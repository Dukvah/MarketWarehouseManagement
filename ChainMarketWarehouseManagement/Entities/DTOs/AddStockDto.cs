using Core.Entities;

namespace Entities.DTOs
{
    public class AddStockDto : IDto
    {
        public int IncomingWarehouseID { get; set; }
        public int OutgoingWarehouseID { get; set; }
        public int ProductID { get; set; }
        public int Quentity { get; set; }
    }
}

