namespace FastFood.Web.Controllers
{
    using FastFood.Services.Data.Interfaces;
    using FastFood.Web.ViewModel.Categories;
    using Microsoft.AspNetCore.Mvc;

    public class CategoriesController : Controller
    {
        private readonly ICategoryService categoriesService;

        public CategoriesController(ICategoryService categoriesService)
        {
            this.categoriesService = categoriesService;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Error", "Home");
            }

            await this.categoriesService.CreateAsync(model);

            return RedirectToAction("All", "Categories");
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            IEnumerable<CategoryAllViewModel> categories = 
                await this.categoriesService.GetAllAsync();

            return View(categories.ToList());
        }
    }
}
