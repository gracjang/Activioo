using System;

namespace Activioo.Domain.Models
{
    public class Activity
    {
        public Guid Id { get; protected set; }
        public string Title { get; protected set; }
        public string Description { get; protected set; }
        public string Category  { get; protected set; }
        public DateTime Date { get; protected set; }
        public string City { get; protected set; }
        public string Venue { get; protected set; } 
        public DateTime UpdatedAt { get; protected set; }
        public DateTime CreateAt { get; protected set; }
  }
}