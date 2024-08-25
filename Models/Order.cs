using PetShopQa.Enums;

namespace PetShopQa.Models
{
    public class Order
    {
        public ulong Id { get; set; } 
        public ulong PetId { get; set; } 
        public int Quantity { get; set; } 
        public DateTime? ShipDate { get; set; }
        public OrderStatus Status { get; set; }
        public bool Complete { get; set; }
        
        public static Order Create(
            ulong id = 0,
            ulong petId = 0,
            int quantity = 1,
            DateTime? shipDate = null,
            OrderStatus orderStatus = OrderStatus.Approved,
            bool complete = false)
        {
            shipDate ??= DateTime.Today;

            return new Order()
            {
                Id = id,
                PetId = petId,
                Quantity = quantity,
                ShipDate = shipDate,
                Status = orderStatus,
                Complete = complete
            };
        }
    }
}