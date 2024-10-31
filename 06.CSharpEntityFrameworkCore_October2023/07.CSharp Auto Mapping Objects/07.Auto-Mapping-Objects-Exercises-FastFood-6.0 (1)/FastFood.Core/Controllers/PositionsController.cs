namespace FastFood.Web.Controllers
{
    using System.Linq;
    using FastFood.Services.Data.Interfaces;
    using FastFood.Web.ViewModel.Positions;
    using Microsoft.AspNetCore.Mvc;

    public class PositionsController : Controller
    {
        private readonly IPositionService positionsService;
        public PositionsController(IPositionService positionsService)
        {
            this.positionsService = positionsService;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreatePositionInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Error", "Home");
            }

            await this.positionsService.CreateAsync(model);

            return RedirectToAction("All", "Positions");
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            IEnumerable<PositionsAllViewModel> positions =
                await this.positionsService.GetAllAsync();

            return View(positions.ToList());
        }
    }
}
