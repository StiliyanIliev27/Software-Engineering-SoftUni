namespace FastFood.Data.Models
{
    using FastFood.Data.Common.EntityConfiguration;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Employee
    {
        public Employee()
        {
            Id = Guid.NewGuid().ToString();
            Orders = new HashSet<Order>();
        }
      
        [Key]
        [MaxLength(EntitiesValidation.GuidMaxLength)]
        public string Id { get; set; }

        [MaxLength(EntitiesValidation.EmployeeNameMaxLength)]
        public string Name { get; set; } = null!;

        [Range(15, 80)]
        public int Age { get; set; }

        [MaxLength(EntitiesValidation.EmployeeAddressMaxLength)]
        public string Address { get; set; } = null!;

        public int PositionId { get; set; }
        
        [ForeignKey(nameof(PositionId))]

        public virtual Position Position { get; set; } = null!;

        public virtual ICollection<Order> Orders { get; set; }
    }
}