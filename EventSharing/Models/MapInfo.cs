using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using Nancy.Json;

namespace EventSharing.Models
{
    public class MapInfo
    {
        
        public string Name { get; set; }

        

        public static string Serialize(object o)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            return js.Serialize(o);
        }
    }
}
