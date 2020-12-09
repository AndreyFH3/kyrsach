using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsPresentation;
using System.Device.Location;

namespace kyrsovaya
{
    class EventInfo
    {
        public string Mbid { get; set; }

        public string SupportUrl { get; set; }

        public Uri FacebookPageUrl { get; set; }

        public Uri ImageUrl { get; set; }

        public string Name { get; set; }

        public Options Options { get; set; }

        public long TrackerCount { get; set; }

        public long UpcomingEventCount { get; set; }

        public Uri Url { get; set; }
    }
}
