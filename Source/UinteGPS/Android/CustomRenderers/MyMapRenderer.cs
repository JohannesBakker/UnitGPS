using System;
using Xamarin.Forms;
using UniteGPS;
using UniteGPS.Android;
using Xamarin.Forms.Maps.Android;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Platform.Android;
using Newtonsoft.Json;
using Android.Views;
using Android.Locations;
using System.Threading;
using Android.Gms.Maps.Model;
using Android.Gms.Maps;


[assembly: ExportRenderer (typeof (MyMap), typeof (MyMapRenderer))]
[assembly:Dependency(typeof(LiveMapScreen))]
namespace UniteGPS.Android
{
	public class MyMapRenderer : MapRenderer
	{

		MapView mapView;
		public GoogleMap map;
		MyMap myMap;
		LatLng cords;
		List<RoutesResponse> routesResponse;
		List<StopsForRouteResponse> stopsresponse;
		RoutesResponse routmaps;
		string objbusroute;
		float currentZoomLevel;
		protected  override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.View> e)
		{
			base.OnElementChanged(e);
			//zoomLevel ();
			if(UISession.FirstTime)
			{
				if (e.OldElement == null) {
					mapView = Control as MapView;
					map = mapView.Map;
					myMap = e.NewElement as MyMap;
					PolylineOptions line = new PolylineOptions ();
					line.InvokeColor (global::Android.Graphics.Color.Rgb(0,0,255));
					var userID = Devices.Storage.Get ("UserId");
					int userIDValue = -1;
					if (String.IsNullOrEmpty (userID) == false)
						userIDValue = int.Parse (userID);
					routesResponse = DependencyService.Get<IBusClient> ().GetRoutes (userIDValue);
					if (routesResponse != null && routesResponse.Count == 1) 
					{
						var listviewitems = routesResponse.Select (n => n.name).ToArray ();
						UISession.routeId = routesResponse [0].id;
						UISession.SelectedRoute = routesResponse [0].name;
						var routmaps = routesResponse.Where (n => n.name == listviewitems [0]).FirstOrDefault ();
						if (routmaps != null) {
							var maps = routmaps.routePoints;//latitude and longitude

							for (int i = 0; i < maps.Count; i++) {
								var map1 = maps [i];
								var lng = Convert.ToDouble (map1.lng);
								var lat = Convert.ToDouble (map1.lat);
								cords = new LatLng (lat, lng);
								line.Add (cords);
								if (i == 0) {
									var markerWithIcon = new MarkerOptions ();
									markerWithIcon.SetPosition (new LatLng (lat, lng));
									markerWithIcon.SetTitle ("");
									markerWithIcon.InvokeIcon (BitmapDescriptorFactory.FromResource (Resource.Drawable.Start_Icon));
									mapView.Map.AddMarker (markerWithIcon);
								} else if (i == maps.Count - 1) {
									var markerWithIcon = new MarkerOptions ();
									markerWithIcon.SetPosition (new LatLng (lat, lng));
									markerWithIcon.SetTitle ("");
									markerWithIcon.InvokeIcon (BitmapDescriptorFactory.FromResource (Resource.Drawable.End_Icon));
									mapView.Map.AddMarker (markerWithIcon);
								}
							}
							map.AddPolyline (line);
						}
						stopsresponse = DependencyService.Get<IBusClient> ().GetStopsForRoute (Convert.ToInt32 (userID), routmaps.id);
						if (stopsresponse != null && stopsresponse.Count > 0) {
							foreach (var item in stopsresponse) {
								myMap.CustomPins.Add (new CustomPin {
									Position = new Position (Convert.ToDouble (item.lat), Convert.ToDouble (item.lng)),
									Label = item.name,
									//Address = "",
									PinIcon = "CarWashMapIcon"
								});
							}
						}

						var markrs = myMap.CustomPins;

						foreach (var item in markrs) {
							var markerWithIcon = new MarkerOptions ();

							markerWithIcon.SetPosition (new LatLng (item.Position.Latitude, item.Position.Longitude));
							markerWithIcon.SetTitle (item.Label);
							if (!string.IsNullOrEmpty (item.PinIcon))
								markerWithIcon.InvokeIcon (BitmapDescriptorFactory.FromResource (Resource.Drawable.Bus_Stop_Icon));
							else
								markerWithIcon.InvokeIcon (BitmapDescriptorFactory.DefaultMarker ());

							mapView.Map.AddMarker (markerWithIcon);
						}
					} 
					else {
						Position position = new Position(Convert.ToDouble (UISession.currentlat),  Convert.ToDouble (UISession.currentlng));
						myMap.MoveToRegion (MapSpan.FromCenterAndRadius (position, Distance.FromMiles (0.5)));
					}
				}
				currentZoomLevel = map.CameraPosition.Zoom;
				map.CameraChange += (object sender, GoogleMap.CameraChangeEventArgs e1) => {
					if ((int)e1.Position.Zoom == (int)currentZoomLevel) {
						UISession.zoomlevelchanged=true;
						ZoomlevelChanged ();
						return;
					}
					UISession.zoomlevelchanged=true;
					currentZoomLevel = e1.Position.Zoom;
					Console.WriteLine ("New current zoom level: " + currentZoomLevel);
					UISession.CurrentZoomLevel = Convert.ToDouble (currentZoomLevel);
				};
				UISession.CurrentZoomLevel =Convert.ToDouble(currentZoomLevel);
			}
			UISession.FirstTime = false;
		}

		protected override void OnElementPropertyChanged (object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged (sender, e);
			myMap = (MyMap)sender;
			if (UISession.FirstTime == false && UISession.Routeselected) {
				if(UISession.zoomlevelchanged==false)
					ZoomlevelChanged ();	
			}
		}
		private void ZoomlevelChanged()
		{

			if (map != null)
				map.Clear ();
			mapView = Control as MapView;
			map = mapView.Map;
			myMap.CustomPins = new List<CustomPin> ();
			PolylineOptions line = new PolylineOptions ();
			line.InvokeColor (global::Android.Graphics.Color.Rgb (0, 0, 255));
			var userID = Devices.Storage.Get ("UserId");
			if (UISession.routeResponse != null && UISession.routeResponse.Count > 0) {
				routmaps = UISession.routeResponse.Where (n => n.name == UISession.SelectedRoute).FirstOrDefault ();
				if (routmaps != null) {
					var maps = routmaps.routePoints;//latitude and longitude

					for (int i = 0; i < maps.Count; i++) {
						var map1 = maps [i];
						var lng = Convert.ToDouble (map1.lng);
						var lat = Convert.ToDouble (map1.lat);
						cords = new LatLng (lat, lng);
						line.Add (cords);
						if (i == 0) {
							var markerWithIcon = new MarkerOptions ();
							markerWithIcon.SetPosition (new LatLng (lat, lng));
							markerWithIcon.SetTitle ("");
							markerWithIcon.InvokeIcon (BitmapDescriptorFactory.FromResource (Resource.Drawable.Start_Icon));
							mapView.Map.AddMarker (markerWithIcon);
						} else if (i == maps.Count - 1) {
							var markerWithIcon = new MarkerOptions ();
							markerWithIcon.SetPosition (new LatLng (lat, lng));
							markerWithIcon.SetTitle ("");
							markerWithIcon.InvokeIcon (BitmapDescriptorFactory.FromResource (Resource.Drawable.End_Icon));
							mapView.Map.AddMarker (markerWithIcon);
						}
					}
					map.AddPolyline (line);
				}
				if (UISession.stopsresponse != null && UISession.stopsresponse.Count > 0) {
					foreach (var item in UISession.stopsresponse) {
						myMap.CustomPins.Add (new CustomPin {
							Position = new Position (Convert.ToDouble (item.lat), Convert.ToDouble (item.lng)),
							Label = item.name,
							//Address = "",
							PinIcon = "CarWashMapIcon"
						});
					}
				}

				var markrs = myMap.CustomPins;

				foreach (var item in markrs) {
					var markerWithIcon = new MarkerOptions ();

					markerWithIcon.SetPosition (new LatLng (item.Position.Latitude, item.Position.Longitude));
					markerWithIcon.SetTitle (item.Label);
					if (!string.IsNullOrEmpty (item.PinIcon))
						markerWithIcon.InvokeIcon (BitmapDescriptorFactory.FromResource (Resource.Drawable.Bus_Stop_Icon));
					else
						markerWithIcon.InvokeIcon (BitmapDescriptorFactory.DefaultMarker ());

					mapView.Map.AddMarker (markerWithIcon);
				}
			}
			MovingBusRoot ();
			UISession.Routeselected = false;
		}
		public void MovingBusRoot()
		{
			if (UISession.routeId != null && UISession.routeId != 0 && (UISession.lat != null && UISession.lat!=0) && (UISession.lng != null && UISession.lng!=0)) {
				var markerWithIcon = new MarkerOptions ();
				markerWithIcon.SetPosition (new LatLng (UISession.lat, UISession.lng));
				markerWithIcon.SetTitle ("");
				markerWithIcon.InvokeIcon (BitmapDescriptorFactory.FromResource (Resource.Drawable.Bus_Icon));
				mapView.Map.AddMarker (markerWithIcon);
			} else if(UISession.routeId != null && UISession.routeId != 0)
			{
				objbusroute = DependencyService.Get<IBusClient> ().GetBusCoordinates (UISession.routeId);
				objbusroute = objbusroute.Replace ("[", "");
				objbusroute = objbusroute.Replace ("]", "");
				if (objbusroute != "[]" && objbusroute != "" && objbusroute != null) { 
					var markerWithIcon = new MarkerOptions ();
					var obj = JsonConvert.DeserializeObject<RootObject> (objbusroute);
					markerWithIcon.SetPosition (new LatLng (Convert.ToDouble(obj.lat), Convert.ToDouble(obj.lng)));
					markerWithIcon.SetTitle ("");
					markerWithIcon.InvokeIcon (BitmapDescriptorFactory.FromResource (Resource.Drawable.Bus_Icon));
					mapView.Map.AddMarker (markerWithIcon);
				}
			}
		}
	}
}
