using System.Reflection;
using Activioo.Infrastructure.Commands.Core;
using Activioo.Infrastructure.Commands.Core.Interfaces;
using Autofac;
using Module = Autofac.Module;

namespace Activioo.Infrastructure.IoC.Modules
{
  public class CommandModule : Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      var assembly = typeof(CommandModule).GetTypeInfo().Assembly;

      builder.RegisterAssemblyTypes(assembly)
        .AsClosedTypesOf(typeof(ICommandHandler<>))
        .InstancePerLifetimeScope();

      builder.RegisterType<CommandDispatcher>()
        .As<ICommandDispatcher>()
        .InstancePerLifetimeScope();
    }
  }
}