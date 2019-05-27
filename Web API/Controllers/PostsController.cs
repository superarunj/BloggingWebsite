﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Application.Interfaces;
using Application.ViewModels.Input;
using Application.ViewModels.Output;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web_API.Controllers
{
    [Route("api/[controller]")]
    public class PostsController : Controller
    {
        IUnitOfWork unitOfWork;
        public PostsController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [Route("postspreview/{page?}")]
        [HttpGet]
        public IActionResult GetRecentPosts(int? page)
        {
            var posts = this.unitOfWork.PostsFetcher.GetRecentPostsPreview(page);
            return Ok(posts);
        }
        
        [Route("postspreview/category/{category}/{page?}")]
        [HttpGet]
        public IActionResult GetRecentPostsByCategory(int category, int? page)
        {
            var posts = this.unitOfWork.PostsFetcher.GetRecentPostsPreviewByCategory(page,category);
            return Ok(posts);
        }

        [Route("postspreview/tag/{tag}/{page?}")]
        [HttpGet]
        public IActionResult GetRecentPostsByTag(int tag, int? page)
        {
            var posts = this.unitOfWork.PostsFetcher.GetRecentPostsPreviewByTag(page, tag);
            return Ok(posts);
        }

        [HttpGet("search/{query}")]
        public IActionResult SearchPosts(string query)
        {
            var posts = this.unitOfWork.PostsFetcher.GetPostsByASearch(query);
            return Ok(posts);
        }

        [HttpGet("{id}")]
        [ActionName("PostGet")]
        public IActionResult Get(long id)
        {
            var post = this.unitOfWork.PostsFetcher.GetPostByPostId(id);
            if (post == null)
                return NotFound();
            else
                return Ok(post);
        }

        [HttpGet]
        [Route("{id}/recommended")]
        public IActionResult GetRecommmendedPosts(long id)
        {
            var posts = this.unitOfWork.PostsFetcher.GetRecommendedPosts(id);
            return Ok(posts);
        }

        [Authorize(Roles = "Blogger")]
        [HttpPost]
        // to be continued
        public async Task<IActionResult> Post([FromBody]NewPostViewModel newPost)
        {
            if (ModelState.IsValid)
            {
                Post post = new Post
                {
                    CategoryId = newPost.CategoryId,
                    UserId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value,
                    Title = newPost.Title,
                    Text = newPost.Content,
                    PostedOn = DateTime.UtcNow,
                    NumberOfViews = 0,
                    ReadTime = this.CalculateReadTime(newPost.Content)
                };
                this.unitOfWork.PostsRepository.Add(post);
                var tags = newPost.Tags;
                foreach (var tag in tags)
                {
                    var wantedTag = this.unitOfWork.TagsRepository.GetByName(tag);
                    if (wantedTag == null)
                    {
                        wantedTag = new Tag { Name = tag };
                        this.unitOfWork.TagsRepository.Add(wantedTag);
                    }
                    this.unitOfWork.PostsRepository.AddPostTag(new PostTag
                    {
                        Tag = wantedTag,
                        Post = post
                    });
                }
                await this.unitOfWork.Save();
                return CreatedAtAction("PostGet", new { id = post.PostId });
            }
            else
            {
                return BadRequest();
            }
        }

        // Dummy calculation. It's not precise.
        private byte CalculateReadTime(string content)
        {
            const short wordsPerMinute = 250;
            double numberOfCharacters = content.Length * 1.0;
            return (byte)Math.Ceiling(numberOfCharacters / wordsPerMinute);
        }

        [Authorize(Roles = "Blogger")]
        [HttpPatch("{id}")]
        //to be continued
        public async Task<IActionResult> Patch(long id, [FromBody]NewPostViewModel model)
        {
            if (ModelState.IsValid)
            {
                var post = this.unitOfWork.PostsRepository.GetById(id);
                if (post == null)
                    return NotFound();
                else
                {
                    post.CategoryId = model.CategoryId;
                    post.Title = model.Title;
                    post.Text = model.Content;
                    foreach(var tag in model.Tags)
                    {
                        var wantedTag = this.unitOfWork.TagsRepository.GetByName(tag);
                        if (wantedTag == null)
                        {
                            wantedTag = new Tag { Name = tag };
                            this.unitOfWork.TagsRepository.Add(wantedTag);
                            this.unitOfWork.PostsRepository.AddPostTag(new PostTag
                            {
                                Tag = wantedTag,
                                Post = post
                            });
                        }
                        else
                        {
                            if(!this.unitOfWork.PostsRepository.HasTag(post.PostId, wantedTag.TagId))
                            {
                                PostTag postTag = new PostTag { PostId = post.PostId, TagId = wantedTag.TagId };
                                this.unitOfWork.PostsRepository.AddPostTag(postTag);
                            }
                        }
                    }
                }
                await this.unitOfWork.Save();
                return NoContent();
            }
            else
            {
                return BadRequest();
            }
        }

        [Authorize(Roles = "Moderator,Blogger")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var post = this.unitOfWork.PostsRepository.GetById(id);
            if (post == null)
                return NotFound();
            else
            {
                var userId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;
                var role = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role).Value;
                // only bloggers and moderators may approach to this line of code
                // then
                if (userId != post.UserId && role == "Blogger")
                    return Forbid();
                else
                {
                    this.unitOfWork.PostsRepository.Delete(post);
                    await this.unitOfWork.Save();
                    return NoContent();
                }
            }
        }
    }
}
