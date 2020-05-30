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
    private readonly IGetActivitiesResponseConverter _getActivitiesResponseConverter;
    public ActivityQuery(IActivityRepository activityRepository, IGetActivitiesResponseConverter getActivitiesResponseConverter)
    {
      _activityRepository = activityRepository;
      _getActivitiesResponseConverter = getActivitiesResponseConverter;
    }

    public async Task<GetActivitiesResponse> GetActivitiesAsync()
    {
      var activities = await _activityRepository.GetAllAsync();
      return _getActivitiesResponseConverter.Convert(activities);
    }
  }
}