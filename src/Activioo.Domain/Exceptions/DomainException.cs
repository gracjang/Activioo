using System;

namespace Activioo.Domain.Exceptions
{
  public class DomainException : BaseException
  {
    public DomainException(string errorMessage, object errors = null) 
      : base(errorMessage, errors)
    {
    }

    protected DomainException(string message, params object[] args) 
      : base(message, args)
    {
    }

    protected DomainException(string errorMessage, object errors, string message, params object[] args) 
      : base(errorMessage, errors, message, args)
    {
    }

    protected DomainException(Exception innerException, string message, params object[] args) 
      : base(innerException, message, args)
    {
    }

    protected DomainException(Exception innerException, string errorMessage, object errors, string message, params object[] args) 
      : base(innerException, errorMessage, errors, message, args)
    {
    }
  }
}