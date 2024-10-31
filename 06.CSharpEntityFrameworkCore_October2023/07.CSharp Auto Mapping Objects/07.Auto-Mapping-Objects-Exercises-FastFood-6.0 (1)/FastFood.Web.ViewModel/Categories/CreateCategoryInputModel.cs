using FastFood.Data.Common.EntityConfiguration;
using FastFood.Data.Common.Messages;
using System.ComponentModel.DataAnnotations;

namespace FastFood.Web.ViewModel.Categories
{
    public class CreateCategoryInputModel
    {
        [StringLength(ViewModelsValidation.CategoryNameMaxLength,
            MinimumLength = ViewModelsValidation.CategoryNameMinLength,
            ErrorMessage = ErrorMessages.CategoryNameErrorMessage)]
        public string CategoryName { get; set; } = null!;
    }
}
