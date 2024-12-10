using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace ProiectMPA.Models
{
    public class DeliveryAddress
    {
        public int Id { get; set; }
        [ForeignKey("AspNetUsers")]
        public string UserId { get; set; }
        public IdentityUser? User { get; set; }
        public string? Description { get; set; }
        public string Address {  get; set; }

    }
}
