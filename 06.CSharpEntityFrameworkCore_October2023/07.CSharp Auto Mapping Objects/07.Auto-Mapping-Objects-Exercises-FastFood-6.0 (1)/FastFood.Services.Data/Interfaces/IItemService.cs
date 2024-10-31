using FastFood.Web.ViewModel.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFood.Services.Data.Interfaces
{
    public interface IItemService
    {
        Task CreateAsync(CreateItemInputModel inputModel);
        Task<IEnumerable<ItemsAllViewModel>> GetAllAsync();
        Task<IEnumerable<CreateItemViewModel>> GetAllAvailableCategories();
    }
}
