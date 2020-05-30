using System.Collections.Generic;

namespace Activioo.Infrastructure.Queries.Activity.Models
{
  public class GetActivitiesResponse
  {
    public IEnumerable<DTO.ActivityDto> Activities { get; set; }
  }
}