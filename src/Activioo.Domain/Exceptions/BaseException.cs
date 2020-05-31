using System;
using System.Net;

namespace Activioo.Domain.Exceptions
{
  public class BaseException : Exception
  {
    public string ErrorMessage { get; }
    public HttpStatusCode Code { get; }


    public BaseException(HttpStatusCode code, string errorMessage)
    {
      Code = code;
      ErrorMessage = errorMessage;
    }

    protected BaseException(HttpStatusCode code, string errorMessage,string message, params object[] args)
      : base(string.Format(message, args))
    {
      Code = code;
      ErrorMessage = errorMessage;
    }
  }
}