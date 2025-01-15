using Core.Entities;

namespace Entities.DTOs
{
    public class UpdateProductDto : IDto
    {
        public string Sku { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int CategoryID { get; set; }
    }
}
