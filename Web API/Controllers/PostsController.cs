﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DataAccess;
using DataAccess.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shared_Library.ViewModels.Input;
using Shared_Library.ViewModels.Output;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web_API.Controllers
{
    [Route("api/[controller]")]
    public class PostsController : Controller
    {
        UnitOfWork unitOfWork;
        public PostsController(UnitOfWork unitOfWork)
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

        public IActionResult SearchPosts(string example)
        {
            var posts = this.unitOfWork.PostsFetcher.GetPostsByASearch(example);
            return Ok(posts);
        }

        // GET api/<controller>/5

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var post = this.unitOfWork.PostsRepository.GetById(id);
            if (post == null)
                return NotFound();
            else
            {
                PostViewModel vm = new PostViewModel
                {
                    PostId = post.PostId,
                    Title = post.Title,
                    Text = post.Text,
                    PostedOn = post.PostedOn,
                    NumberOfViews = post.NumberOfViews,
                    ReadTime = post.ReadTime,
                    UserId = post.UserId,
                    AuthorFirstName = post.User.FirstName,
                    AuthorLastName = post.User.LastName,
                    AuthorBiography = post.User.Biography
                };
                return Ok(vm);
            }
        }

        [Route("{id}/recommended")]
        public IActionResult GetRecommmendedPosts(long id)
        {
            return Ok(this.unitOfWork.PostsFetcher.GetRecommendedPosts(id));
        }

        [Authorize(Roles = "Blogger")]
        [HttpPost]
        //Needs refactoring
        //Warning - post content should be sanatized
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
                    if (this.unitOfWork.TagsFetcher.DoesExist(tag))
                    {
                        return null;
                    }
                    else
                    {
                        this.unitOfWork.TagsRepository.Add(new Tag { Name = tag });
                    }
                }
                await this.unitOfWork.Save();
                return null;
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
            const byte averageNoOfCharactersWord = 6;
            double numberOfCharacters = content.Length * 1.0;
            return (byte)Math.Floor(numberOfCharacters / (250 * 6));
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}