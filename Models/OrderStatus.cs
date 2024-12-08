using Microsoft.AspNetCore.Identity;
using ProiectMPA.Models.Enums;

namespace ProiectMPA.Models
{
    public class OrderStatus
    {
        public int Id { get; set; }
        public int OrderId {  get; set; }
        public Order? Order { get; set; }
        public OrderStatusEnum Status { get; set; }
        public DateTime Timestamp { get; set; }
        public string EmployeeId { get; set; }
        public IdentityUser?Employee { get; set; }

    }
}
