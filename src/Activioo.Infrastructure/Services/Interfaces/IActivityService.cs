using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Activioo.Infrastructure.Queries.Activity.DTO;

namespace Activioo.Infrastructure.Services.Interfaces
{
  public interface IActivityService : IService
  {
    Task CreateAsync(Guid activityId, string title, string description, string category, DateTime date, string city, string venue);
    Task UpdateAsync(Guid activityId, string title, string description, string category, DateTime date, string city, string venue);
    Task RemoveAsync(Guid activityId);
    Task<ActivityDto> GetAsync(Guid activityId);
    Task<IEnumerable<ActivityDto>>GetAllAsync();
  }
}