using System;
using System.Net;

namespace Activioo.Domain.Exceptions
{
  public class BaseException : Exception
  {
    public string ErrorMessage { get; }
    public object Errors { get; }


    public BaseException(string errorMessage, object errors = null)
    {
      ErrorMessage = errorMessage;
      Errors = errors;
    }

    protected BaseException(string message, params object[] args) : this(string.Empty, null, message, args)
    {
    }

    protected BaseException(string errorMessage, object errors, string message, params object[] args)
      : this(null, errorMessage, errors, message, args)
    {
    }

    protected BaseException(Exception innerException, string message, params object[] args) 
      : this(innerException, string.Empty, null, message,args)
    {

    }

    protected BaseException(Exception innerException, string errorMessage, object errors, string message, params object[] args)
      : base(string.Format(message, args), innerException)
    {
      ErrorMessage = errorMessage;
      Errors = errors;
    }
  }
}