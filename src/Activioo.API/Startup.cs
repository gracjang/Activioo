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
      services.Configure<MongoSettings>(Configuration.GetSection(nameof(MongoSettings)));
      services.AddSingleton<IMongoSettings>(sp =>
        sp.GetRequiredService<IOptions<MongoSettings>>().Value);
      services.AddScoped<IActivityRepository, ActivityRepository>();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env) 
    {
      if (env.IsDevelopment()) 
      {
        app.UseDeveloperExceptionPage();
      }

      //app.UseHttpsRedirection();

      app.UseRouting();

      app.UseAuthorization();

      app.UseEndpoints(endpoints => {
        endpoints.MapControllers();
      });
    }
  }
}