using System.Net;
using Activioo.Domain.Exceptions;

namespace Activioo.Infrastructure.Exceptions
{
  public class InfrastructureException : BaseException
  {
    public InfrastructureException(HttpStatusCode code, string errorMessage) 
      : base(code, errorMessage)
    {
    }

    public InfrastructureException(HttpStatusCode code, string errorMessage, string message, params object[] args) 
      : base(code, errorMessage, message, args)
    {
    }
  }
}