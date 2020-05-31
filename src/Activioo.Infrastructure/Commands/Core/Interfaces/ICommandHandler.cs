using System.Threading.Tasks;

namespace Activioo.Infrastructure.Commands.Core.Interfaces
{
  public interface ICommandHandler<T> where T : ICommand
  {
    Task HandleAsync(T command);
  }
}