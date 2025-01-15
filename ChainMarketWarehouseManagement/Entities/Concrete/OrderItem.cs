using System.ComponentModel.DataAnnotations;
using Core.Entities;

namespace Entities.Concrete
{
    public class OrderItem : IEntity
    {
        [Key]
        public int OrderItemId { get; set; }
        public int? ProductID { get; set; }
        public Product? Product { get; set; }
        public int Quantity { get; set; }
        public int OrderID { get; set; }
        public Order Order { get; set; }
    }
}
