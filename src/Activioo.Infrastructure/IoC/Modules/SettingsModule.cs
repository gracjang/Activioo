using Activioo.Infrastructure.Extensions;
using Activioo.Infrastructure.Mongo;
using Activioo.Infrastructure.Mongo.Interfaces;
using Autofac;
using Microsoft.Extensions.Configuration;

namespace Activioo.Infrastructure.IoC.Modules
{
  public class SettingsModule : Module
  {
    private readonly IConfiguration _configuration;

    public SettingsModule(IConfiguration configuration)
    {
      _configuration = configuration;
    }

    protected override void Load(ContainerBuilder builder)
    {
      builder.RegisterInstance(_configuration.GetSettings<MongoSettings>())
        .As<IMongoSettings>()
        .SingleInstance();
    }
  }
}