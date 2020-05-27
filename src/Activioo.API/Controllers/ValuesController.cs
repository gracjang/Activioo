using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Activioo.Domain.Models;
using Activioo.Infrastructure.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Activioo.API.Controllers 
{
  [Route("api/[controller]")]
  [ApiController]
  public class ActivityController : Controller 
  {

    private readonly IActivityRepository _repo;
    public ActivityController(IActivityRepository repo) 
    {
      _repo = repo;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
      var activities = await _repo.GetAllAsync();
      return Json(activities);
    }

    [HttpGet("{id}")]
    public ActionResult<string> Get(int id) 
    {
      return "value";
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Activity activity)
    {
      await _repo.AddAsync(activity);

      return Created("api/activity", new object());
    }

    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value) { }

    [HttpDelete("{id}")]
    public void Delete(int id) { }
  }
}