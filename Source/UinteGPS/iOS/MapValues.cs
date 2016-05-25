using System;
using MonoTouch.CoreLocation;
using MonoTouch.MapKit;
using System.Collections.Generic;

namespace UniteGPS.iOS
{
	public class MapValues
	{
		public static CLLocationCoordinate2D[] mapcord;
		public static MKMapView mapView;
		public static MKPolyline lineOverlay;
		public static List<CLLocationCoordinate2D> places;
	}
}

