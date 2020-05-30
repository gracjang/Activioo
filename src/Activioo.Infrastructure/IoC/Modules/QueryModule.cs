using Autofac;
using System.Reflection;
using Activioo.Infrastructure.Queries.Activity.Interfaces;

namespace Activioo.Infrastructure.IoC.Modules
{
  public class QueryModule : Autofac.Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      var assembly = typeof(QueryModule).GetTypeInfo().Assembly;

      builder.RegisterAssemblyTypes(assembly)
        .Where(x => x.IsAssignableTo<IQuery>())
        .AsImplementedInterfaces()
        .InstancePerLifetimeScope();
    }
  }
}