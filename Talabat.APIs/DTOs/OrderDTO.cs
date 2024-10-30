using System.ComponentModel.DataAnnotations;
using Talabat.Core.Order_Aggregate;

namespace Talabat.APIs.DTOs
{
    public class OrderDTO
    {
        [Required]
        public string BuyerEmail { get; set; }
        [Required]
        public string BasketId { get; set; }
        [Required]
        public int DeliveryMathod { get; set; }

        public AddressDTO ShippingAddress { get; set; }
    }
}
