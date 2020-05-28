using Activioo.Infrastructure.Repositories;
using Activioo.Infrastructure.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Activioo.API.IoC
{
  public static class RepositoryInstaller
  {
    public static void InstallRepositories(this IServiceCollection services)
    {
      services.AddScoped<IActivityRepository, ActivityRepository>();
    }
  }
}