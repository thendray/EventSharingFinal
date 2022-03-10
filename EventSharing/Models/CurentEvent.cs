using EventSharing.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventSharing.Models
{
    public class CurentEvent
    {
        // public static int CurentEventId = 0;
        public static IQueryable<Event> FindEvents { get; set; }

        public static List<string> Names { get; set; }
        public static List<string> Adresses { get; set; }
        public static List<string> StartsTime  { get; set; }
        public static List<string> HourDurations { get; set; }
        public static List<string> Informations { get; set; }

        public static bool EventsInBase(MapInfo map, MyAppDbContext db)
        {
            
            var events = db.Events.Where(x => (x.Name.Contains(map.Name) || map.Name.Contains(x.Name)));
            if (events.Count() > 0)
            {
                FindEvents = events;
                return true;
            }
            return false;
        }

    }
}
