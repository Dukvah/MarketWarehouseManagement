using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.Concrete
{
    public class Warehouse : IEntity
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string Name { get; set; }
        public int? MainWarehouseID { get; set; }
    }
}
