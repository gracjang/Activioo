using System;
using System.Threading.Tasks;
using Activioo.Domain.Models;
using Activioo.Domain.Repositories;
using Activioo.Infrastructure.Commands.Activities;
using Activioo.Infrastructure.Commands.Core.Interfaces;

namespace Activioo.Infrastructure.Handlers.Activities
{
  public class AddActivityCommandHandler : ICommandHandler<AddActivityCommand>
  {
    private readonly IActivityRepository _activityRepository;

    public AddActivityCommandHandler(IActivityRepository activityRepository)
    {
      _activityRepository = activityRepository;
    }

    public async Task HandleAsync(AddActivityCommand command)
    {
      command.Id = Guid.NewGuid();
      var activity = Activity.Create(command.Title, command.Description, command.Category, command.Date, command.City, command.Venue);

      await _activityRepository.AddSingleAsync(activity);
    }
  }
}