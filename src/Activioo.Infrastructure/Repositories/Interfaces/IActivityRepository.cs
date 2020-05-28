using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Activioo.Domain.Models;

namespace Activioo.Infrastructure.Repositories.Interfaces 
{
  public interface IActivityRepository
  {
    Task<IEnumerable<Activity>> GetAllAsync();
    Task<Activity> GetByIdAsync(Guid id);
    Task AddSingleAsync(Activity activity);
    Task AddManyAsync(IEnumerable<Activity> activities);
    Task UpdateAsync(Activity activity);
    Task RemoveAsync(Activity activity);
  }
}