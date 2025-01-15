using Core.Entities;

namespace Entities.DTOs
{
    public class AddWarehouseDto : IDto
    {
        public string Address { get; set; }
        public string Name { get; set; }
        public int MainWarehouseID { get; set; }
    }
}
