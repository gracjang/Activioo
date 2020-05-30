using System;
using System.Text.Encodings.Web;
using Activioo.Infrastructure.IoC;
using Activioo.Infrastructure.Migration;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Activioo.API
{
  public class Startup
  {
    public IConfiguration Configuration { get; }

    public ILifetimeScope AutofacContainer { get; private set; }

    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
      services.AddControllers().AddJsonOptions(options =>
      {
        options.JsonSerializerOptions.WriteIndented = true;
        options.JsonSerializerOptions.Encoder = JavaScriptEncoder.Create(System.Text.Unicode.UnicodeRanges.All);
      });
    }

    public void ConfigureContainer(ContainerBuilder builder)
    {
      builder.RegisterModule(new ContainerModule(Configuration));
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider provider)
    {
      AutofacContainer = app.ApplicationServices.GetAutofacRoot();

      if(env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      if(bool.Parse(Configuration.GetSection("SeedData").Value))
      {
        var dataSeeder = app.ApplicationServices.GetService<IDataSeeder>();
        dataSeeder.SeedData();
      }

      app.UseRouting();

      app.UseAuthorization();

      app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
    }
  }
}