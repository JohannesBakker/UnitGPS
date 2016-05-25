using System;
using MonoTouch.CoreLocation;

namespace UniteGPS.iOS
{
	public class DistanceHelper
	{
		public static  double  CalculateDistanceInKiloMeters ( double fromLatitude,double fromLongitude,double toLatitude,double toLongitude)
		{ 
			double distance;
			double R = 6372.795477598;
			double latA = (3.1415926538 * fromLatitude / 180);
			double lonA = (3.1415926538 * fromLongitude / 180);
			double latB = (3.1415926538 *toLatitude / 180);
			double lonB = (3.1415926538 * toLongitude / 180);
			distance = R * Math.Acos (Math.Sin (latA) * Math.Sin (latB) + Math.Cos (latA) * Math.Cos (latB) * Math.Cos (lonA - lonB));
			return distance;
		}
		public static  double  CalculateDistanceInKiloMeters ( CLLocationCoordinate2D from,CLLocationCoordinate2D to)
		{
			double distance;
			double R = 6372.795477598;
			double latA = (3.1415926538 * from.Latitude / 180);
			double lonA = (3.1415926538 * from.Longitude / 180);
			double latB = (3.1415926538 *to.Latitude / 180);
			double lonB = (3.1415926538 * to.Longitude / 180);
			distance = R * Math.Acos (Math.Sin (latA) * Math.Sin (latB) + Math.Cos (latA) * Math.Cos (latB) * Math.Cos (lonA - lonB));
			return distance;
		}
	}
}

