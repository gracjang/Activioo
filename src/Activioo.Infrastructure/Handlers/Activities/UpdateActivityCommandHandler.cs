using System.Threading.Tasks;
using Activioo.Domain.Repositories;
using Activioo.Infrastructure.Commands.Activities;
using Activioo.Infrastructure.Commands.Core.Interfaces;
using Activioo.Infrastructure.Services.Interfaces;

namespace Activioo.Infrastructure.Handlers.Activities
{
  public class UpdateActivityCommandHandler : ICommandHandler<UpdateActivityCommand>
  {
    private readonly IActivityService _activityService;

    public UpdateActivityCommandHandler(IActivityService activityService)
    {
      _activityService = activityService;
    }

    public async Task HandleAsync(UpdateActivityCommand command)
    {
      await _activityService.UpdateAsync(command.Id, command.Title, command.Description, command.Category, command.Date,
        command.City, command.Venue);
    }
  }
}