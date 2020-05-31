using Activioo.Domain.Models;
using Activioo.Infrastructure.Queries.Activity.DTO;
using AutoMapper;

namespace Activioo.Infrastructure.AutoMapper
{
  public class ActivityProfile : Profile
  {
    public ActivityProfile()
    {
      CreateMap<Activity, ActivityDto>();
    }
  }
}