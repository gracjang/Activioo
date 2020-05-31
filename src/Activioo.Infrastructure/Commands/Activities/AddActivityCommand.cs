using System;
using Activioo.Infrastructure.Commands.Core.Interfaces;

namespace Activioo.Infrastructure.Commands.Activities
{
  public class AddActivityCommand : ICommand
  {
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Category { get; set; }
    public DateTime Date { get; set; }
    public string City { get; set; }
    public string Venue { get; set; }
  }
}
