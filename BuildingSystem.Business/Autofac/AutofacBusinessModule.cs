using Autofac;
using BuildingSystem.Business.Abstract;
using BuildingSystem.Business.AutoMapper;
using BuildingSystem.Business.Concrete;
using BuildingSystem.Business.UnitOfWork;
using BuildingSystem.DataAccess.Abstract;
using BuildingSystem.DataAccess.Concrete;
using BuildingSystem.DataAccess.Context;
using System.Reflection;
using Module = Autofac.Module;

namespace BuildingSystem.Business.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IGenericRepository<>)).InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(Service<>)).As(typeof(IService<>)).InstancePerLifetimeScope();

            builder.RegisterType<BuildingSystem.Business.UnitOfWork.UnitOfWork>().As<IUnitOfWork>();


            var apiAssembly = Assembly.GetExecutingAssembly();
            var DataAssembly = Assembly.GetAssembly(typeof(ApplicationDbContext));
            var BusinessAssembly = Assembly.GetAssembly(typeof(MapProfile));

            builder.RegisterAssemblyTypes(apiAssembly, DataAssembly, BusinessAssembly).Where(x => x.Name.EndsWith
            ("Repository")).AsImplementedInterfaces().InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(apiAssembly, DataAssembly, BusinessAssembly).Where(x => x.Name.EndsWith
           ("Service")).AsImplementedInterfaces().InstancePerLifetimeScope();

            //InstancePerLifetimeScope => Scope karşılık gelir.



            //builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IGenericRepository<>));
            //builder.RegisterGeneric(typeof(Service<>)).As(typeof(IService<>));

            //builder.RegisterType(typeof(BlockService)).As(typeof(IBlockService));
            //builder.RegisterType(typeof(BlockRepository)).As(typeof(IBlockRepository));
            //builder.RegisterType(typeof(BuildingRepository)).As(typeof(IBuildingRepository));
            //builder.RegisterType(typeof(BuildingService)).As(typeof(BuildingService));



        }
    }
}
