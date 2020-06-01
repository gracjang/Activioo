using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Activioo.Domain.Repositories;
using Activioo.Infrastructure.Queries.Activity.DTO;
using Activioo.Infrastructure.Queries.Activity.Interfaces;
using Activioo.Infrastructure.Services.Interfaces;
using AutoMapper;

namespace Activioo.Infrastructure.Queries.Activity
{
  public class ActivityQuery : IActivityQuery
  {
    private readonly IActivityService _activityService;
    public ActivityQuery(IActivityService activityService)
    {
      _activityService = activityService;
    }

    public async Task<IEnumerable<ActivityDto>> GetActivitiesAsync()
    {
      return await _activityService.GetAllAsync();
    }

    public async Task<ActivityDto> GetActivityAsync(Guid id)
    {
      return await _activityService.GetAsync(id);
    }
  }
}