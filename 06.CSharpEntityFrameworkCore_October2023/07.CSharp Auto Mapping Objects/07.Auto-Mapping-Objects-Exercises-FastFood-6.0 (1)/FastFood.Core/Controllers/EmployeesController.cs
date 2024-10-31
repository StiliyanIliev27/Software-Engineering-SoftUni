namespace FastFood.Web.Controllers
{
    using System;
    using AutoMapper;
    using Data;
    using FastFood.Services.Data.Interfaces;
    using FastFood.Web.ViewModel.Employees;
    using Microsoft.AspNetCore.Mvc;

    public class EmployeesController : Controller
    {
        private readonly IEmployeeService employeeService;
        public EmployeesController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        [HttpGet]
        public async Task<IActionResult> Register()
        {
            IEnumerable<RegisterEmployeeViewModel> availablePositions =
                await this.employeeService.GetAllAvailablePositions();

            return View(availablePositions);    
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterEmployeeInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Error", "Home");
            }

            await this.employeeService.CreateAsync(model);

            return RedirectToAction("All", "Employees");
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            IEnumerable<EmployeesAllViewModel> employees =
                await this.employeeService.GetAllAsync();

            return View(employees.ToList());
        }
    }
}
