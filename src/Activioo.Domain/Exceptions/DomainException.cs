using System;
using System.Net;

namespace Activioo.Domain.Exceptions
{
  public class DomainException : BaseException
  {
    public DomainException(HttpStatusCode code, string errorMessage) 
      : base(code, errorMessage)
    {
    }

    public DomainException(HttpStatusCode code, string errorMessage, string message, params object[] args) 
      : base(code, errorMessage, message, args)
    {
    }
  }
}