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

    protected Activity(Guid id, string title, string description, string category, DateTime date, string city, string venue)
    {
      SetId(id);
      SetDescription(description);
      SetTitle(title);
      SetCategory(category);
      SetDate(date);
      SetCity(city);
      SetVenue(venue);
      CreateAt = DateTime.UtcNow;
    }

    public void UpdateActivity(string title, string description, string category, DateTime date, string city, string venue)
    {
      SetDescription(description);
      SetTitle(title);
      SetCategory(category);
      SetDate(date);
      SetCity(city);
      SetVenue(venue);
      UpdatedAt = DateTime.UtcNow;
    }

    public void SetId(Guid id)
    {
      if (id == Guid.Empty)
      {
        throw new DomainException(HttpStatusCode.BadRequest, ErrorMessage.InvalidActivity);
      }

      Id = id;
      UpdatedAt = DateTime.UtcNow;
    }
    public void SetTitle(string title)
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

    public void SetDescription(string description)
    {
      if (string.IsNullOrEmpty(description))
      {
        throw new DomainException(HttpStatusCode.BadRequest, ErrorMessage.InvalidActivity);
      }

      if (description == Description)
      {
        return;
      }

      Description = description;
      UpdatedAt = DateTime.UtcNow;
    }
    public void SetCategory(string category)
    {
      if (string.IsNullOrEmpty(category))
      {
        throw new DomainException(HttpStatusCode.BadRequest, ErrorMessage.InvalidActivity);
      }

      if (category == Category)
      {
        return;
      }

      Category = category;
      UpdatedAt = DateTime.UtcNow;
    }

    public void SetCity(string city)
    {
      if (string.IsNullOrEmpty(city))
      {
        throw new DomainException(HttpStatusCode.BadRequest, ErrorMessage.InvalidActivity);
      }

      if (city == City)
      {
        return;
      }

      City = city;
      UpdatedAt = DateTime.UtcNow;
    }

    public void SetVenue(string venue)
    {
      if (string.IsNullOrEmpty(venue))
      {
        throw new DomainException(HttpStatusCode.BadRequest, ErrorMessage.InvalidActivity);
      }

      if (venue == Venue)
      {
        return;
      }

      Venue = venue;
      UpdatedAt = DateTime.UtcNow;
    }

    public void SetDate(DateTime date)
    {
      if (date == null)
      {
        throw new DomainException(HttpStatusCode.BadRequest, ErrorMessage.InvalidActivity);
      }

      if (date == Date)
      {
        return;
      }

      Date = date;
      UpdatedAt = DateTime.UtcNow;
    }

    public static Activity Create(
      Guid id,
      string title, 
      string description, 
      string category, 
      DateTime date, 
      string city,
      string venue) => new Activity(id, title, description, category, date, city, venue);
  }
}