using System;
using System.Threading.Tasks;
using Activioo.Infrastructure.Commands.Activities;
using Activioo.Infrastructure.Commands.Core.Interfaces;
using Activioo.Infrastructure.Services.Interfaces;

namespace Activioo.Infrastructure.Handlers.Activities
{
  public class AddActivityCommandHandler : ICommandHandler<AddActivityCommand>
  {
    private readonly IActivityService _activityService;

    public AddActivityCommandHandler(IActivityService activityService)
    {
      _activityService = activityService;
    }

    public async Task HandleAsync(AddActivityCommand command)
    {
      command.Id = Guid.NewGuid();

      await _activityService.CreateAsync(command.Id, command.Title, command.Description, command.Category, command.Date,
        command.City, command.Venue);
    }
  }
}