using AutoMapper;
using Cookbook.Api.Data;
using Cookbook.Api.Features.Ingredient.Dto;
using Entities = Cookbook.Api.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace Cookbook.Api.Features.Ingredient.Services
{
    public class IngredientService : IIngredientService
    {
        private readonly CookbookDbContext _context;
        private readonly IMapper _mapper;

        public IngredientService(CookbookDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IngredientDto> GetIngredient(Guid userId, int ingredientId)
        {
            var ingredient = await _context.Ingredients.FirstOrDefaultAsync(i => i.UserId == userId && i.IngredientId == ingredientId);
            return _mapper.Map<IngredientDto>(ingredient);
        }

        public async Task<IEnumerable<IngredientDto>> GetIngredients(Guid userId)
        {
            var ingredients = await _context.Ingredients.Where(i => i.UserId == userId).OrderByDescending(i => i.CreatedDate).ToListAsync();
            return _mapper.Map<IEnumerable<IngredientDto>>(ingredients);
        }

        public async Task<int> AddIngredient(IngredientDto ingredientDto)
        {
            if (await _context.Recipes.AnyAsync(i => i.Name == ingredientDto.Name))
                throw new Exception($"Error: Ingredient '{ingredientDto.Name}' already exists");

            ingredientDto.IngredientId = 0;

            var ingredient = _mapper.Map<Entities.Ingredient >(ingredientDto);

            await _context.Ingredients.AddAsync(ingredient);
            await _context.SaveChangesAsync();

            return ingredient.IngredientId;
        }

        public async Task<int> UpdateIngredient(IngredientDto ingredientDto)
        {
            if (await _context.Ingredients.AnyAsync(i => i.IngredientId != ingredientDto.IngredientId && i.Name == ingredientDto.Name))
                throw new Exception($"Error: Ingredient '{ingredientDto.Name}' already exists");

            var ingredient = await _context.Ingredients.FirstOrDefaultAsync(i => i.IngredientId == ingredientDto.IngredientId);
            if (ingredient == null)
                throw new Exception($"Error: Ingredient with ID: {ingredientDto.IngredientId} not found ");

            ingredient.Name = ingredientDto.Name;
            ingredient.Description = ingredientDto.Description;
            ingredient.ImgSrc = ingredientDto.ImgSrc;

            _context.Ingredients.Update(ingredient);
            await _context.SaveChangesAsync();
            return ingredient.IngredientId;
        }
    }
}
