using Autofac;
using Business.Abstract;
using Business.Concrete;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProductManager>().As<IProductService>().SingleInstance();
            builder.RegisterType<ProductCategoryManager>().As<IProductCategoryService>().SingleInstance();
            builder.RegisterType<OrderManager>().As<IOrderService>().SingleInstance();
            builder.RegisterType<WarehouseManager>().As<IWarehouseService>().SingleInstance();
            builder.RegisterType<StockManager>().As<IStockService>().SingleInstance();


            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();

            builder.RegisterType<EFOrderDal>().As<IOrderDal>();
            builder.RegisterType<EFOrderItemDal>().As<IOrderItemDal>();

            builder.RegisterType<EFCustomerDal>().As<ICustomerDal>();

            builder.RegisterType<EFProductDal>().As<IProductDal>();

            builder.RegisterType<EFProductCategoryDal>().As<IProductCategoryDal>();

            builder.RegisterType<EFWarehouseDal>().As<IWarehouseDal>();

            builder.RegisterType<EFStockDal>().As<IStockDal>();

            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();
        }
    }
}