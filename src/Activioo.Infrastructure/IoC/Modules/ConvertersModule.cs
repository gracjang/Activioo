using Activioo.Infrastructure.Converters;
using Activioo.Infrastructure.Converters.Interfaces;
using Autofac;

namespace Activioo.Infrastructure.IoC.Modules
{
  public class ConvertersModule : Autofac.Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      builder.RegisterType<ActivityQueryConverter>()
        .As<IActivityQueryConverter>()
        .InstancePerLifetimeScope();
    }
  }
}