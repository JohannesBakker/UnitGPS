using System;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using System.Collections.Generic;
using System.Linq;

namespace UniteGPS
{
	public class ETAScreen : ContentPage
	{
		Map map;
		public static bool isRoute = true;
		public static bool isStop = true;
		public static bool isETA=true;
		List<RoutesResponse> routesResponse;
		List<StopsForRouteResponse> stopsresponse;
		#pragma warning disable 253
		public ETAScreen ()
		{
			this.BackgroundColor = Color.White;
			map = new Map { 
				IsShowingUser = true,
				WidthRequest = 960,
				HeightRequest = 100,
			};
			// You can use MapSpan.FromCenterAndRadius 
			map.MoveToRegion (MapSpan.FromCenterAndRadius (
				new Position (17.5165141245552,78.3975195345906 ), Distance.FromMiles (0.7)));
				
			var imgroute = new Image {
				Aspect = Aspect.AspectFill,
				HorizontalOptions = LayoutOptions.Start,
				WidthRequest =  40,
				HeightRequest = 40,
			};
			imgroute.Source = ImageSource.FromFile ("Images/Routesimg.png");
			var imgStop = new Image {
				Aspect = Aspect.Fill,
				HorizontalOptions = LayoutOptions.Center,
				WidthRequest =  40,
				HeightRequest = 40 
			};
			imgStop.Source = ImageSource.FromFile ("Images/Stops.png");
			var imgETA = new Image {
				Aspect = Aspect.Fill,
				WidthRequest =  40,
				HeightRequest = 40 
			};
			imgETA.Source = ImageSource.FromFile ("Images/eta1.png");
			var lblroute = new Label {
				Text = "Routes",
				TextColor = Color.Black,
				BackgroundColor = Color.White,
				FontAttributes = FontAttributes.Bold,
				FontSize = Device.GetNamedSize (NamedSize.Small, typeof(Label)),
			};
			var lblStop = new Label {
				Text = "Stops",
				TextColor = Color.Black,
				BackgroundColor = Color.White,
				FontAttributes = FontAttributes.Bold,
				FontSize = Device.GetNamedSize (NamedSize.Small, typeof(Label)),
			};
			var lbleta = new Label {
				Text = "ETA",
				TextColor = Color.Black,
				BackgroundColor = Color.White,
				FontAttributes = FontAttributes.Bold,
				FontSize = Device.GetNamedSize (NamedSize.Small, typeof(Label)),
			};


			//Activity Indicator
			ActivityIndicator activityIndicator = new ActivityIndicator
			{
				Color = Device.OnPlatform(Color.Black, Color.Default, Color.Default),
				IsRunning = true,
				VerticalOptions = LayoutOptions.CenterAndExpand
			};
			activityIndicator.IsVisible = false;

			//Ads
			AdsView ads = new AdsView ();

			//Routes List
			var label1 = new Label {
				BackgroundColor = Color.Black, 
				HeightRequest = 30,
				WidthRequest = 180,
				Text = "Choose a location",
				XAlign= TextAlignment.Center,
				YAlign=TextAlignment.Center,
				TextColor = Color.White,
				FontAttributes = FontAttributes.Bold,
				FontSize = Device.GetNamedSize (NamedSize.Small, typeof(Label)),
			};
			var imgChoose = new Image {
				Aspect = Aspect.AspectFit,
				HeightRequest=20,
				WidthRequest = 20
			};
			imgChoose.Source = ImageSource.FromFile ("Images/Arrowimg.png");
			var routesList = new ListView
			{  
				BackgroundColor = Color.White,
				HeightRequest = 240,
				WidthRequest = 180,
				RowHeight = 47,
			};
			var stopsList = new ListView
			{  
				BackgroundColor = Color.White,
				HeightRequest = 240,
				WidthRequest = 180,
				RowHeight = 50,
			};
			var userID = Devices.Storage.Get ("UserId");
			routesResponse = DependencyService.Get<IBusClient>().GetRoutes(int.Parse(userID));
			if (routesResponse.Count > 0) {
				string[] listviewitems = routesResponse.Select (n => n.name).ToArray ();
				routesList.ItemsSource = listviewitems;

				var routmaps = routesResponse.Where(n =>n.name == listviewitems[0]).FirstOrDefault();
				var maps = routmaps.routePoints;//latitude and longitude
				for (int i = 0; i < maps.Count; i++) {
					var map1 = maps [i];
					var lng = Convert.ToDouble (map1.lng);
					var lat = Convert.ToDouble (map1.lat);

					map.Pins.Add (new Pin {
						Position = new Position (lat, lng),
						Label = routmaps.name
					});
				}
				stopsresponse = DependencyService.Get<IBusClient>().GetStopsForRoute(Convert.ToInt32(userID),routmaps.id);  // routmaps.id replace with 5032

				if (stopsresponse != null && stopsresponse.Count > 0) {
					var stopsnames = stopsresponse.Select (stop => stop.name).ToArray ();
					stopsList.ItemsSource = stopsnames;
				}
			}

			var RoutesLayout = new AbsoluteLayout ();
			RoutesLayout.Children.Add (label1, new Point (0,0));
			RoutesLayout.Children.Add (imgChoose,new Point (10,5));
			RoutesLayout.Children.Add (routesList,new Point(0,30));

			routesList.ItemTemplate  = new DataTemplate(typeof(RoutesListView));
			routesList.ItemTapped += (sender, e) => {
				RoutesLayout.IsVisible = false;
				var routmaps = routesResponse.Where(n =>n.name == e.Item).FirstOrDefault();
				var maps = routmaps.routePoints; //latitude and longitude
				for (int i = 0; i < maps.Count; i++) {
					var map1 = maps[i];
					var lng = Convert.ToDouble(map1.lng);
					var lat = Convert.ToDouble(map1.lat);
					map.Pins.Add(new Pin {
						Position = new Position(lat,lng),
						Label =routmaps.name
					});
					map.MoveToRegion (MapSpan.FromCenterAndRadius (
						new Position (lat,lng), Distance.FromMiles (0.3)));
					stopsresponse = DependencyService.Get<IBusClient> ().GetStopsForRoute (Convert.ToInt32(userID) , routmaps.id);

					if (stopsresponse != null && stopsresponse.Count > 0) {
						var stopsnames = stopsresponse.Select (stop => stop.name).ToArray ();
						stopsList.ItemsSource = stopsnames;
					}
					else 
						stopsList.ItemsSource = null;
				}
			};

			//Stops List
			var Choose1 = new Label {
				BackgroundColor = Color.Black, 
				HeightRequest = 30,
				WidthRequest = 180,
				Text = "Choose a Stop",
				XAlign= TextAlignment.Center,
				YAlign=TextAlignment.Center,
				TextColor = Color.White,
				FontAttributes = FontAttributes.Bold,
				FontSize = Device.GetNamedSize (NamedSize.Small, typeof(Label)),
			};
			var imgChoosestop = new Image {
				Aspect = Aspect.AspectFit,
				HeightRequest=20,
				WidthRequest = 20
			};
			imgChoosestop.Source = ImageSource.FromFile ("Images/Arrowimg.png");

			var StopsLayout = new AbsoluteLayout ();
			StopsLayout.Children.Add (stopsList, new Point (0,30));
			StopsLayout.Children.Add (Choose1, new Point (0,0));
			StopsLayout.Children.Add (imgChoosestop, new Point (10,5));

//			stopsList.ItemTemplate  = new DataTemplate(typeof(ScrollViewDemoPage));
			stopsList.ItemTapped += (sender, e) => {
				map.Pins.Clear();
				StopsLayout.IsVisible = false;
				var routestrops = stopsresponse.Where(rs => rs.name == e.Item).FirstOrDefault();
				var lng = Convert.ToDouble(routestrops.lng);
				var lat = Convert.ToDouble(routestrops.lat);

				map.Pins.Add(new Pin {
					Type = PinType.Generic,
					Position = new Position(lat,lng),
					Label = routestrops.name
				});
				map.MoveToRegion (MapSpan.FromCenterAndRadius (
					new Position (lat,lng), Distance.FromMiles (0.3)));
			};

			//ETA Part
			var labETATime = new Label {
				BackgroundColor= Color.White,
				Text="ETA 20 minutes",
				FontAttributes = FontAttributes.Bold,
				FontSize = Device.GetNamedSize (NamedSize.Small, typeof(Label)),
				TextColor= Color.Black,
			};
			var labOntime = new Label {
				BackgroundColor = Color.Green,
				Text="ONTIME",
				FontAttributes = FontAttributes.Bold,
				FontSize = Device.GetNamedSize (NamedSize.Small, typeof(Label)),
				TextColor=Color.Black,
			};
			var labTimedis = new Label {
				Text ="7.30 AM",
				HorizontalOptions=LayoutOptions.End,
				FontAttributes = FontAttributes.Bold,
				FontSize = Device.GetNamedSize (NamedSize.Small, typeof(Label)),
				TextColor=Color.Black
			};
			var labRoute = new Label {
				Text ="Route:",
				FontAttributes = FontAttributes.Bold,
				FontSize = Device.GetNamedSize (NamedSize.Small, typeof(Label)),
				TextColor = Color.Black,
				IsEnabled = false
			};
			var labRoutename = new Label {
				Text = "Goffs Falls Road",
				TextColor = Color.Black,
				FontAttributes = FontAttributes.Bold,
				FontSize = Device.GetNamedSize (NamedSize.Small, typeof(Label)),
			};
			var labSchedule = new Label {
				Text="Scheduled",
				TextColor = Color.Black,
				FontAttributes = FontAttributes.Bold,
				FontSize = Device.GetNamedSize (NamedSize.Small, typeof(Label)),
			};
			var labActual = new  Label{
				Text="Actual",
				TextColor= Color.Black,
				FontAttributes = FontAttributes.Bold,
				FontSize = Device.GetNamedSize (NamedSize.Small, typeof(Label)),
			};
			var labDeparture = new Label {
				Text ="Departure",
				TextColor = Color.Black,
				FontAttributes = FontAttributes.Bold,
				FontSize = Device.GetNamedSize (NamedSize.Small, typeof(Label)),
			};
			var labscheduledeptime = new Label {
				Text="7.30 AM",
				TextColor=Color.Black,
				FontAttributes = FontAttributes.Bold,
				FontSize = Device.GetNamedSize (NamedSize.Small, typeof(Label)),
			};
			var labActualdeptime = new Label {
				Text="7.20 PM",
				TextColor= Color.Black,
				FontAttributes = FontAttributes.Bold,
				FontSize = Device.GetNamedSize (NamedSize.Small, typeof(Label)),
			};
			var labaddtime = new Label {
				Text="+3",
				TextColor= Color.Black,
				FontAttributes = FontAttributes.Bold,
				FontSize = Device.GetNamedSize (NamedSize.Small, typeof(Label)),
			};
			var labMystop = new Label {
				Text="My Stop",
				FontAttributes = FontAttributes.Bold,
				FontSize = Device.GetNamedSize (NamedSize.Small, typeof(Label)),
				TextColor=Color.Black,
			};
			var labschedulemystoptime = new Label {
				Text="7.60 AM",
				TextColor=Color.Black,
				FontAttributes = FontAttributes.Bold,
				FontSize = Device.GetNamedSize (NamedSize.Small, typeof(Label)),
			};

			var labscheduleactualtime = new Label {
				Text="8.40 AM",
				TextColor=Color.Black,
				FontAttributes = FontAttributes.Bold,
				FontSize = Device.GetNamedSize (NamedSize.Small, typeof(Label)),
			};
			var labArrival = new Label {
				Text="Arrival",
				TextColor=Color.Black,
				FontAttributes = FontAttributes.Bold,
				FontSize = Device.GetNamedSize (NamedSize.Small, typeof(Label)),
			};
			var labschedulearrivaltime = new Label {
				Text=" 9.00 AM",
				TextColor=Color.Black,
				FontAttributes = FontAttributes.Bold,
				FontSize = Device.GetNamedSize (NamedSize.Small, typeof(Label)),
			};
			var  ETApart1 = new StackLayout
			{
				Spacing = 10,
				Padding = new Thickness(15,20,15,0),
				VerticalOptions = LayoutOptions.Start,
				Orientation = StackOrientation.Horizontal,
				HorizontalOptions = LayoutOptions.Start,
				Children = {labETATime,labOntime ,labTimedis }
			};
			var  ETApart2 = new StackLayout
			{
				Spacing = 10,
				Padding = new Thickness(15,0,0,0),
				VerticalOptions = LayoutOptions.Start,
				Orientation = StackOrientation.Horizontal,
				HorizontalOptions = LayoutOptions.Start,
				Children = {labRoute,labRoutename  }
			};
			var  ETApart3 = new StackLayout
			{
				Spacing = 30,
				Padding = new Thickness(100,0,0,0),
				VerticalOptions = LayoutOptions.End,
				Orientation = StackOrientation.Horizontal,
				HorizontalOptions = LayoutOptions.Start,
				Children = { labSchedule,labActual }
			};
			var  ETApart4 = new StackLayout
			{
				Spacing = 30,
				Padding = new Thickness(15,0,20,0),
				VerticalOptions = LayoutOptions.Start,
				Orientation = StackOrientation.Horizontal,
				HorizontalOptions = LayoutOptions.Start,
				Children = { labDeparture, labscheduledeptime,labActualdeptime,labaddtime}
			};
			var  ETApart5 = new StackLayout
			{
				Spacing = 35,
				Padding = new Thickness(15,0,10,0),
				VerticalOptions = LayoutOptions.Start,
				Orientation = StackOrientation.Horizontal,
				HorizontalOptions = LayoutOptions.Start,
				Children = { labMystop, labschedulemystoptime,labscheduleactualtime}
			};
			var  ETApart6 = new StackLayout
			{
				Spacing = 45,
				Padding = new Thickness(15,0,0,0),
				VerticalOptions = LayoutOptions.Start,
				Orientation = StackOrientation.Horizontal,
				HorizontalOptions = LayoutOptions.Start,
				Children = { labArrival, labschedulearrivaltime}
			};
			var ETAbelowpart = new StackLayout 
			{
				BackgroundColor = Color.White,
				Padding = new Thickness(0,0,0,0),
				WidthRequest=320,	
				Children={
					ETApart1,
					ETApart2,
					ETApart3,
					ETApart4,
					ETApart5,
					ETApart6
				}
			};

			RelativeLayout l = new RelativeLayout { };

			l.Children.Add (map, 
				xConstraint: Constraint.Constant(0), 
				yConstraint: Constraint.Constant(90), 
				widthConstraint: Constraint.RelativeToParent ((parent) => {return parent.Width;}),
				heightConstraint: Constraint.RelativeToParent ((parent) => {return parent.Height;}));
				
			l.Children.Add (RoutesLayout, Constraint.RelativeToParent ((parent) => {
				return 0;
			}),
				Constraint.RelativeToParent ((parent) => {
					return +90;
				}));

			l.Children.Add (StopsLayout, Constraint.RelativeToParent ((parent) => {
				return 0;
			}),
				Constraint.RelativeToParent ((parent) => {
					return +90;
				}));

			l.Children.Add (ETAbelowpart, Constraint.RelativeToParent ((parent) => {
				return 0;
			}),
				Constraint.RelativeToParent ((parent) => {
					return +90;
				}));

			l.Children.Add (ads, Constraint.RelativeToParent ((parent) => {
				return 0;
			}),
				Constraint.RelativeToParent ((parent) => {
					return parent.Height -50 ;
				}));
			l.Children.Add (imgroute, Constraint.RelativeToParent ((parent) => {
				return parent.Width/12;
			}),
				Constraint.RelativeToParent ((parent) => {
					return +20;
				}));

			l.Children.Add (imgStop, Constraint.RelativeToParent ((parent) => {
				return parent.Width/2.2;
			}),
				Constraint.RelativeToParent ((parent) => {
					return +20;
				}));

			l.Children.Add (imgETA, Constraint.RelativeToParent ((parent) => {
				return parent.Width/1.22;
			}),
				Constraint.RelativeToParent ((parent) => {
					return +20;
				}));

			l.Children.Add (lblroute, Constraint.RelativeToParent ((parent) => {
				return parent.Width/12;
			}),
				Constraint.RelativeToParent ((parent) => {
					return +70;
				}));

			l.Children.Add (lblStop, Constraint.RelativeToParent ((parent) => {
				return parent.Width/2.2;
			}),
				Constraint.RelativeToParent ((parent) => {
					return +70;
				}));

			l.Children.Add (lbleta, Constraint.RelativeToParent ((parent) => {
				return parent.Width/1.22;
			}),
				Constraint.RelativeToParent ((parent) => {
					return +70;
				}));

			this.Content = l;

			//TapGesture for Routes
			RoutesLayout.IsVisible = false;
			var tapGestureRecognizer1 = new TapGestureRecognizer();
			tapGestureRecognizer1.Tapped += (s, e) =>{
				if(!isRoute){
					RoutesLayout.HeightRequest = 0;
					RoutesLayout.WidthRequest = 0;
				}
				else{
					RoutesLayout.HeightRequest = 400;
					RoutesLayout.WidthRequest = 200;
				}
				if (isRoute) {
					isRoute = false;
					isStop=true;
					isETA = true;
					RoutesLayout.IsVisible = true;
					StopsLayout.IsVisible = false;
					ETAbelowpart.IsVisible = false;
				}  
				else {
					isRoute = true;
					RoutesLayout.IsVisible = false;
				}
			};
			imgroute.GestureRecognizers.Add(tapGestureRecognizer1);

			//TapGesture for Stops
			StopsLayout.IsVisible = false;
			var tapGestureRecognizer2 = new TapGestureRecognizer();
			tapGestureRecognizer2.Tapped += (s, e) =>
			{
				if(!isStop)
				{
					StopsLayout.HeightRequest = 0;
					StopsLayout.WidthRequest = 0;
				}
				else
				{
					StopsLayout.HeightRequest = 400;
					StopsLayout.WidthRequest = 200;
				}
				if (isStop) {
					isStop = false;
					isRoute=true;
					isETA = true;
					RoutesLayout.IsVisible = false;
					StopsLayout.IsVisible = true;
					ETAbelowpart.IsVisible = false;
				}  
				else {
					isStop = true;
					StopsLayout.IsVisible = false;
				}

			};
			imgStop.GestureRecognizers.Add(tapGestureRecognizer2);

			//TapGesture for ETA
			ETAbelowpart.IsVisible = false;
			var tapGestureRecognizer4 = new TapGestureRecognizer();
			tapGestureRecognizer4.Tapped += (s, e) =>
			{
				if(isETA){
					isETA=false;
					isRoute = true;
					isStop= true;
					ETAbelowpart.IsVisible = true;
					RoutesLayout.IsVisible = false;
					StopsLayout.IsVisible = false;
				}
				else
				{
					isETA=true;
					ETAbelowpart.IsVisible = false;
				}
//				Navigation.PushModalAsync(new LoginScreen());
			};
			imgETA.GestureRecognizers.Add(tapGestureRecognizer4);
		}
	}
}

