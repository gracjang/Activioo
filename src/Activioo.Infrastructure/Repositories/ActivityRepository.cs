using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Activioo.Domain.Models;
using Activioo.Infrastructure.Mongo.Interfaces;
using Activioo.Infrastructure.Repositories.Interfaces;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Activioo.Infrastructure.Repositories 
{
  public class ActivityRepository : IActivityRepository 
  {
    private const string ActivityCollectionName = "Activities";
    private readonly IMongoCollection<Activity> _activities;

    public ActivityRepository(IMongoSettings settings) 
    {
      var client = new MongoClient(settings.ConnectionString);
      var database = client.GetDatabase(settings.Database);

      _activities = database.GetCollection<Activity>(ActivityCollectionName);
    }
    public async Task AddAsync(Activity activity) 
    {
      await _activities.InsertOneAsync(activity);
    }

    public async Task<IEnumerable<Activity>> GetAllAsync() 
      => await _activities.AsQueryable().ToListAsync();


    public async Task<Activity> GetByIdAsync(Guid id)
    {
      return await _activities.AsQueryable().FirstOrDefaultAsync(x => x.Id == id);
    }

    public Task RemoveAsync(Activity activity) {
      throw new NotImplementedException();
    }

    public Task UpdateAsync(Activity activity) {
      throw new NotImplementedException();
    }
  }
}