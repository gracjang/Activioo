using System.Threading.Tasks;
using Activioo.Domain.Repositories;
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
    public ActionResult<string> Get(int id) 
    {
      return "value";
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] AddActivityCommand command)
    {
      await _dispatcher.DispatchAsync(command);

      return Created("api/activity", new object());
    }

    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value) { }

    [HttpDelete("{id}")]
    public void Delete(int id) { }
  }
}