using Activioo.Infrastructure.IoC.Modules;
using Autofac;
using Microsoft.Extensions.Configuration;

namespace Activioo.Infrastructure.IoC
{
  public class ContainerModule : Module
  {
    private readonly IConfiguration _configuration;

    public ContainerModule(IConfiguration configuration)
    {
      _configuration = configuration;
    }

    protected override void Load(ContainerBuilder builder)
    {
      builder.RegisterModule(new SettingsModule(_configuration));
      builder.RegisterModule<ServiceModule>();
      builder.RegisterModule<RepositoryModule>();
      builder.RegisterModule<CommandModule>();
      builder.RegisterModule<QueryModule>();
      builder.RegisterModule<DataSeederModule>();
    }
  }
}