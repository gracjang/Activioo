using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Activioo.Domain.Models;

namespace Activioo.Domain.Repositories 
{
  public interface IActivityRepository : IRepository
  {
    Task<IEnumerable<Activity>> GetAllAsync();
    Task<Activity> GetByIdAsync(Guid id);
    Task AddSingleAsync(Activity activity);
    Task AddManyAsync(IEnumerable<Activity> activities);
    Task UpdateAsync(Activity activity);
    Task RemoveAsync(Guid id);
  }
}