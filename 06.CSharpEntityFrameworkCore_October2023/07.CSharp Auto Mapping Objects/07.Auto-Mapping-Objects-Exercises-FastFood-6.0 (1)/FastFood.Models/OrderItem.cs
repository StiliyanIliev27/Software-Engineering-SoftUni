namespace FastFood.Data.Models
{
    using FastFood.Data.Common.EntityConfiguration;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class OrderItem
    {
        [MaxLength(EntitiesValidation.GuidMaxLength)]
        [ForeignKey(nameof(OrderId))]
        public string OrderId { get; set; } = null!;       
        
        public virtual Order Order { get; set; } = null!;

        [MaxLength(EntitiesValidation.GuidMaxLength)]
        [ForeignKey(nameof(ItemId))]
        public string ItemId { get; set; } = null!;
        
        public virtual Item Item { get; set; } = null!;

        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }
    }
}