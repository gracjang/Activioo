namespace Activioo.Infrastructure.Mongo.Interfaces
{
    public interface IMongoSettings
    {
      string ConnectionString { get; set; }
      string Database {get; set; }
    }
}