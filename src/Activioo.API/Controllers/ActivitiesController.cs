using System;
using System.Net;
using System.Threading.Tasks;
using Activioo.Infrastructure.Commands.Activities;
using Activioo.Infrastructure.Commands.Core.Interfaces;
using Activioo.Infrastructure.Queries.Activity.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Activioo.API.Controllers 
{
  [Route("api/[controller]")]
  [ApiController]
  public class ActivitiesController : Controller
  {

    private readonly ICommandDispatcher _dispatcher;
    private readonly IActivityQuery _activityQuery;
    public ActivitiesController(ICommandDispatcher dispatcher,
      IActivityQuery activityQuery)
    {
      _dispatcher = dispatcher;
      _activityQuery = activityQuery;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
      var response = await _activityQuery.GetActivitiesAsync();
      return Json(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
      var response = await _activityQuery.GetActivityAsync(id);

      return Json(response);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] AddActivityCommand command)
    {
      await _dispatcher.DispatchAsync(command);

      return Created("api/activity", new object());
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(Guid id, [FromBody] UpdateActivityCommand command)
    {
      command.Id = id;
      await _dispatcher.DispatchAsync(command);

      return Json(HttpStatusCode.OK);
    }

    [HttpDelete("{id}")]
    public void Delete(int id) { }
  }
}