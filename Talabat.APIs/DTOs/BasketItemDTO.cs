using System.ComponentModel.DataAnnotations;

namespace Talabat.APIs.DTOs
{
    public class BasketItemDTO
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string ProductName { get; set; }

        [Required]
        public string PictureURL { get; set; }

        [Required]
        [Range(0.1, double.MaxValue)]
        public decimal Price { get; set; }

        [Required]
        public string Brand { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }
    }
}