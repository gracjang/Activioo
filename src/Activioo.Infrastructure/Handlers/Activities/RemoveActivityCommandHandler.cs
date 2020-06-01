using System.Threading.Tasks;
using Activioo.Infrastructure.Commands.Activities;
using Activioo.Infrastructure.Commands.Core.Interfaces;
using Activioo.Infrastructure.Services.Interfaces;

namespace Activioo.Infrastructure.Handlers.Activities
{
  public class RemoveActivityCommandHandler : ICommandHandler<RemoveActivityCommand>
  {
    private readonly IActivityService _activityService;

    public RemoveActivityCommandHandler(IActivityService activityService)
    {
      _activityService = activityService;
    }

    public async Task HandleAsync(RemoveActivityCommand command)
    {
      await _activityService.RemoveAsync(command.Id);
    }
  }
}