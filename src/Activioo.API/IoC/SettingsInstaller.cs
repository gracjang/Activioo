using Activioo.Infrastructure.Mongo;
using Activioo.Infrastructure.Mongo.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Activioo.API.IoC
{
  public static class SettingsInstaller
  {
    public static void InstallSettings(this IServiceCollection services, IConfiguration configuration)
    {
      services.Configure<MongoSettings>(configuration.GetSection(nameof(MongoSettings)));
      services.AddSingleton<IMongoSettings>(sp =>
        sp.GetRequiredService<IOptions<MongoSettings>>().Value);
    }
  }
}