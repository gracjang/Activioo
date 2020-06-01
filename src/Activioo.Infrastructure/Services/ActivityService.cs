using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Activioo.Domain.Models;
using Activioo.Domain.Repositories;
using Activioo.Infrastructure.Exceptions;
using Activioo.Infrastructure.Queries.Activity.DTO;
using Activioo.Infrastructure.Services.Interfaces;
using AutoMapper;

namespace Activioo.Infrastructure.Services
{
  public class ActivityService : IActivityService
  {
    private readonly IActivityRepository _activityRepository;
    private readonly IMapper _mapper;

    public ActivityService(IActivityRepository activityRepository, IMapper mapper)
    {
      _activityRepository = activityRepository;
      _mapper = mapper;
    }

    public async Task CreateAsync(Guid id, string title, string description, string category, DateTime date, string city, string venue)
    {
      var activity = await _activityRepository.GetByIdAsync(id);

      if(activity != null)
      {
        throw new InfrastructureException(HttpStatusCode.Conflict, ErrorMessage.ActivityAlreadyExists);
      }

      activity = Activity.Create(id, title, description, category, date, city, venue);

      await _activityRepository.AddSingleAsync(activity);
    }

    public async Task UpdateAsync(Guid activityId, string title, string description, string category, DateTime date, string city, string venue)
    {
      var activity = await _activityRepository.GetByIdAsync(activityId);

      if (activity == null)
      {
        throw new InfrastructureException(HttpStatusCode.BadRequest, ErrorMessage.ActivityNotFound);
      }
      
      activity.UpdateActivity(title, description, category, date, city, venue);
      await _activityRepository.UpdateAsync(activity);
    }

    public async Task RemoveAsync(Guid activityId)
    {
      var activity = await _activityRepository.GetByIdAsync(activityId);

      if (activity == null)
      {
        throw new InfrastructureException(HttpStatusCode.BadRequest, ErrorMessage.ActivityNotFound);
      }
      
      await _activityRepository.RemoveAsync(activityId);
    }

    public async Task<ActivityDto> GetAsync(Guid activityId)
    {
      var activity = await _activityRepository.GetByIdAsync(activityId);

      if (activity == null)
      {
        throw new InfrastructureException(HttpStatusCode.BadRequest, ErrorMessage.ActivityNotFound);
      }

      return _mapper.Map<ActivityDto>(activity);
    }

    public async Task<IEnumerable<ActivityDto>> GetAllAsync()
    {
      var activities = await _activityRepository.GetAllAsync();

      if (activities == null)
      {
        throw new InfrastructureException(HttpStatusCode.BadRequest, ErrorMessage.ActivitiesNotFound);
      }

      return _mapper.Map<IEnumerable<ActivityDto>>(activities);
    }
  }
}