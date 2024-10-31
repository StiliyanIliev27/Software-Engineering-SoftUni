namespace FastFood.Web.Controllers
{
    using System;
    using System.Linq;
    using AutoMapper;
    using Data;
    using FastFood.Services.Data.Interfaces;
    using FastFood.Web.ViewModel.Orders;
    using Microsoft.AspNetCore.Mvc;

    public class OrdersController : Controller
    {
        private readonly IOrderService orderService;
        public OrdersController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        [HttpGet]
        public IActionResult Create()
        {
            //var viewOrder = new CreateOrderViewModel
            //{
            //    Items = _context.Items.Select(x => x.Id).ToList(),
            //    Employees = _context.Employees.Select(x => x.Id).ToList(),
            //};

            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateOrderInputModel model)
        {
            return RedirectToAction("All", "Orders");
        }

        [HttpGet] 
        public IActionResult All()
        {
            throw new NotImplementedException();
        }
    }
}
