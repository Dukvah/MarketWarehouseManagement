using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IProductService
    {
        IDataResult<List<Product>> GetAll();
        IDataResult<List<Product>> GetByUnitPrice(int min, int max);
        IDataResult<Product> GetById(int productId);
        IResult Add(AddProductDto addProductDto);
        IResult Update(UpdateProductDto updateProductDto, int id);
        IResult Delete(int id);
        IResult AddTransactionalTest(Product product);
    }
}