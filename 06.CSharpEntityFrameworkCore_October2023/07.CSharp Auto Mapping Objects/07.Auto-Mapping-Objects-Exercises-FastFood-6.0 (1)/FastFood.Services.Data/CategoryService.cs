
using AutoMapper;
using AutoMapper.QueryableExtensions;
using FastFood.Data;
using FastFood.Data.Models;
using FastFood.Services.Data.Interfaces;
using FastFood.Web.ViewModel.Categories;
using Microsoft.EntityFrameworkCore;

namespace FastFood.Services.Data
{
    public class CategoryService : ICategoryService
    {
        private readonly IMapper mapper;
        private readonly FastFoodContext context;

        public CategoryService(IMapper mapper, FastFoodContext context)
        {
            this.mapper = mapper;
            this.context = context;
        }
        public async Task CreateAsync(CreateCategoryInputModel inputModel)
        {
            Category category = this.mapper.Map<Category>(inputModel);

            await context.Categories.AddAsync(category);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<CategoryAllViewModel>> GetAllAsync()
            => await context.Categories
                .ProjectTo<CategoryAllViewModel>(this.mapper.ConfigurationProvider)
                .ToArrayAsync();
    }
}
