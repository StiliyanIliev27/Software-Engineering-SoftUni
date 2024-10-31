using FastFood.Data.Common.EntityConfiguration;
using FastFood.Data.Common.Messages;
using System.ComponentModel.DataAnnotations;

namespace FastFood.Web.ViewModel.Positions
{
    public class CreatePositionInputModel
    {        
        [StringLength(ViewModelsValidation.PositionNameMaxLength, 
            MinimumLength = ViewModelsValidation.PositionNameMinLength, 
            ErrorMessage = ErrorMessages.PositionNameErrorMessage)]
        public string PositionName { get; set; } = null!;
    }
}