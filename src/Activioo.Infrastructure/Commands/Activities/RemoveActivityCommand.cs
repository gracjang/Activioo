using System;
using Activioo.Infrastructure.Commands.Core.Interfaces;

namespace Activioo.Infrastructure.Commands.Activities
{
  public class RemoveActivityCommand : ICommand
  {
    public Guid Id { get; set; }
  }
}