using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Activioo.Domain.Models;
using Activioo.Domain.Repositories;
using Activioo.Infrastructure.Commands.Activities;
using Activioo.Infrastructure.Commands.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Activioo.API.Controllers 
{
  [Route("api/[controller]")]
  [ApiController]
  public class ActivityController : Controller
  {

    private readonly ICommandDispatcher _dispatcher;
    private readonly IActivityRepository _activityRepository;
    public ActivityController(ICommandDispatcher dispatcher, IActivityRepository activityRepository)
    {
      _dispatcher = dispatcher;
      _activityRepository = activityRepository;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
      var response = await _activityRepository.GetAllAsync();
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