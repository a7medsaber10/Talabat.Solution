using System.ComponentModel.DataAnnotations;

namespace Talabat.APIs.DTOs
{
    public class CustomerBasketDTO
    {
        [Required]
        public string Id { get; set; }
        public List<BasketItemDTO> Items { get; set; }

        public string? ClientSecret { get; set; }
        public string? PaymentIntent { get; set; }

        public int? DeliveryMethodId { get; set; }
    }
}
