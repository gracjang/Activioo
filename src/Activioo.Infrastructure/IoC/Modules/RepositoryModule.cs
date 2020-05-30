using System.Reflection;
using Activioo.Domain.Repositories;
using Activioo.Infrastructure.Mongo.Interfaces;
using Autofac;
using MongoDB.Driver;
using Module = Autofac.Module;

namespace Activioo.Infrastructure.IoC.Modules
{
  public class RepositoryModule : Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      builder.Register(x =>
      {
        var settings = x.Resolve<IMongoSettings>();
        return new MongoClient(settings.ConnectionString);
      }).SingleInstance();

      builder.Register(x =>
      {
        var client = x.Resolve<MongoClient>();
        var setting = x.Resolve<IMongoSettings>();
        var database = client.GetDatabase(setting.Database);

        return database;
      }).As<IMongoDatabase>();

      var assembly = typeof(RepositoryModule).GetTypeInfo().Assembly;

      builder.RegisterAssemblyTypes(assembly)
        .Where(x => x.IsAssignableTo<IRepository>())
        .AsImplementedInterfaces()
        .InstancePerLifetimeScope();
    }
  }
}