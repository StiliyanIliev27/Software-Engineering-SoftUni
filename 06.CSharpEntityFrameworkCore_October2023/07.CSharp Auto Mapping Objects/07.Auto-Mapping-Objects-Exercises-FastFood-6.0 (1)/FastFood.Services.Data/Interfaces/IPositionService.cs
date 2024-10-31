using FastFood.Web.ViewModel.Positions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFood.Services.Data.Interfaces
{
    public interface IPositionService
    {
        Task CreateAsync(CreatePositionInputModel inputModel);
        Task<IEnumerable<PositionsAllViewModel>> GetAllAsync();
    }
}
