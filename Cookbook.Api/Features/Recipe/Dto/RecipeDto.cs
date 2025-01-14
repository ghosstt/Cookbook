﻿using System;
using System.Collections.Generic;

namespace Cookbook.Api.Features.Recipe.Dto
{
    public class RecipeDto
    {
        public int RecipeId { get; set; }
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImgSrc { get; set; }
        public IEnumerable<int> IngredientIds { get; set; }
    }
}
