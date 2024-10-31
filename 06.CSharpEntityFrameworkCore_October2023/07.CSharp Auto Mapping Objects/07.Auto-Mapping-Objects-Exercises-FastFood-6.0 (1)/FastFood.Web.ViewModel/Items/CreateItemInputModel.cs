using FastFood.Data.Common.EntityConfiguration;
using FastFood.Data.Common.Messages;
using System.ComponentModel.DataAnnotations;

namespace FastFood.Web.ViewModel.Items
{
    public class CreateItemInputModel
    {
        [StringLength(ViewModelsValidation.ItemNameMaxLength,
            MinimumLength = ViewModelsValidation.ItemNameMinLength,
            ErrorMessage = ErrorMessages.ItemNameErrorMessage)]
        public string Name { get; set; } = null!;

        [Range(typeof(decimal), "0.01", "79228162514264337593543950335")]
        public decimal Price { get; set; }

        public int CategoryId { get; set; }
    }
}
