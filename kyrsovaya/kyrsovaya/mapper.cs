using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsPresentation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Device.Location;
using System.Dynamic;
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
        public mapper(GMapControl Map, GMapMarker marker, ListBox OnlineList)
        {
            info = OnlineList;
            this.gMap = Map;
            this.marker = marker;
        }
        GMapControl gMap;
        string markerinfo;
        GMapMarker marker;
        ListBox info;

        public void Chooser(Root infoarr)
        {
            if (infoarr == null) return;
            markerinfovoid(infoarr.Lineup[0], infoarr.Description, infoarr.Title, infoarr.datetime.ToString());
            if (infoarr.Venue.Latitude == null && infoarr.Venue.Longitude == null) return;
            else
            {
                float lng = float.Parse(infoarr.Venue.Longitude.Replace(".", ","));
                float lat = float.Parse(infoarr.Venue.Latitude.Replace(".", ","));
                AddMarker(lat, lng);
            }
        }
        public void lbret(Root infoarr)
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                if (infoarr.Venue.Latitude == null && infoarr.Venue.Longitude == null)
                {
                    markerinfovoid(infoarr.Lineup[0], infoarr.Description, infoarr.Title, infoarr.datetime.ToString());
                    ListBoxItem OnlineEventinfo = new ListBoxItem()
                    {
                        Content = infoarr.Lineup[0],
                        ToolTip = markerinfo
                    };
                    info.Items.Add(OnlineEventinfo);
                }
            });
        }

        public void markerinfovoid(string _1, string _2, string _3, string _4)
        {
            markerinfo = _1 + "\n" + _2 + "\n" + _3 + "\n" + _4;
        }

        void AddMarker(float lat, float lng)
        {
            PointLatLng EventLocation = new PointLatLng(lat, lng);
            Application.Current.Dispatcher.Invoke(() =>
            {
                marker = new GMapMarker(EventLocation)
                {
                    Shape = new Image
                    {
                        Width = 32,
                        Height = 32,
                        ToolTip = markerinfo,
                        Source = new BitmapImage(new Uri("pack://application:,,,/imag/metka.png"))
                    }
                };
                gMap.Markers.Add(marker);
            });
        }
    }
}