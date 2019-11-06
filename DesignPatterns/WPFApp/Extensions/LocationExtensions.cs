using System;
using System.Device.Location;

namespace WPFApp.Extensions
{
    public enum Units
    {
        NauticalMiles,
        Kilometers,
        Meters,
        Miles
    }

    public static class LocationExtensions
    {
        public static double GetDistance(this GeoCoordinate source, GeoCoordinate target, Units unit)
        {
            if (source == null || target == null)
            {
                return 0;
            }
            double sourceLat = source.Latitude;
            double sourceLong = source.Longitude;

            double targetLat = target.Latitude;
            double targetLong = target.Longitude;

            double theta = targetLong - sourceLong;
            double dist = Math.Sin(DegreeToRadian(sourceLat)) * Math.Sin(DegreeToRadian(targetLat)) + Math.Cos(DegreeToRadian(sourceLat)) * Math.Cos(DegreeToRadian(targetLat)) * Math.Cos(DegreeToRadian(theta));
            dist = Math.Acos(dist);
            dist = RadianToDegree(dist);
            dist = dist * 60 * 1.1515;
            if (unit == Units.Kilometers)
            {
                dist = dist * 1.609344;
            }
            else if (unit == Units.Meters)
            {
                dist = dist * 1.609344 * 1000;
            }
            else if (unit == Units.NauticalMiles)
            {
                dist = dist * 0.8684;
            }
            return (dist);
        }

        private static double RadianToDegree(double radians)
        {
            return (radians / Math.PI * 180.0);
        }

        private static double DegreeToRadian(double degree)
        {
            return (degree * Math.PI / 180.0);
        }
    }
}
