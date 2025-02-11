using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EFProductDal : EfEntityRepositoryBase<Product, WarehouseManagementContext>, IProductDal
    {
        private readonly WarehouseManagementContext _context;

        public EFProductDal(WarehouseManagementContext context)
        {
            _context = context;
        }
        public IQueryable<Product> GetAllQueryable()
        {
            return _context.Products.AsQueryable();
        }
    }
}
