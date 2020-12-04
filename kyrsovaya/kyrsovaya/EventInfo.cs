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
        public DateTime EventTinme { get; set; }

        public PointLatLng EventPlace { get; set; }

        public string EventName { get; set; }

        public string EventInform {get; set;}

    }
}
