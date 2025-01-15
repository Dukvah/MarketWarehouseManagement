using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Entities.Concrete;

namespace Entities.DTOs
{
    public class OrderDetailDto : IDto
    {
        public string Name { get; set; }
        public int CustomerID { get; set; }
        public List<OrderItemDto> OrderItem { get; set; }
        public DateTime CreateDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; }
    }
}
