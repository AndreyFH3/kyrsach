using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsPresentation;
using System.Device.Location;

namespace kyrsovaya
{    
    public partial class SecondPage : UserControl
    {
        public SecondPage()
        {
            InitializeComponent();
        }
        List<Root> infoarr = new List<Root>();
        GMapMarker marker;

        private void MapLoaded(object sender, RoutedEventArgs e)
        {
            GMaps.Instance.Mode = AccessMode.ServerAndCache;

            Map.MapProvider = YandexMapProvider.Instance;

            Map.MinZoom = 2;
            Map.MaxZoom = 17;
            Map.Zoom = 15;
            Map.Position = new PointLatLng(55.012823, 82.950359);
            Map.MouseWheelZoomType = MouseWheelZoomType.MousePositionAndCenter;
            Map.CanDragMap = true;
            Map.DragButton = MouseButton.Left;
        }

        bit ch = new bit();

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            infoarr = ch.LoadEventInfo(Search.Text);

            Map.Markers.Clear();

            float lat;
            float lng;

            for (int i = 0; i < infoarr.Count();i++) 
            {
                //string str1 = infoarr[i].Venue.Latitude;
                //string str2 = infoarr[i].Venue.Longitude;
                if (infoarr[i].Venue.Latitude==null)
                    lat = 0;
                else
                    lat = float.Parse(infoarr[i].Venue.Latitude.Replace(".", ","));
                if (infoarr[i].Venue.Longitude==null)
                    lng = 0;
                else
                    lng = float.Parse(infoarr[i].Venue.Longitude.Replace(".", ","));

                string markerinfo = infoarr[i].Lineup[0] + "\n" + infoarr[i].Description + "\n" + infoarr[i].Title + "\n" + infoarr[i].datetime;
                AddMarker(lat, lng, markerinfo);
            }

        }
        void AddMarker(float lat, float lng, string tooltip)
        {
            PointLatLng EventLocation = new PointLatLng(lat, lng);
            marker = new GMapMarker(EventLocation)
            {
                Shape = new Image
                {
                    Width = 32,
                    Height = 32,
                    ToolTip = tooltip,
                    Source = new BitmapImage(new Uri("pack://application:,,,/imag/metka.png"))
                }
            };
            Map.Markers.Add(marker);
        }
    }
}
