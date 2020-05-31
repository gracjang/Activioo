using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Activioo.Domain.Repositories;
using Activioo.Infrastructure.Converters.Interfaces;
using Activioo.Infrastructure.Queries.Activity.Interfaces;
using Activioo.Infrastructure.Queries.Activity.Models;
using AutoMapper;

namespace Activioo.Infrastructure.Queries.Activity
{
  public class ActivityQuery : IActivityQuery
  {
    private readonly IActivityRepository _activityRepository;
    private readonly IActivityQueryConverter _activityQueryConverter;
    public ActivityQuery(IActivityRepository activityRepository, IActivityQueryConverter activityQueryConverter)
    {
      _activityRepository = activityRepository;
      _activityQueryConverter = activityQueryConverter;
    }

    public async Task<GetActivitiesResponse> GetActivitiesAsync()
    {
      var activities = await _activityRepository.GetAllAsync();
      return _activityQueryConverter.Convert(activities);
    }

    public async Task<GetActivityResponse> GetActivityAsync(Guid id)
    {
      var activity = await _activityRepository.GetByIdAsync(id);
      return _activityQueryConverter.Convert(activity);
    }
  }
}