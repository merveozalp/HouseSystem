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
            builder.RegisterType<BuildingSystem.Business.UnitOfWork.UnitOfWork>().As<IUnitOfWork>();


            var apiAssembly = Assembly.GetExecutingAssembly();
            var DataAssembly = Assembly.GetAssembly(typeof(ApplicationDbContext));
            var BusinessAssembly = Assembly.GetAssembly(typeof(MapProfile));

            builder.RegisterAssemblyTypes(apiAssembly, DataAssembly, BusinessAssembly).Where(x => x.Name.EndsWith
            ("Repository")).AsImplementedInterfaces().InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(apiAssembly, DataAssembly, BusinessAssembly).Where(x => x.Name.EndsWith
           ("Service")).AsImplementedInterfaces().InstancePerLifetimeScope();

            //InstancePerLifetimeScope => Scope karşılık gelir.
        }
    }
}
