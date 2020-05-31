using System;
using System.Net;
using Activioo.Domain.Consts;
using Activioo.Domain.Exceptions;

namespace Activioo.Domain.Models
{
  public class Activity
  {
    public Guid Id { get; protected set; }
    public string Title { get; protected set; }
    public string Description { get; protected set; }
    public string Category { get; protected set; }
    public DateTime Date { get; protected set; }
    public string City { get; protected set; }
    public string Venue { get; protected set; }
    public DateTime UpdatedAt { get; protected set; }
    public DateTime CreateAt { get; protected set; }

    protected Activity(string title, string description, string category, DateTime date, string city, string venue)
    {
      Id = Guid.Empty;
      SetTitle(title);
    }

    private void SetTitle(string title)
    {
      if(string.IsNullOrEmpty(title))
      {
        throw new DomainException(HttpStatusCode.BadRequest, ErrorMessage.InvalidActivity);
      }

      if(title == Title)
      {
        return;
      }

      Title = title;
      UpdatedAt = DateTime.UtcNow;
    }
  }
}