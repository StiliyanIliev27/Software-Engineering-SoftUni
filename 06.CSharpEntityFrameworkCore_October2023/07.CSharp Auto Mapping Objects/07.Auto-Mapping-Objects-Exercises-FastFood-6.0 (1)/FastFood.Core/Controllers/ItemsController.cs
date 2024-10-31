namespace FastFood.Web.Controllers
{
    using System;
    using System.Linq;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Data;
    using FastFood.Services.Data.Interfaces;
    using FastFood.Web.ViewModel.Items;
    using Microsoft.AspNetCore.Mvc;

    public class ItemsController : Controller
    {
        private readonly IItemService itemService;
        public ItemsController(IItemService itemService)
        {
            this.itemService = itemService;
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            IEnumerable<CreateItemViewModel> availableCategories =
                await this.itemService.GetAllAvailableCategories();

            return View(availableCategories);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateItemInputModel model)
        {
            if(!this.ModelState.IsValid)
            {
                return RedirectToAction("Error", "Home");
            }

            await this.itemService.CreateAsync(model);

            return RedirectToAction("All", "Items");
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            IEnumerable<ItemsAllViewModel> items =
                await this.itemService.GetAllAsync();

            return View(items.ToList());
        }
    }
}
