using Activioo.Infrastructure.Commands.Activities;
using FluentValidation;

namespace Activioo.Infrastructure.Validators
{
  public class RemoveActivityCommandValidator : AbstractValidator<RemoveActivityCommand>
  {
    public RemoveActivityCommandValidator()
    {
      RuleFor(x => x.Id).NotEmpty().NotNull();
    }
  }
}