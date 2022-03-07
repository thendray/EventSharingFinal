using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventSharing.Models
{
    public class Event
    {
        public int EventId { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public double DurationHour { get; set; }
        public string EventType { get; set; }
        public string ImageUrl { get; set; }
        public string Adress { get; set; }
        public double Coordinates { get; set; }
        public string SiteUrl { get; set; }

    }
}
