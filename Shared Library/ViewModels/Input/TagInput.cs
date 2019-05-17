﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Shared_Library.ViewModels.Input
{
    public class TagInput
    {
        [RegularExpression(@"^[\w\-]{2,15}$")]
        public string Name { get; set; }
    }
}