using System.Collections.Generic;
using Activioo.Domain.Models;
using Activioo.Infrastructure.Queries.Activity.Models;

namespace Activioo.Infrastructure.Converters.Interfaces
{
  public interface IGetActivitiesResponseConverter
  {
    GetActivitiesResponse Convert(IEnumerable<Activity> activities);
  }
}