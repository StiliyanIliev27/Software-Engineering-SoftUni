using AutoMapper;
using FastFood.Data;
using FastFood.Services.Data.Interfaces;
using FastFood.Web.ViewModel.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFood.Services.Data
{
    public class OrderService : IOrderService
    {
        private readonly IMapper mapper;
        private readonly FastFoodContext context;

        //Dependency Injection
        public OrderService(IMapper mapper, FastFoodContext context)
        {
            this.mapper = mapper;
            this.context = context;
        }
        public Task CreateAsync(CreateOrderInputModel inputModel)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<OrderAllViewModel>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CreateOrderViewModel>> GetAllAvailableOrders()
        {
            throw new NotImplementedException();
        }
    }
}
