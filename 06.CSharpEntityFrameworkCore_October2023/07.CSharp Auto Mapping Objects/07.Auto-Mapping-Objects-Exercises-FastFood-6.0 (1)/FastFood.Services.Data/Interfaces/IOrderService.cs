using FastFood.Web.ViewModel.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFood.Services.Data.Interfaces
{
    public interface IOrderService
    {
        Task CreateAsync(CreateOrderInputModel inputModel);
        Task<IEnumerable<OrderAllViewModel>> GetAllAsync();
        Task<IEnumerable<CreateOrderViewModel>> GetAllAvailableOrders();
    }
}
