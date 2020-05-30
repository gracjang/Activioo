using System.Collections.Generic;
using Activioo.Domain.Models;
using Activioo.Infrastructure.Converters.Interfaces;
using Activioo.Infrastructure.Queries.Activity.DTO;
using Activioo.Infrastructure.Queries.Activity.Models;
using AutoMapper;

namespace Activioo.Infrastructure.Converters
{
  public class GetActivitiesResponseConverter : IGetActivitiesResponseConverter
  {
    private readonly IMapper _mapper;

    public GetActivitiesResponseConverter()
    {
      var config = new MapperConfiguration(cfg =>
      {
        cfg.CreateMap<Activity,ActivityDto>();
      });

      config.AssertConfigurationIsValid();
      _mapper = config.CreateMapper();
    }

    public GetActivitiesResponse Convert(IEnumerable<Activity> activities)
    {
      return new GetActivitiesResponse
      {
        Activities = _mapper.Map<IEnumerable<ActivityDto>>(activities)
      };
    }
  }
}