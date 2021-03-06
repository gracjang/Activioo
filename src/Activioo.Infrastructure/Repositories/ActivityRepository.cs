using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Activioo.Domain.Models;
using Activioo.Domain.Repositories;
using Activioo.Infrastructure.Mongo.Interfaces;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Activioo.Infrastructure.Repositories 
{
  public class ActivityRepository : IActivityRepository 
  {
    private const string ActivityCollectionName = "Activities";

    private readonly IMongoCollection<Activity> _activities;

    public ActivityRepository(IMongoDatabase database)
    {
      _activities = database.GetCollection<Activity>(ActivityCollectionName);
    }

    public async Task<IEnumerable<Activity>> GetAllAsync() 
      => await _activities.AsQueryable().ToListAsync();

    public async Task<Activity> GetByIdAsync(Guid id) 
      => await _activities.AsQueryable().FirstOrDefaultAsync(x => x.Id == id);

    public async Task AddSingleAsync(Activity activity)
     => await _activities.InsertOneAsync(activity);

    public async Task AddManyAsync(IEnumerable<Activity> activities)
      => await _activities.InsertManyAsync(activities);

    public async Task RemoveAsync(Guid id)
      => await _activities.DeleteOneAsync(x => x.Id == id);

    public async Task UpdateAsync(Activity activity)
      => await _activities.ReplaceOneAsync(x => x.Id == activity.Id, activity);


  }
}