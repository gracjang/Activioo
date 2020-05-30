using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Activioo.Domain.Models;
using Activioo.Domain.Repositories;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Activioo.Infrastructure.Migration
{
  public class DataSeeder : IDataSeeder
  {
    private const string Path = "D:\\repos\\Activioo\\src\\Activioo.Infrastructure\\Migration\\MOCK_DATA.json";
    private readonly IActivityRepository _activityRepository;

    public DataSeeder(IActivityRepository activityRepository)
    {
      _activityRepository = activityRepository;
    }

    public async Task SeedData()
    {
      try
      {
        var activitiesData = File.ReadAllText(Path);
        var activities = JsonConvert.DeserializeObject<List<Activity>>(activitiesData,
          new IsoDateTimeConverter {DateTimeFormat = "yyyy-mm-dd"});

        await _activityRepository.AddManyAsync(activities);
      }
      catch (Exception e)
      {
        Console.WriteLine(e);
      }
    }
  }
}