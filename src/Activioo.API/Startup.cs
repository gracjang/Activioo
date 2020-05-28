using System;
using Activioo.API.IoC;
using Activioo.Infrastructure.Migration;
using Activioo.Infrastructure.Mongo;
using Activioo.Infrastructure.Mongo.Interfaces;
using Activioo.Infrastructure.Repositories;
using Activioo.Infrastructure.Repositories.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace Activioo.API 
{
  public class Startup 
  {
    public Startup(IConfiguration configuration) {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services) 
    {
      services.AddControllers().AddJsonOptions(options => { options.JsonSerializerOptions.WriteIndented = true; });
      services.InstallSettings(Configuration);
      services.InstallRepositories();
      services.AddScoped<IDataSeeder, DataSeeder>();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider provider) 
    {
      if (env.IsDevelopment()) 
      {
        app.UseDeveloperExceptionPage();
      }

      //app.UseHttpsRedirection();
      if(bool.Parse(Configuration.GetSection("SeedData").Value))
      {
        var dataSeeder = provider.GetService<IDataSeeder>();
        dataSeeder.SeedData();
      }
      
      app.UseRouting();

      app.UseAuthorization();

      app.UseEndpoints(endpoints => {
        endpoints.MapControllers();
      });
    }
  }
}