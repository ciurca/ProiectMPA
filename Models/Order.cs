using Microsoft.AspNetCore.Identity;
using ProiectMPA.Models.Enums;

namespace ProiectMPA.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public IdentityUser User { get; set; }
        public int DeliveryAddress {  get; set; }
        public DeliveryAddress Address { get; set; }
        public string? SpecialMentions { get; set; }
        public DateTime CreatedAt {  get; set; }
        public decimal TotalPrice { get; set; }
        public OrderStatus Status { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
