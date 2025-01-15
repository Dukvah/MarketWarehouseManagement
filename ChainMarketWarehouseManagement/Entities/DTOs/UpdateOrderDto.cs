using Core.Entities;
using Entities.Concrete;

namespace Entities.DTOs
{
    public class UpdateOrderDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CustomerID { get; set; }
        public List<OrderItemDto> OrderItem { get; set; }
        public DateTime CreateDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; }
    }
}
