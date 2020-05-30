using System.Threading.Tasks;

namespace Activioo.Infrastructure.Commands.Core.Interfaces
{
  public interface ICommandDispatcher
  {
    Task DispatchAsync<T>(T command) where T : ICommand;
  }
}