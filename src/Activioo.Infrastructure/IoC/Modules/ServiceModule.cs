using System.Reflection;
using Activioo.Infrastructure.Services.Interfaces;
using Autofac;

namespace Activioo.Infrastructure.IoC.Modules
{
  class ServiceModule : Autofac.Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      var assembly = typeof(ServiceModule).GetTypeInfo().Assembly;

      builder.RegisterAssemblyTypes(assembly)
        .Where(x => x.IsAssignableTo<IService>())
        .AsImplementedInterfaces()
        .InstancePerLifetimeScope();
    }
  }
}
