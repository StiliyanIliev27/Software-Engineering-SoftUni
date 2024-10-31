using AutoMapper;
using AutoMapper.QueryableExtensions;
using FastFood.Data;
using FastFood.Data.Models;
using FastFood.Services.Data.Interfaces;
using FastFood.Web.ViewModel.Employees;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFood.Services.Data
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IMapper mapper;
        private readonly FastFoodContext context;

        public EmployeeService(IMapper mapper, FastFoodContext context)
        {
            this.mapper = mapper;
            this.context = context;
        }

        public async Task CreateAsync(RegisterEmployeeInputModel inputModel)
        {
            Employee employee = this.mapper.Map<Employee>(inputModel);
            
            await this.context.Employees.AddAsync(employee);
            await this.context.SaveChangesAsync();
        }

        public async Task<IEnumerable<EmployeesAllViewModel>> GetAllAsync()
            => await this.context.Employees
                .ProjectTo<EmployeesAllViewModel>(this.mapper.ConfigurationProvider)
                .ToArrayAsync();

        public async Task<IEnumerable<RegisterEmployeeViewModel>> GetAllAvailablePositions()
            => await this.context.Positions
                .ProjectTo<RegisterEmployeeViewModel>(this.mapper.ConfigurationProvider)
                .ToArrayAsync();                   
    }
}
