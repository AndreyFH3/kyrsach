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
using System.Threading;

namespace kyrsovaya
{
    public partial class SecondPage : UserControl
    {
        public string[] names { get; set; }
        public SecondPage()
        {
            InitializeComponent();

            names = new string[] { "United States", "Estonia", "Germany", "Czechia", "United Kingdom", "Australia" };

            DataContext = this;

        }

        List<Root> infoarr = new List<Root>();
        List<string> ArtistList = new List<string>() { "Grandson", "Gorilazz", "Scorpions", "Би 2", "Justin Bieber", "Death Angel", "Tech N9ne", "Wiz Khalifa", "G-Eazy", "Diplo", "Major Lazer", "Jojo", "Avatar", "Lauv", "Black Pink", "Popa Chubby", "Primus", "Kb", "Default", "Tennis", "Emery", "CKY" };

        public GMapMarker marker;

        bit ch = new bit();
        mapper MapElements = null;

        private void MapLoaded(object sender, RoutedEventArgs e)
        {
            GMaps.Instance.Mode = AccessMode.ServerAndCache;

            Map.MapProvider = YandexMapProvider.Instance;

            Map.MinZoom = 2;
            Map.MaxZoom = 17;
            Map.Zoom = 1;
            Map.Position = new PointLatLng(55.012823, 82.950359);
            Map.MouseWheelZoomType = MouseWheelZoomType.MousePositionAndCenter;
            Map.CanDragMap = true;
            Map.DragButton = MouseButton.Left;
            MapElements = new mapper(Map, marker, OnlineList);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            Map.Markers.Clear();
            string find = Search.Text;
            OnlineList.Items.Clear();
            new Thread(() =>
            {
                infoarr = ch.LoadEventInfo(find);
                for (int i = 0; i < infoarr.Count; i++)
                {
                    MapElements.Chooser(infoarr[i]);
                    MapElements.lbret(infoarr[i]);
                }
            }).Start();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            OnlineList.Items.Clear();
            Map.Markers.Clear();
            string str = CityList.Text.ToString();
            new Thread(() =>
            {
                for (int i = 0; i < ArtistList.Count; i++)
                {
                    infoarr = ch.LoadEventInfo(ArtistList[i]);
                    for (int j = 0; j < infoarr.Count; j++)
                        if (str == infoarr[j].Venue.Country)
                            MapElements.Chooser(infoarr[j]);
                }
            }).Start();
        }

        private void btnDateSort_Click(object sender, RoutedEventArgs e)
        {
            OnlineList.Items.Clear();
            Map.Markers.Clear();
            DateTime From = dt1.SelectedDate.Value;
            DateTime To = dt2.SelectedDate.Value;
            new Thread(() =>
            {
                for (int i = 0; i < ArtistList.Count; i++)
                {
                    infoarr = ch.LoadEventInfo(ArtistList[i]);
                    for (int j = 0; j < infoarr.Count; j++)
                        if (From <= infoarr[j].datetime.DateTime && infoarr[j].datetime.DateTime <= To)
                        {
                            MapElements.Chooser(infoarr[j]);
                            MapElements.lbret(infoarr[j]);
                        }
                }
            }).Start();

        }
        private void DateSort(object sender, RoutedEventArgs e)
        {
            CityList.Margin = new Thickness(1000, 40, 0, 0);
            btnCountry.Margin = new Thickness(1000, 40, 0, 0);

            OnlineList.Margin = new Thickness(509, 160, 0, 0);
            btnArtist.Margin = new Thickness(1000, 40, 0, 0);
            Search.Margin = new Thickness(1000, 40, 0, 0);


            btnDateSort.Margin = new Thickness(0, 0, 10, 287);
            dt1.Margin = new Thickness(0, 76, 70, 0);
            dt2.Margin = new Thickness(0, 101, 70, 0);
        }

        private void CountrySort(object sender, RoutedEventArgs e)
        {
            CityList.Margin = new Thickness(538, 88, 10, 0);
            btnCountry.Margin = new Thickness(500, 125, 0, 0);

            OnlineList.Margin = new Thickness(1000, 40, 0, 0);
            btnArtist.Margin = new Thickness(1000, 40, 0, 0);
            Search.Margin = new Thickness(1000, 40, 0, 0);

            btnDateSort.Margin = new Thickness(0, 0, 10.4, 9.6);
            dt1.Margin = new Thickness(1100, 0, 0, 0);
            dt2.Margin = new Thickness(1100, 0, 0, 0);
        }

        private void ArtistAFind(object sender, RoutedEventArgs e)
        {
            CityList.Margin = new Thickness(1000, 40, 0, 0);
            btnCountry.Margin = new Thickness(1000, 40, 0, 0);

            OnlineList.Margin = new Thickness(508, 160, 0, 0);
            btnArtist.Margin = new Thickness(0, 121, 10, 295);
            Search.Margin = new Thickness(508, 78, 0, 0);


            btnDateSort.Margin = new Thickness(1000, 40, 0, 0);
            dt1.Margin = new Thickness(1100, 0, 0, 0);
            dt2.Margin = new Thickness(1100, 0, 0, 0);
        }
    }
}
