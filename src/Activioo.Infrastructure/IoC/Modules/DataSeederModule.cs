using Autofac;
using Activioo.Infrastructure.Migration;

namespace Activioo.Infrastructure.IoC.Modules
{
  public class DataSeederModule : Autofac.Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      builder.RegisterType<DataSeeder>()
        .As<DataSeeder>()
        .InstancePerLifetimeScope();
    }
  }
}