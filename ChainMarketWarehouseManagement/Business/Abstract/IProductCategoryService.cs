using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IProductCategoryService
    {
        IDataResult<List<ProductCategory>> GetAll();
        IDataResult<ProductCategory> GetById(int productId);
        IResult Add(AddProductCategoryDto productCategoryDto);
        IResult Update(UpdateProductCategoryDto updateProductCategoryDto, int id);
        IResult Delete(int id);
    }
}
