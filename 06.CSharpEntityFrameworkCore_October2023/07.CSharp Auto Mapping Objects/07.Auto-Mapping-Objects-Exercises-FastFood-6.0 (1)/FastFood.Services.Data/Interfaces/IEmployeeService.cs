using FastFood.Web.ViewModel.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFood.Services.Data.Interfaces
{
    public interface IEmployeeService
    {
        Task CreateAsync(RegisterEmployeeInputModel inputModel);
        Task<IEnumerable<EmployeesAllViewModel>> GetAllAsync();
        Task<IEnumerable<RegisterEmployeeViewModel>> GetAllAvailablePositions();
    }
}
