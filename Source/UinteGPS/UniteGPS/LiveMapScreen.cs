using System;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniteGPS;
using System.Threading;
using Newtonsoft.Json;
using System.Diagnostics;

namespace UniteGPS
{
	public class LiveMapScreen : ContentPage
	{
		#region PUBLIC MEMBERS
		public MasterDetailPage MasterPage { get; set; }
		#endregion

		#region PRIVATE MEMBERS
		MyMap map;
		public static bool isRoute = true;
		public static bool isStop = true;
		public static bool isMap = true;
		List<RoutesResponse> routesResponse;
		List<StopsForRouteResponse> stopsresponse;
		MyListView routesList;
		Label maplabel;
		Label maproute;
		Image imgcenteron;
		AbsoluteLayout RoutesLayout;
		ActivityIndicator activityIndicator;
		string userID = Devices.Storage.Get ("UserId");
		string objbusroute;
		#endregion

		#pragma warning disable 253
		public LiveMapScreen ()
		{
			var network= DependencyService.Get<INetworkConnection>();
			network.CheckNetworkConnection();
			if (network.IsConnected) {
				//DependencyService.Get<IAdMobInterstitialAd> ().UnitId = "ca-app-pub-2398347475015144/4185449111";//ca-app-pub-2398347475015144/4185449111
				//DependencyService.Get<IAdMobInterstitialAd> ().DeviceId = "1423F3A29B67BDA144473E14709997B3";
				//DependencyService.Get<IAdMobInterstitialAd> ().LoadAd ();
				this.BackgroundColor = Color.White;
				map = new MyMap(MapSpan.FromCenterAndRadius (new Position (43.9943, -70.05628), Distance.FromMiles (1)))  { 
					//IsShowingUser = true,
					WidthRequest = 960,
					HeightRequest = 100,
					HasZoomEnabled=true,
				};
				var imgroute = new Image {
					Aspect = Aspect.AspectFill,
					HorizontalOptions = LayoutOptions.Start,
					WidthRequest = 40,
					HeightRequest = 40,
				};
				imgroute.Source = ImageSource.FromFile ("Images/Routesimg.png");

				var imgPremium = new Image {
					Aspect = Aspect.Fill,
					WidthRequest = 40,
					HeightRequest = 40 
				};
				imgPremium.Source = ImageSource.FromFile ("Images/premiums.png");

				var imgLogo = new Image {
					Aspect = Aspect.AspectFit,
					Source = ImageSource.FromFile("Images/UinteGps_Title.png"),
				};

				var imgSideMenu = new Image {
					Aspect = Aspect.AspectFit,
					Source = ImageSource.FromFile("Images/navbar_sidebar.png"),
				};

				var routeMenuCancel = new Image {
					Aspect = Aspect.AspectFit,
					Source = ImageSource.FromFile("Images/route_cancel.png"),
					WidthRequest = 25,
					HeightRequest = 25,
				};

				var lblroute = new Label {
					Text = "Routes",
					TextColor = Color.Black,
					FontAttributes = FontAttributes.Bold,
					FontSize = Device.GetNamedSize (NamedSize.Small, typeof(Label)),
				};
				var lblPremium = new Label {
					Text = "Premium",
					TextColor = Color.Black,
					FontAttributes = FontAttributes.Bold,
					FontSize = Device.GetNamedSize (NamedSize.Small, typeof(Label)),
				};
				var imgdivider = new Image {
					Aspect = Aspect.Fill,
					WidthRequest = 40,
					HeightRequest = 70 
				};
				imgdivider.Source = ImageSource.FromFile ("Images/verticalseparator.png");
				maproute = new Label {
					WidthRequest = 160,
					BackgroundColor = Color.FromRgb (135, 206, 250),
					HeightRequest = 70,
				};
				maproute.IsVisible = false;
				var mappremium = new Label {
					WidthRequest = 160,
					BackgroundColor = Color.FromRgb (135, 206, 250),
					HeightRequest = 70,
				};
				mappremium.IsVisible = false;
				var imgcurrentloc = new Image {
					Aspect = Aspect.Fill,
					HeightRequest = 25,
					WidthRequest = 25
				};
				imgcurrentloc.Source = ImageSource.FromFile ("Images/Currentlocation.png");
				imgcenteron = new Image {
					Aspect = Aspect.Fill,
					HeightRequest = 40,
					WidthRequest = 100
				};
				imgcenteron.Source = ImageSource.FromFile ("Images/CenterOn.png");

				//Activity Indicator
				activityIndicator = new ActivityIndicator {
					Color = Device.OnPlatform (Color.Black, Color.Red, Color.Default),
					IsRunning = true,
					VerticalOptions = LayoutOptions.CenterAndExpand
				};
				activityIndicator.IsRunning = false;

				//Routes List
				var label1 = new Label {
					BackgroundColor = Color.Black, 
					HeightRequest = 30,
					WidthRequest = 180,
					Text = "  Choose a location",
					XAlign = TextAlignment.Start,
					YAlign = TextAlignment.Center,
					TextColor = Color.White,
					FontAttributes = FontAttributes.Bold,
					FontSize = Device.GetNamedSize (NamedSize.Small, typeof(Label)),
				};
				var imgChoose = new Image {
					Aspect = Aspect.Fill,
					HeightRequest = 20,
					WidthRequest = 20
				};
				imgChoose.Source = ImageSource.FromFile ("Images/Arrowimg.png");

				maplabel = new Label {
					BackgroundColor = Color.Transparent
				};
				maplabel.IsVisible = false;

				routesList = new MyListView {  
					BackgroundColor = Color.White,
					HeightRequest = 240,
					WidthRequest = 180,
					RowHeight = 40,
				};
				RoutesLayout = new AbsoluteLayout ();
				RoutesLayout.Children.Add (label1, new Point (30, 0));
				RoutesLayout.Children.Add (routesList, new Point (30, 30));
				RoutesLayout.Children.Add (routeMenuCancel, new Point (170, 3));

				TapGestureRecognizer routeCloseGesture = new TapGestureRecognizer ();
				routeCloseGesture.Tapped += (object sender, EventArgs e) => {
					RoutesLayout.IsVisible = false;
					maproute.IsVisible = false;
					maplabel.IsVisible = false;
				};

				routeMenuCancel.GestureRecognizers.Add (routeCloseGesture);

				var networkConnection3 = DependencyService.Get<INetworkConnection>();
				networkConnection3.CheckNetworkConnection();
				if (networkConnection3.IsConnected)
				{
					if (userID != null)
					{
						activityIndicator.IsRunning = true;
						BeginInvokeOnMainThreadAsync (routeData);
					} 
					else 
					{
						DisplayAlert ("UniteGPS", "No user available with this username", "Ok");
					}
				} 
				else
				{
					DisplayAlert ("UniteGPS", "Please check your network connection ", null, "OK");
				}
				imgcenteron.IsVisible = false;
				routesList.ItemTemplate = new DataTemplate (typeof(RoutesListView));
				routesList.ItemSelected += (object sender, SelectedItemChangedEventArgs e) => {
					if (e.SelectedItem == null)
						return;
					
					UISession.lat =0;
					UISession.lng=0;
					var networkConnection = DependencyService.Get<INetworkConnection> ();
					networkConnection.CheckNetworkConnection ();
					if (networkConnection.IsConnected)
					{
						activityIndicator.IsRunning=true;
						RoutesLayout.IsVisible = false;
						maproute.IsVisible = false;
						maplabel.IsVisible = false;
						imgcenteron.IsVisible = true;
						Task.Factory.StartNew (()=>
							{
								routeSelected(e.SelectedItem);
							}).ContinueWith ( 
								t => {
									activityIndicator.IsRunning=false;
								}, TaskScheduler.FromCurrentSynchronizationContext()
							);
					}
					else 
					{
						DisplayAlert ("UniteGPS", "Please check your network and try again ", null, "OK");
					}
				};

				Device.StartTimer(new TimeSpan(0,0,0,5),()=>{
					routeBusCordinate();
					return true;
				});
				/*(
				if (Device.OS == TargetPlatform.Android)
				{
					Device.StartTimer (new TimeSpan (0, 0, 5, 0), () => {
						if(UISession.i != 0)
						{
							if (DependencyService.Get<IAdMobInterstitialAd> ().IsAdLoaded) {
								DependencyService.Get<IAdMobInterstitialAd> ().Show ();
							}
						}
						return true;
					});
				}
				else if (Device.OS == TargetPlatform.iOS) 
				{
					Device.StartTimer (new TimeSpan (0, 0, 5, 0), () => {
						if (DependencyService.Get<IAdMobInterstitialAd> ().IsAdLoaded) {
							DependencyService.Get<IAdMobInterstitialAd> ().Show ();
						}
						return true;
					});
				}
*/
				//Ads
				AdsView ads = new AdsView ();

				//RelativeLAyout
				RelativeLayout relativeLayout = new RelativeLayout {
				};

				relativeLayout.Children.Add (map, 
					xConstraint: Constraint.Constant (0),
					yConstraint: Constraint.Constant (50), 
					widthConstraint: Constraint.RelativeToParent ((parent) => {
						return parent.Width;
					}),
					heightConstraint: Constraint.RelativeToParent ((parent) => {
						return parent.Height - 100;
					}));

				relativeLayout.Children.Add (imgLogo, Constraint.RelativeToParent ((parent) => {
					return parent.Width / 3 * 2 - 10;
				}),
					Constraint.RelativeToParent ((parent) => {
						return +0;
					}),
					Constraint.RelativeToParent ((parent) => {
						return parent.Width / 3;
					}),
					Constraint.RelativeToParent ((parent) => {
						return +50;
					})
				);

				relativeLayout.Children.Add (imgSideMenu, Constraint.RelativeToParent ((parent) => {
					return +10;
				}),
					Constraint.RelativeToParent ((parent) => {
						return +0;
					}),
					Constraint.RelativeToParent ((parent) => {
						return +30;
					}),
					Constraint.RelativeToParent ((parent) => {
						return +50;
					})
				);

				/*
				relativeLayout.Children.Add (maplabel, 
					xConstraint: Constraint.Constant (0),
					yConstraint: Constraint.Constant (90), 
					widthConstraint: Constraint.RelativeToParent ((parent) => {
						return parent.Width;
					}),
					heightConstraint: Constraint.RelativeToParent ((parent) => {
						return parent.Height;
					}));


				relativeLayout.Children.Add (imgdivider, Constraint.RelativeToParent ((parent) => {
					return parent.Width/2.3;
				}),
					Constraint.RelativeToParent ((parent) => {
						return +20;
					}));
				
				relativeLayout.Children.Add (maproute, Constraint.RelativeToParent ((parent) => {
					return 0;
				}),
					Constraint.RelativeToParent ((parent) => {
						return +20;
					}));

				relativeLayout.Children.Add (mappremium, Constraint.RelativeToParent ((parent) => {
					return +160;
				}),
					Constraint.RelativeToParent ((parent) => {
						return +20;
					}));
*/
				relativeLayout.Children.Add (RoutesLayout, Constraint.RelativeToParent ((parent) => {
					return 0;
				}),
					Constraint.RelativeToParent ((parent) => {
						return +90;
					}));

/*
				relativeLayout.Children.Add (imgroute, Constraint.RelativeToParent ((parent) => {
					return parent.Width / 5.2;
				}),
					Constraint.RelativeToParent ((parent) => {
						return +22;
					}));

				relativeLayout.Children.Add (imgPremium, Constraint.RelativeToParent ((parent) => {
					return parent.Width / 1.43;
				}),
					Constraint.RelativeToParent ((parent) => {
						return +22;
					}));

				relativeLayout.Children.Add (lblroute, Constraint.RelativeToParent ((parent) => {
					return parent.Width / 5.2;
				}),
					Constraint.RelativeToParent ((parent) => {
						return +65;
					}));

				relativeLayout.Children.Add (lblPremium, Constraint.RelativeToParent ((parent) => {
					return parent.Width / 1.50;
				}),
					Constraint.RelativeToParent ((parent) => {
						return +65;
					}));
				*/
				relativeLayout.Children.Add (ads, Constraint.RelativeToParent ((parent) => {
					return 0;
				}),
					Constraint.RelativeToParent ((parent) => {
						return parent.Height - 50;
					}));

				relativeLayout.Children.Add (activityIndicator, Constraint.RelativeToParent ((parent) => {
					return parent.Width / 2;
				}),
					Constraint.RelativeToParent ((parent) => {
						return parent.Height / 2;
					}));
				this.Content = relativeLayout;

				//TapGesture for Routes
				RoutesLayout.IsVisible = false;
				var tapGestureRecognizer1 = new TapGestureRecognizer();
				tapGestureRecognizer1.Tapped += (s, e) => 
				{
					var networkConnection = DependencyService.Get<INetworkConnection> ();
					networkConnection.CheckNetworkConnection ();
					if (networkConnection.IsConnected)
					{
						if (isRoute)
						{
							maproute.IsVisible=true;
							mappremium.IsVisible = false;
							routesList.ItemsSource=UISession.RoutesData;
							isRoute = false;
							isStop = true;
							RoutesLayout.IsVisible = true;
							maplabel.IsVisible = true;
						}
						else 
						{
							maproute.IsVisible=false;
							lblroute.BackgroundColor = Color.Transparent;
							isRoute = true;
							RoutesLayout.IsVisible = false;
							maplabel.IsVisible = false;
							activityIndicator.IsRunning = false;
						}

					} 
					else
					{
						DisplayAlert ("UniteGPS", "Please check your network and try again ", null, "OK");
					}
				};
				imgroute.GestureRecognizers.Add (tapGestureRecognizer1);

				//TapGesture for Premium
				var tapGestureRecognizer3 = new TapGestureRecognizer();
				tapGestureRecognizer3.Tapped += (s, e) => {
					var networkConnection2 = DependencyService.Get<INetworkConnection> ();
					networkConnection2.CheckNetworkConnection ();
					if (networkConnection2.IsConnected) 
					{
						RoutesLayout.IsVisible = false;
						maproute.IsVisible = false;
						mappremium.IsVisible = true;
						if (Device.OS == TargetPlatform.Android)
						{
							Device.OpenUri (new Uri ("https://play.google.com/store/apps/details?id=com.unitegps.unitegpsroutemaker&hl=en"));
						} 
						else if (Device.OS == TargetPlatform.iOS)
						{
							Device.OpenUri (new Uri ("https://play.google.com/store/apps/details?id=com.unitegps.unitegpsroutemaker&hl=en"));
						} 
					} 
					else
					{
						DisplayAlert ("UniteGPS", "Please check your network and try again ", null, "OK");
					}

				};
				imgPremium.GestureRecognizers.Add (tapGestureRecognizer3);

				var tapgest = new TapGestureRecognizer ();
				tapgest.Tapped += (s, e) => {
					if (isMap) 
					{
						maproute.IsVisible = false;
						RoutesLayout.IsVisible = false;
						maplabel.IsVisible = false;
						isRoute = true;
						isStop = true;
						activityIndicator.IsRunning = false;
					}
				};
				maplabel.GestureRecognizers.Add(tapgest);

				var tapSideMenu = new TapGestureRecognizer ();
				tapSideMenu.Tapped += (s, e) => {
					if (MasterPage != null)
						MasterPage.IsPresented = !MasterPage.IsPresented;
				};
				imgSideMenu.GestureRecognizers.Add (tapSideMenu);

			}
			else
			{
				DisplayAlert("UniteGPS","Please check your internet and try again","Ok");
			}
			activityIndicator.IsRunning=false;
		}
		public Task BeginInvokeOnMainThreadAsync(Action action)
		{
			TaskCompletionSource<object> tcs = new TaskCompletionSource<object>();
			Device.BeginInvokeOnMainThread(() =>
				{
					try
					{
						//activityIndicator.IsRunning=true;
						action();
						tcs.SetResult(null);
					}
					catch (Exception ex)
					{
						tcs.SetException(ex);
					}
				});
			return tcs.Task;
		}
		public void routeData()
		{
			try
			{
				routesResponse = DependencyService.Get<IBusClient> ().GetRoutes (int.Parse (userID));
				if (routesResponse != null && routesResponse.Count > 0) 
				{
					BeginInvokeOnMainThreadAsync(() => {
						UISession.routeResponse = routesResponse;
						string[] listviewitems = routesResponse.Select (n => n.name).ToArray ();
						UISession.RoutesData = listviewitems;
						routesList.ItemsSource = listviewitems;
					});
				} 
				else 
				{
					DisplayAlert ("UniteGPS", "No routes available", "Ok");
					activityIndicator.IsRunning = false;
				}
			}
			catch(Exception ex)
			{
				Debug.WriteLine (ex.Message);
			}
		}
		private void routeBusCordinate()
		{	
			try
			{
				if (UISession.routeId != 0) 
				{
					objbusroute = DependencyService.Get<IBusClient> ().GetBusCoordinates (UISession.routeId);
					objbusroute = objbusroute.Replace ("[", "");
					objbusroute = objbusroute.Replace ("]", "");
					if (Device.OS == TargetPlatform.Android) 
					{
						if (objbusroute != "[]" && objbusroute != "" && objbusroute != null)
						{
							UISession.Routeselected = true;
							UISession.MovingBus = true;
							var obj = JsonConvert.DeserializeObject<RootObject> (objbusroute);
							Position position = new Position(Convert.ToDouble (obj.lat),  Convert.ToDouble (obj.lng));
							var latlongdeg = 360 / (Math.Pow(2, UISession.CurrentZoomLevel-0.4));
							map.MoveToRegion (new MapSpan(position, latlongdeg,latlongdeg));
							UISession.lat = Convert.ToDouble (obj.lat);
							UISession.lng = Convert.ToDouble (obj.lng);
						}
					}
					else if (Device.OS == TargetPlatform.iOS) 
					{
						if (objbusroute != "[]" && objbusroute != "" && objbusroute != null) 
						{
							UISession.Routeselected = true;
							UISession.MovingBus = true;
							if (UISession.stopsresponse != null && UISession.stopsresponse.Count > 0) 
							{
								map.CustomPins = new List<CustomPin> ();
								for (int i = 0; i < UISession.stopsresponse.Count; i++){
									map.CustomPins.Add (new CustomPin {
										Position = new Position (Convert.ToDouble (stopsresponse [i].lat), Convert.ToDouble (stopsresponse [i].lng)),
										Label = UISession.stopsresponse [i].name,
										PinIcon = "CarWashMapIcon"
									});
								}
							}
							var obj = JsonConvert.DeserializeObject<RootObject> (objbusroute);
							Debug.WriteLine(obj.time);
							//						Position position = new Position(Convert.ToDouble (obj.lat),  Convert.ToDouble (obj.lng));
							//						var latlongdeg = 360 / (Math.Pow(2, UISession.radius));
							//						map.MoveToRegion (new MapSpan(position, latlongdeg,latlongdeg));
							//						map.MoveToRegion (MapSpan.FromCenterAndRadius (new Position (Convert.ToDouble (obj.lat), Convert.ToDouble (obj.lng)), Distance.FromMiles (UISession.radius)));
							UISession.lat = Convert.ToDouble (obj.lat);
							UISession.lng = Convert.ToDouble (obj.lng);
						}
					}
				}
			}
			catch(Exception ex)
			{
				Debug.WriteLine (ex.Message);
			}
		}
		private void routeSelected(object item)
		{
			try
			{
				UISession.Routeselected = true;
				Device.BeginInvokeOnMainThread (() => {
					var data = routesResponse.Where (x => x.name.Equals (item.ToString ())).ToArray ();
					if(data!=null && data.Length>0)
						UISession.routeId = data [0].id;
				});			
				isRoute = true;
				Device.BeginInvokeOnMainThread (() => {
					if(UISession.SelectedRoute!=null && UISession.SelectedRoute!=item.ToString())
					{
						UISession.SelectedRoute = item.ToString ();
						map.Pins.Clear ();
					}
					else if(string.IsNullOrEmpty(UISession.SelectedRoute))
						UISession.SelectedRoute = item.ToString ();
				});
				var routmaps = routesResponse.Where (n => n.name == item).FirstOrDefault ();
				Device.BeginInvokeOnMainThread (() => {
					stopsresponse = DependencyService.Get<IBusClient> ().GetStopsForRoute (Convert.ToInt32 (userID), routmaps.id);
					if (stopsresponse != null && stopsresponse.Count > 0) 
					{
						UISession.stopsresponse=stopsresponse;
						map.CustomPins = new List<CustomPin> ();
						for (int i = 0; i < stopsresponse.Count; i++) {
							map.CustomPins.Add (new CustomPin {
								Position = new Position (Convert.ToDouble (stopsresponse [i].lat), Convert.ToDouble (stopsresponse [i].lng)),
								Label = stopsresponse [i].name,
								PinIcon = "CarWashMapIcon"
							});
						}

						if (stopsresponse.Count > 0)
						{
							Position position = new Position(Convert.ToDouble (stopsresponse [0].lat),  Convert.ToDouble (stopsresponse [0].lng));
							var latlongdeg = 360 / (Math.Pow(2, UISession.CurrentZoomLevel-0.4));
							map.MoveToRegion(new MapSpan(position, latlongdeg, latlongdeg));
						}
					} 
					else
					{
						UISession.stopsresponse=null;
						Device.BeginInvokeOnMainThread (() => {
							DisplayAlert ("UniteGPS", "No stops for this Route", "Ok");
						});
					}
				});
			}
			catch(Exception ex)
			{
				Debug.WriteLine (ex.Message);
			}
		}

		public void ShowRouteLayout()
		{
			RoutesLayout.IsVisible = true;

			var networkConnection3 = DependencyService.Get<INetworkConnection>();
			networkConnection3.CheckNetworkConnection();
			if (networkConnection3.IsConnected)
			{
				if (userID != null)
				{
					Task.Run (() => {
						routeData();
					});
					//BeginInvokeOnMainThreadAsync (routeData);
				} 
			} 
		}
	}
}