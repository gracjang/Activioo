using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Activioo.Infrastructure.Queries.Activity.DTO;

namespace Activioo.Infrastructure.Queries.Activity.Interfaces
{
  public interface IActivityQuery : IQuery
  {
    Task<IEnumerable<ActivityDto>> GetActivitiesAsync();
    Task<ActivityDto> GetActivityAsync(Guid id);
  }
}