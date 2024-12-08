namespace ProiectMPA.Models
{
    public class CartViewModel
    {
        public List<OrderItem> Cart { get; set; } = new List<OrderItem>();
        public int DeliveryAddressId { get; set; }
        public List<DeliveryAddress> DeliveryAddresses { get; set; } = new List<DeliveryAddress>();
    }
}
