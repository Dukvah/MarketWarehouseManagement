using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.DTOs
{
    public class OrderItemDto : IDto
    {
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public int OrderID { get; set; }
    }
}
