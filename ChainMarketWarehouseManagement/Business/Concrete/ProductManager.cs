using Business.Abstract;
using Business.Constants;
using Core.Aspects.Autofac.Transaction;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }
        public IDataResult<List<Product>> GetAll()
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.ProductListed);

        }
        public IDataResult<List<Product>> GetByUnitPrice(int minPrice, int maxPrice)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(x => x.Price >= minPrice && x.Price <= maxPrice));
        }
        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.Id == productId));
        }
        public IResult Add(AddProductDto addProductDto)
        {
            var newProduct = new Product();
            newProduct.Sku = addProductDto.Sku;
            newProduct.Name = addProductDto.Name;
            newProduct.Quantity = addProductDto.Quantity;
            newProduct.Price = addProductDto.Price;
            newProduct.ProductCategoryId = addProductDto.ProductCategoryId;
            _productDal.Add(newProduct);
            return new SuccessResult(Messages.ProductAdded);
        }
        public IResult Update(UpdateProductDto updateProductDto, int id)
        {
            var product = GetById(id).Data;
            product.Price = updateProductDto.Price;
            product.Quantity = updateProductDto.Quantity;
            _productDal.Update(product);
            return new SuccessDataResult<Product>(product, Messages.ProductUpdated);
        }

        public IResult Delete(int id)
        {
            var product = GetById(id).Data;
            _productDal.Delete(product);
            return new SuccessResult(Messages.ProductDeleted);
        }

        [TransactionScopeAspect]
        public IResult AddTransactionalTest(Product product)
        {
            throw new NotImplementedException();
        }


    }
}