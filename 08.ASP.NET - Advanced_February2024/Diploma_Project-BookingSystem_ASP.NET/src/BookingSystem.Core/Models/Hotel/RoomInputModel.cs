namespace BookingSystem.Core.Models.Hotel
{
    using BookingSystem.Core.Contracts;
    using System.ComponentModel.DataAnnotations;
    using static BookingSystem.Infrastructure.Data.Constants.DataConstants.Room;
    public class RoomInputModel : IHotelModel
    {
        public int Id { get; set; }
        
        [Required]
        public string Type { get; set; } = null!;

        [Required]
        [Display(Name = "Price per Night")]
        [Range(MinPricePerNight,MaxPricePerNight, ErrorMessage = PriceErrorMessage)]
        public decimal PricePerNight { get; set; }

        [Required]
        public int Hotel_Id { get; set; }

        [Required]
        [Display(Name = "Wi-fi")]
        public string Wifi { get; set; } = null!;

        public IEnumerable<string> Types { get; set; } = new HashSet<string>();
        public IEnumerable<string> WifiAvailability { get; set; } = new List<string>() { "Available", "Not Available" };

        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
    }
}
