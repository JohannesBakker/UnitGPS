using System;
using MonoTouch.MapKit;
using MonoTouch.CoreLocation;

namespace UniteGPS.iOS
{
	public class BusStartAnnotationHelper:MKAnnotation
	{
		string title;
		CLLocationCoordinate2D coord;
		public BusStartAnnotationHelper (string title, CLLocationCoordinate2D coord)
		{
			this.title = title;
			this.coord = coord;
		}

		public override string Title {get {return title;}}

		public override CLLocationCoordinate2D Coordinate {get {return coord;}set {coord = value;}}			
	}
}

