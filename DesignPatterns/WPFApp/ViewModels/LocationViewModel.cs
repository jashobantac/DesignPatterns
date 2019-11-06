using System;
using System.Device.Location;
using System.Threading.Tasks;

using WPFApp.Extensions;
using WPFApp.ViewModels.Base;

namespace WPFApp.ViewModels
{

    public class LocationViewModel : ViewModelBase
    {
        private readonly GeoCoordinateWatcher _coordinateWatcher;

        private string _latitude;
        public string Latitude
        {
            get => _latitude;
            set => SetProperty(ref _latitude, value);
        }

        private string _longitude;
        public string Longitude
        {
            get => _longitude;
            set => SetProperty(ref _longitude, value);
        }

        private GeoCoordinate _necBangaloreLocation;
        public GeoCoordinate NecBangaloreLocation
        {
            get => _necBangaloreLocation;
            set => SetProperty(ref _necBangaloreLocation, value);
        }

        private string _distanceInMiles;
        public string DistanceInMiles
        {
            get => _distanceInMiles;
            set => SetProperty(ref _distanceInMiles, value);
        }

        private string _distanceInKms;
        public string DistanceInKms
        {
            get => _distanceInKms;
            set => SetProperty(ref _distanceInKms, value);
        }

        public LocationViewModel()
        {
            _coordinateWatcher = new GeoCoordinateWatcher(GeoPositionAccuracy.High);
            Task.Run(() =>
            {
                Initialize();
            });

            NecBangaloreLocation = new GeoCoordinate(12.9328392, 77.6007083);
        }

        private void Initialize()
        {
            _coordinateWatcher.TryStart(true, TimeSpan.FromSeconds(2000));
            _coordinateWatcher.PositionChanged -= CoordinateWatcher_PositionChanged;
            _coordinateWatcher.PositionChanged += CoordinateWatcher_PositionChanged;
        }

        private void CoordinateWatcher_PositionChanged(object sender, GeoPositionChangedEventArgs<GeoCoordinate> e)
        {
            Latitude = e.Position.Location.Latitude.ToString();
            Longitude = e.Position.Location.Longitude.ToString();

            DistanceInKms = NecBangaloreLocation.GetDistance(new GeoCoordinate(e.Position.Location.Latitude, e.Position.Location.Longitude), Units.Kilometers).ToString("0.##########");
            DistanceInMiles = NecBangaloreLocation.GetDistance(new GeoCoordinate(e.Position.Location.Latitude, e.Position.Location.Longitude), Units.Miles).ToString("0.##########");
        }
    }
}
