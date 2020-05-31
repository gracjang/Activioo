using System;
using System.Threading.Tasks;
using Activioo.Infrastructure.Queries.Activity.Models;

namespace Activioo.Infrastructure.Queries.Activity.Interfaces
{
  public interface IActivityQuery : IQuery
  {
    Task<GetActivitiesResponse> GetActivitiesAsync();
    Task<GetActivityResponse> GetActivityAsync(Guid id);
  }
}