using Activioo.Infrastructure.Commands.Activities;
using FluentValidation;

namespace Activioo.Infrastructure.Validators
{
  public class UpdatedActivityCommandValidator : AbstractValidator<UpdateActivityCommand>
  {
    public UpdatedActivityCommandValidator()
    {
      RuleFor(x => x.Category).NotEmpty().NotNull();
      RuleFor(x => x.City).NotEmpty().NotNull();
      RuleFor(x => x.Date).NotEmpty();
      RuleFor(x => x.Description).NotEmpty().NotNull();
      RuleFor(x => x.Title).NotEmpty().NotNull();
      RuleFor(x => x.Venue).NotEmpty().NotNull();
    }
  }
}