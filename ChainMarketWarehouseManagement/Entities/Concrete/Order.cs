using System.ComponentModel.DataAnnotations.Schema;
using Core.Entities;

namespace Entities.Concrete
{
    public class Order : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CustomerID { get; set; }
        public DateTime CreateDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; }
    }
}
