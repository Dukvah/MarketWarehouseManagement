using Core.DataAccess;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IProductDal : IEntityRepository<Product>
    {   
        IQueryable<Product> GetAllQueryable();
    }
}
