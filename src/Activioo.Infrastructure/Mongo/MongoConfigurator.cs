using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Conventions;

namespace Activioo.Infrastructure.Mongo
{
  public class MongoConfigurator
  {
    private static bool _initialized;

    public static void Initialize()
    {
      if (_initialized)
      {
        return;
      }

      RegisterConventions();
    }

    private static void RegisterConventions()
    {
      ConventionRegistry.Register("ActiviooConventions", new MongoConvention(), x => true);
      _initialized = true;
    }

    private class MongoConvention : IConventionPack
    {
      public IEnumerable<IConvention> Conventions => new List<IConvention>()
      {
        new IgnoreExtraElementsConvention(true),
        new CamelCaseElementNameConvention(),
        new EnumRepresentationConvention(BsonType.String),
      };
    }
  }
}