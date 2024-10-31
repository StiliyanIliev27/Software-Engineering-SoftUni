namespace FastFood.Web.ViewModel.Orders
{
    using FastFood.Web.ViewModel.Employees;
    using FastFood.Web.ViewModel.Items;
    using System.Collections.Generic;

    public class CreateOrderViewModel
    {
        public CreateOrderViewModel()
        {
            Items = new List<ItemsAllViewModel>();
            Employees = new List<EmployeesAllViewModel>();
        }
        public List<ItemsAllViewModel> Items { get; set; }

        public List<EmployeesAllViewModel> Employees { get; set; }
    }
}
