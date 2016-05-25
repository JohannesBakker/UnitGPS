
using System;
using Xamarin.Forms;
using UniteGPS;
using UniteGPS.iOS;
using MonoTouch.MapKit;
using Xamarin.Forms.Maps.iOS;
using MonoTouch.CoreLocation;
using MonoTouch.UIKit;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms.Maps;
using MonoTouch.Foundation;
using System.Drawing;
using Newtonsoft.Json;
using System.Diagnostics;

[assembly: ExportRenderer (typeof (MyMap), typeof (MyMapRenderer))]
namespace UniteGPS.iOS
{
	public class MyMapRenderer :MapRenderer
	{
		List<RoutesResponse> routesResponse;
		MyMap myMap;
		MKPolylineRenderer lineRenderer;
		List<StopsForRouteResponse> stopsresponse;
		string objbusroute;
		MyMapDelegate myMapDelegate = new MyMapDelegate ();
		public MKMapView NativeMap { get { return (this.NativeView as MapRenderer).Control as MKMapView; } }
		private NSTimer timer;
		#pragma warning disable 219
		public MyMapRenderer()
		{
			timer = NSTimer.CreateRepeatingScheduledTimer (new TimeSpan (0, 0, 1),
				delegate {
					TestMethod (null, null);
				} );
			Console.WriteLine (timer);
		}
		private void TestMethod(object sender , MKMapViewDragStateEventArgs e)
		{
			try
			{
				double zV = Math.Log ((360 * ((this.NativeMap.Frame.Size.Width / 256) / this.NativeMap.Region.Span.LongitudeDelta)), 2);
				zV = Math.Round (zV, 4);
				UISession.radius = zV - 0.1318;
			}
			catch(Exception ex)
			{
				Console.WriteLine (ex.Message);
			}
		}
		protected override void OnElementChanged(Xamarin.Forms.Platform.iOS.ElementChangedEventArgs<View> e)
		{
			try
			{
				base.OnElementChanged (e);
				if (e.OldElement == null)
				{
					MapValues.places = new List<CLLocationCoordinate2D> ();
					MapValues.mapView = Control as MKMapView;
					myMap = e.NewElement as MyMap;
					MapValues.mapView.OverlayRenderer = (m, o) => 
					{
						if (lineRenderer == null) 
						{
							lineRenderer = new MKPolylineRenderer (o as MKPolyline);
							lineRenderer.StrokeColor = UIColor.FromRGB(0,0,255);
							lineRenderer.FillColor = UIColor.Green;
							lineRenderer.LineWidth = 3;
						}
						return lineRenderer;
					} ;
					CLLocationManager locationManager = new  CLLocationManager ();
					if (Convert.ToInt16 (UIDevice.CurrentDevice.SystemVersion.Split ('.') [0].ToString ()) >= 8) 
					{
						try
						{
							locationManager.RequestWhenInUseAuthorization ();
							locationManager.RequestAlwaysAuthorization ();
							locationManager.StartUpdatingLocation ();
							NativeMap.ShowsUserLocation = true;
						}
						catch (Exception ex)
						{
							Console.WriteLine(ex.Message);
						}
					}
					var userID = Devices.Storage.Get ("UserId");
					routesResponse = DependencyService.Get<IBusClient> ().GetRoutes (int.Parse(userID));
					if (routesResponse != null && routesResponse.Count == 1)
					{
						string[] listviewitems = routesResponse.Select (n => n.name).ToArray ();
						UISession.routeId = routesResponse [0].id;
						UISession.SelectedRoute = routesResponse [0].name;
						var routmaps = routesResponse.Where (n => n.name == listviewitems [0]).FirstOrDefault ();
						var maps = routmaps.routePoints;
						CLLocationCoordinate2D[] cords = new CLLocationCoordinate2D[maps.Count];
						for (int i = 0; i < maps.Count; i++) {
							var map1 = maps [i];
							var lng = Convert.ToDouble (map1.lng);
							var lat = Convert.ToDouble (map1.lat);
							var point = new CLLocationCoordinate2D (lat, lng);
							MapValues.places.Add (point);
							cords [i] = point;
							if (i == 0)							
								NativeMap.AddAnnotation (new BusStartAnnotationHelper ("", new CLLocationCoordinate2D (Convert.ToDouble (map1.lat), Convert.ToDouble (map1.lng))));
							else if (i == maps.Count - 1)
								NativeMap.AddAnnotation (new BusEndAnnotationHelper ("", new CLLocationCoordinate2D (Convert.ToDouble (map1.lat), Convert.ToDouble (map1.lng))));
						}
						stopsresponse = DependencyService.Get<IBusClient> ().GetStopsForRoute (Convert.ToInt32 (userID), routmaps.id);
						if (stopsresponse != null && stopsresponse.Count > 0)
						{
							foreach (var item in stopsresponse) {
								NativeMap.Delegate = myMapDelegate;
								NativeMap.AddAnnotation(new MKPointAnnotation (){
									Title=item.name,
									Coordinate = new CLLocationCoordinate2D (Convert.ToDouble (item.lat), Convert.ToDouble (item.lng))
								} );
								myMap.MoveToRegion (MapSpan.FromCenterAndRadius (
									new Position (Convert.ToDouble (item.lat), Convert.ToDouble (item.lng)), Distance.FromMiles (UISession.radius)));
							}
						}  
						MapValues.lineOverlay = MKPolyline.FromCoordinates (cords);
						MapValues.mapView.AddOverlay (MapValues.lineOverlay);
					}  
					else 
					{
						NativeMap.DidUpdateUserLocation += (sender1, e1) => 
						{
							var mapCenter = new CLLocationCoordinate2D (NativeMap.UserLocation.Coordinate.Latitude, NativeMap.UserLocation.Coordinate.Longitude);
							var mapRegion = MKCoordinateRegion.FromDistance (mapCenter, UISession.radius, UISession.radius);
							NativeMap.CenterCoordinate=mapCenter;
							NativeMap.Region = mapRegion;
							myMap.MoveToRegion (MapSpan.FromCenterAndRadius (
								new Position ( mapCenter.Latitude,mapCenter.Longitude), Distance.FromKilometers (0.3)));
						} ;
					}
				}
				UISession.FirstTime = false;
			}
			catch(Exception ex)
			{
				Console.WriteLine (ex.Message);
			}
		}

		protected override void OnElementPropertyChanged (object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			try
			{
				base.OnElementPropertyChanged (sender, e);
				if (UISession.FirstTime == false && UISession.Routeselected) 
				{
					//				PointF location = new PointF ();
					//				location.X = NativeMap.Frame.Size.Width / 2.0f;
					//				location.Y = 0;
					//				CLLocationCoordinate2D topCenterCoordinate = NativeMap.ConvertPoint (location, this.NativeMap);
					//				radius = DistanceHelper.CalculateDistanceInKiloMeters (NativeMap.CenterCoordinate, topCenterCoordinate);
					if (MapValues.lineOverlay != null) {
						MapValues.mapView.RemoveOverlay (MapValues.lineOverlay);
						MapValues.mapView.RemoveAnnotations (MapValues.mapView.Annotations);
					}
					MapValues.mapView = Control as MKMapView;

					MapValues.mapView.OverlayRenderer = (m, o) => 
					{
						lineRenderer=null;
						if (lineRenderer == null) {
							lineRenderer = new MKPolylineRenderer (o as MKPolyline);
							lineRenderer.StrokeColor = UIColor.FromRGB(0,0,255);
							lineRenderer.FillColor = UIColor.Green;
							lineRenderer.LineWidth = 3;
						}
						return lineRenderer;
					} ;
					var userID = Devices.Storage.Get ("UserId");
					Console.WriteLine("UserId:{ 0}",userID);
					if (UISession.routeResponse!= null && UISession.routeResponse.Count > 0) 
					{					
						MapValues.places = new List<CLLocationCoordinate2D> ();
						string[] listviewitems = UISession.routeResponse.Select (n => n.name).ToArray ();
						var routmaps = UISession.routeResponse.Where (n => n.name == UISession.SelectedRoute).FirstOrDefault ();
						var maps = routmaps.routePoints;
						CLLocationCoordinate2D[] cords = new CLLocationCoordinate2D[maps.Count];
						for (int i = 0; i < maps.Count; i++) {
							var map1 = maps [i];
							var lng = Convert.ToDouble (map1.lng);
							var lat = Convert.ToDouble (map1.lat);
							var point = new CLLocationCoordinate2D (lat, lng);
							MapValues.places.Add (point);
							cords [i] = point;
							if (i == 0) {							
								NativeMap.AddAnnotation (new BusStartAnnotationHelper ("", new CLLocationCoordinate2D (Convert.ToDouble (map1.lat), Convert.ToDouble (map1.lng))));
							}  else if (i == maps.Count - 1) {
								NativeMap.AddAnnotation (new BusEndAnnotationHelper ("", new CLLocationCoordinate2D (Convert.ToDouble (map1.lat), Convert.ToDouble (map1.lng))));
							}
						}
						MapValues.lineOverlay = MKPolyline.FromCoordinates (cords);
						MapValues.mapView.AddOverlay (MapValues.lineOverlay);
						if (UISession.stopsresponse != null && UISession.stopsresponse.Count > 0) 
						{
							foreach (var item in UISession.stopsresponse) {
								NativeMap.Delegate = myMapDelegate;
								NativeMap.AddAnnotation (new AnnotationHelper (item.name, new CLLocationCoordinate2D (Convert.ToDouble (item.lat), Convert.ToDouble (item.lng))));
							}
						}
						else
						{
							UIAlertView alert = new UIAlertView ("UniteGPS","No stops available for this route.", null, "OK", null);
							alert.Show ();
						}
					}
					MovingBusRoute ();
					UISession.Routeselected = false;

				}
			}
			catch(Exception ex)
			{
				Console.WriteLine (ex.Message);
			}
		}	
		public void MovingBusRoute()
		{
			try
			{
				if (UISession.routeId != 0)
				{
					objbusroute = DependencyService.Get<IBusClient> ().GetBusCoordinates (UISession.routeId);
					objbusroute = objbusroute.Replace ("[", "");
					objbusroute = objbusroute.Replace ("]", "");
					if (objbusroute != "[]" && objbusroute != "" && objbusroute != null)
					{  
						var obj = JsonConvert.DeserializeObject<RootObject> (objbusroute);
						NativeMap.Delegate = myMapDelegate;
						NativeMap.AddAnnotation (new MKPointAnnotation () {
							Title = "",
							Coordinate = new CLLocationCoordinate2D (Convert.ToDouble (obj.lat), Convert.ToDouble (obj.lng))
						} );
						var mapCenter = new CLLocationCoordinate2D (Convert.ToDouble (obj.lat), Convert.ToDouble (obj.lng));
						NativeMap.SetCenterCoordinate (mapCenter, true);

					}
				}
			}
			catch(Exception ex)
			{
				Console.WriteLine (ex.Message);
			}
		}
	}
	public class MyMapDelegate : MKMapViewDelegate 
	{
		protected string annotationIdentifier = "BasicAnnotation";

		public override MKAnnotationView GetViewForAnnotation (MKMapView mapView, NSObject annotation)
		{
			MKAnnotationView annotationView = mapView.DequeueReusableAnnotation(annotationIdentifier);   
			if (annotationView == null)
				annotationView = new MKPinAnnotationView(annotation, annotationIdentifier);
			annotationView.CanShowCallout = true;
			if (annotation is AnnotationHelper)
			{
				annotationView.Image = UIImage.FromFile ("Images/Bus_Stop_Icon.png");
				UISession.MovingBus = false;
			}
			else if (annotation is BusStartAnnotationHelper)
			{
				annotationView.Image = UIImage.FromFile ("Images/Start_Icon.png");
				UISession.MovingBus = false;
			}
			else if (annotation is BusEndAnnotationHelper)
			{
				annotationView.Image = UIImage.FromFile ("Images/End_Icon.png");
				UISession.MovingBus = false;
			}
			else 
				annotationView.Image = UIImage.FromFile ("Images/Bus_Icon.png");

			annotationView.RightCalloutAccessoryView = UIButton.FromType (UIButtonType.DetailDisclosure);
			return annotationView;
		}
	}
}