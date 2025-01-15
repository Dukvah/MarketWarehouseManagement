using Core.Entities;
using Entities.Concrete;

namespace Entities.DTOs
{
    public class AddProductDto : IDto
    {
        public string Sku { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int ProductCategoryId { get; set; }
    }
}
