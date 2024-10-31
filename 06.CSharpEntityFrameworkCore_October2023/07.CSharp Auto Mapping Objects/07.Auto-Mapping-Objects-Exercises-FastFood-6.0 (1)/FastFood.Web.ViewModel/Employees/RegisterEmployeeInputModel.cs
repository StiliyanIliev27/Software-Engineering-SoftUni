using FastFood.Data.Common.EntityConfiguration;
using FastFood.Data.Common.Messages;
using System.ComponentModel.DataAnnotations;

namespace FastFood.Web.ViewModel.Employees
{
    public class RegisterEmployeeInputModel
    {
        [StringLength(ViewModelsValidation.EmployeeNameMaxLength,
            MinimumLength = ViewModelsValidation.EmployeeNameMinLength, 
            ErrorMessage = ErrorMessages.EmployeeNameErrorMessage)]
        public string Name { get; set; } = null!;

        [Range(15 , 80)]
        public int Age { get; set; }

        public int PositionId { get; set; }

        public string PositionName { get; set; } = null!;

        [StringLength(ViewModelsValidation.EmployeeAddressMaxLength,
            MinimumLength = ViewModelsValidation.EmployeeAddressMinLength,
            ErrorMessage = ErrorMessages.EmployeeAddressErrorMessage)]
        public string Address { get; set; } = null!;
    }
}
