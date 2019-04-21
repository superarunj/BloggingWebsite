﻿using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repositories
{
    public class PostsRepository
    {
        BlogDbContext context;
        public PostsRepository(BlogDbContext context)
        {
            this.context = context;
        } 

        public Post GetPostById(long id)
        {
            return this.context.Posts.Find(id);
        }
    }
}
