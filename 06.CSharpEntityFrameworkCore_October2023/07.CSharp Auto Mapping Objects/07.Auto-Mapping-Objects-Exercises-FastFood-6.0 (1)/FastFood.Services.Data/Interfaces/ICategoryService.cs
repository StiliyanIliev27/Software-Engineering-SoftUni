
using FastFood.Web.ViewModel.Categories;

namespace FastFood.Services.Data.Interfaces
{
    public interface ICategoryService
    {
        Task CreateAsync(CreateCategoryInputModel inputModel);
        Task<IEnumerable<CategoryAllViewModel>> GetAllAsync();
    }
}
