using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsPresentation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Device.Location;
using System.Dynamic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;


namespace kyrsovaya
{
    class mapper
    {
        public ListBoxItem lbret(Root infoarr)
        {
            return new ListBoxItem()
            {
                Content = infoarr.Lineup[0],
                ToolTip = markerinfovoid(infoarr.Lineup[0], infoarr.Description, infoarr.Title, infoarr.datetime.ToString())
            };
        }

        public string markerinfovoid (string _1, string _2, string _3, string _4)
        {
            return _1 + "\n" + _2 + "\n" + _3 + "\n" + _4;
        }

        public List<GMapMarker> GetMarkers(List<Root> data)
        {
            var res = new List<GMapMarker>();
            
            foreach (Root infoarr in data)
            {
                if (infoarr.Venue.Latitude == null && infoarr.Venue.Longitude == null)
                    continue;
                string info = markerinfovoid(infoarr.Lineup[0], infoarr.Description, infoarr.Title, infoarr.datetime.ToString());
                float lng = Convert.ToSingle(infoarr.Venue.Longitude, CultureInfo.InvariantCulture);
                float lat = Convert.ToSingle(infoarr.Venue.Latitude, CultureInfo.InvariantCulture);
                var marker = CreatMarker(lat, lng, info);
                res.Add(marker);
            }
            return res;
        }

        GMapMarker CreatMarker(float lat, float lng, string info)
        {
            PointLatLng EventLocation = new PointLatLng(lat, lng);
                return new GMapMarker(EventLocation)
                {
                    Shape = new Image
                    {
                        Width = 40,
                        Height = 40,
                        ToolTip = info,
                        Source = new BitmapImage(new Uri("pack://application:,,,/imag/metka.png"))
                    }
                };
        }
    }
}