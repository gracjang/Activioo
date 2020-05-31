using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Activioo.Domain.Repositories;
using Activioo.Infrastructure.Queries.Activity.DTO;
using Activioo.Infrastructure.Queries.Activity.Interfaces;
using AutoMapper;

namespace Activioo.Infrastructure.Queries.Activity
{
  public class ActivityQuery : IActivityQuery
  {
    private readonly IActivityRepository _activityRepository;
    private readonly IMapper _mapper;
    public ActivityQuery(IActivityRepository activityRepository, IMapper mapper)
    {
      _activityRepository = activityRepository;
      _mapper = mapper;
    }

    public async Task<IEnumerable<ActivityDto>> GetActivitiesAsync()
    {
      var activities = await _activityRepository.GetAllAsync();
      return _mapper.Map<IEnumerable<ActivityDto>>(activities);
    }

    public async Task<ActivityDto> GetActivityAsync(Guid id)
    {
      var activity = await _activityRepository.GetByIdAsync(id);
      return _mapper.Map<ActivityDto>(activity);
    }
  }
}