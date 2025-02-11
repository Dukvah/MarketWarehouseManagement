using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.EntityFrameworkCore;

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

            builder.RegisterType<EFUserDal>().As<IUserDal>();
            builder.RegisterType<EFOrderDal>().As<IOrderDal>();
            builder.RegisterType<EFOrderItemDal>().As<IOrderItemDal>();
            builder.RegisterType<EFCustomerDal>().As<ICustomerDal>();
            builder.RegisterType<EFProductDal>().As<IProductDal>();
            builder.RegisterType<EFProductCategoryDal>().As<IProductCategoryDal>();
            builder.RegisterType<EFWarehouseDal>().As<IWarehouseDal>();
            builder.RegisterType<EFStockDal>().As<IStockDal>();

            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();

            // DbContext'in Autofac ile yönetilmesi için eklenmesi
            builder.Register(context =>
            {
                var optionsBuilder = new DbContextOptionsBuilder<WarehouseManagementContext>();
                optionsBuilder.UseMySql("server=localhost;port=3306;user=root;password=;database=warehousedb",
                    ServerVersion.AutoDetect("server=localhost;port=3306;user=root;password=;database=warehousedb"));
                return new WarehouseManagementContext(optionsBuilder.Options);
            }).AsSelf().InstancePerLifetimeScope();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions() 
                { 
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
            
        }
    }
}