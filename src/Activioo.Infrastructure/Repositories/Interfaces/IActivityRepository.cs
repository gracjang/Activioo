using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Activioo.Domain.Models;

namespace Activioo.Infrastructure.Repositories.Interfaces 
{
  public interface IActivityRepository : IRepository 
  {
    Task<IEnumerable<Activity>> GetAllAsync();
    Task<Activity> GetByIdAsync(Guid id);
    Task AddAsync(Activity activity);
    Task UpdateAsync(Activity activity);
    Task RemoveAsync(Activity activity);
  }
}