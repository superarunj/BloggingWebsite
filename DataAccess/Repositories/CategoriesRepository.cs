﻿using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repositories
{
    public class CategoriesRepository : ICategoriesRepository
    {
        private BlogDbContext context;
        public CategoriesRepository(BlogDbContext context)
        {
            this.context = context;
        }
    }
}