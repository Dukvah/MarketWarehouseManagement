using Core.Entities;

namespace Entities.Concrete
{
    public class Stock : IEntity
    {
        public int Id { get; set; }
        public int? IncomingWarehouseID { get; set; }
        public Warehouse? ICWarehouse { get; set; }
        public int? OutgoingWarehouseID { get; set; }
        public Warehouse? OGWarehouse { get; set; }
        public int ProductID { get; set; }
        public Product Product { get; set; }
        public int Quentity { get; set; }
    }
}
