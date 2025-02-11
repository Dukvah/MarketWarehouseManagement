using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class ProductCategoryManager : IProductCategoryService
    {
        private readonly IProductCategoryDal _productCategoryDal;
        public ProductCategoryManager(IProductCategoryDal productCategoryDal)
        {
            _productCategoryDal = productCategoryDal;
        }

        public IResult Add(AddProductCategoryDto addProductCategoryDto)
        {
            var productCategory = new ProductCategory();
            productCategory.Name = addProductCategoryDto.Name;
            _productCategoryDal.Add(productCategory);

            return new SuccessDataResult<AddProductCategoryDto>(addProductCategoryDto,Messages.ProductCategoryAdded);
        }

        public IResult Delete(int id)
        {
            var productCategory = GetById(id).Data;
            _productCategoryDal.Delete(productCategory);
            return new SuccessResult(Messages.ProductCategoryDeleted);
        }

        public IDataResult<List<ProductCategory>> GetAll()
        {
            return new SuccessDataResult<List<ProductCategory>>(_productCategoryDal.GetAll(), Messages.ProductCategoryListed);
        }

        public IDataResult<ProductCategory> GetById(int productCategoryId)
        {
            return new SuccessDataResult<ProductCategory>(_productCategoryDal.Get(p => p.ProductCategoryId == productCategoryId));
        }

        public IResult Update(UpdateProductCategoryDto updateProductCategoryDto, int id)
        {
            var productCategory = GetById(id).Data;
            productCategory.Name = updateProductCategoryDto.Name;
            _productCategoryDal.Update(productCategory);
            return new SuccessDataResult<ProductCategory>(productCategory, Messages.ProductCategoryUpdated);
        }
    }
}
