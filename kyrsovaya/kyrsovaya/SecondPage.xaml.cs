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

            names = new string[] {"United States","Estonia", "Germany", "Czechia", "United Kingdom", "Australia"};

            DataContext = this;
        }
        List<Root> infoarr = new List<Root>();
        List<string> ArtistList = new List<string>()  { "Grandson", "Gorilazz", "Scorpions", "Би 2", "Justin Bieber", "Death Angel", "Tech N9ne", "Wiz Khalifa", "G-Eazy", "Diplo", "Major Lazer", "Jojo", "Avatar", "Lauv", "Black Pink", "Popa Chubby", "Primus", "Kb", "Default", "Tennis", "Emery", "CKY"};
        GMapMarker marker;
        float lat;
        float lng;

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
        }

        bit ch = new bit();

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            Map.Markers.Clear();
            string find = Search.Text;
            OnlineList.Items.Clear();
            new Thread(() => 
            {
                infoarr = ch.LoadEventInfo(find);
                for (int i = 0; i < infoarr.Count(); i++)
                {
                    string markerinfo = infoarr[i].Lineup[0] + "\n" + infoarr[i].Description + "\n" + infoarr[i].Title + "\n" + infoarr[i].datetime;
                    if (infoarr[i].Venue.Latitude == null && infoarr[i].Venue.Longitude == null)
                    {
                        Application.Current.Dispatcher.Invoke(() =>
                        {
                            ListBoxItem OnlineEventinfo = new ListBoxItem()
                            {
                                Content = infoarr[i].Lineup[0],
                                ToolTip = markerinfo
                            };
                            OnlineList.Items.Add(OnlineEventinfo);
                        });
                    }
                    else
                    {
                        lng = float.Parse(infoarr[i].Venue.Longitude.Replace(".", ","));
                        lat = float.Parse(infoarr[i].Venue.Latitude.Replace(".", ","));
                        AddMarker(lat, lng, markerinfo);
                    }
                }
            }).Start();

            
        }
        void AddMarker(float lat, float lng, string tooltip)
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
                        ToolTip = tooltip,
                        Source = new BitmapImage(new Uri("pack://application:,,,/imag/metka.png"))
                    }
                };
                Map.Markers.Add(marker);
            });
        }
        
        void CityChose(string city, List<Root> list)
        {
            for (int i  = 0; i < list.Count(); i++)
                if (list[i].Venue.Country == city)
                {
                    
                    {
                        string markerinfo = list[i].Lineup[0] + "\n" + list[i].Description + "\n" + list[i].Title + "\n" + list[i].datetime;
                        if (list[i].Venue.Latitude == null && list[i].Venue.Longitude == null)
                        {
                        }
                        else
                        {
                            lng = float.Parse(list[i].Venue.Longitude.Replace(".", ","));
                            lat = float.Parse(list[i].Venue.Latitude.Replace(".", ","));
                            AddMarker(lat, lng, markerinfo);
                        }
                    }
                }
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
                    infoarr = null;
                    infoarr = ch.LoadEventInfo(ArtistList[i]);
                    CityChose(str, infoarr);
                }
            }).Start();
        }

        

        void SortDate (DateTime from, DateTime to, List<Root> list)
        {
            if (list == null)
                return;
            for (int i = 0; i < list.Count(); i++)

            {
                DateTime eventtime = list[i].datetime.DateTime;
                if (from <= eventtime && eventtime <= to)
                {
                    string markerinfo = list[i].Lineup[0] + "\n" + list[i].Description + "\n" + list[i].Title + "\n" + list[i].datetime;
                        if (list[i].Venue.Latitude == null && list[i].Venue.Longitude == null)
                        {
                        Application.Current.Dispatcher.Invoke(() =>
                        {
                            ListBoxItem OnlineEventinfo = new ListBoxItem()
                            {
                                Content = infoarr[i].Lineup[0],
                                ToolTip = markerinfo
                            };
                            OnlineList.Items.Add(OnlineEventinfo);
                        });
                        }
                        else
                        {
                            lng = float.Parse(list[i].Venue.Longitude.Replace(".", ","));
                            lat = float.Parse(list[i].Venue.Latitude.Replace(".", ","));
                            AddMarker(lat, lng, markerinfo);
                        }
                    }
                }
        }
        private void btnDateSort_Click(object sender, RoutedEventArgs e)
        {
            OnlineList.Items.Clear();
            Map.Markers.Clear();
            DateTime From = dt1.SelectedDate.Value;
            DateTime To = dt2.SelectedDate.Value;
            new Thread(() =>
            {
                for (int i = 0; i < ArtistList.Count + 1; i++)
                {
                    if (i >= ArtistList.Count)
                        return;
                    infoarr = null;
                    infoarr = ch.LoadEventInfo(ArtistList[i]);
                    SortDate(From, To, infoarr);
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
