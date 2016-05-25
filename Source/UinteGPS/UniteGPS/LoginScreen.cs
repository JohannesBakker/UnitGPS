using System;
using System.Net;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.ServiceModel;
using System.ServiceModel.Channels;
using Newtonsoft.Json;
using System.Threading;

namespace UniteGPS
{
	public class LoginScreen : ContentPage
	{ 
		public static readonly EndpointAddress EndPoint = new EndpointAddress("http://dev-ws.unitegps.com/dev-UniteGPSBusService/BusService.svc/basic");
		public static bool isclick;
		Switch switcher;
		ActivityIndicator activityIndicator; 
		Entry entryUser;
		Entry entryPassword;
		public LoginScreen()
		{
			var networkConnection3 = DependencyService.Get<INetworkConnection>();
			networkConnection3.CheckNetworkConnection();
			if (networkConnection3.IsConnected) 
			{
				//DependencyService.Get<IAdMobInterstitialAd> ().UnitId = "ca-app-pub-2398347475015144/4185449111";
				//DependencyService.Get<IAdMobInterstitialAd> ().DeviceId = "1423F3A29B67BDA144473E14709997B3";
				//DependencyService.Get<IAdMobInterstitialAd> ().LoadAd ();

				this.BackgroundColor = Color.FromRgb(0x0, 0x71, 0xd1);

				Label lblempty = new Label
				{
					BackgroundColor = Color.Transparent,
					WidthRequest = 320,
					HeightRequest = 50,
					HorizontalOptions = LayoutOptions.Start,
					VerticalOptions = LayoutOptions.Start
				};

				Label lblempty1 = new Label 
				{
					BackgroundColor = Color.Transparent,
					WidthRequest = 320,
					HeightRequest = 10,
					HorizontalOptions = LayoutOptions.Start,
					VerticalOptions = LayoutOptions.Start
				};

				Label lblempty2 = new Label 
				{
					BackgroundColor = Color.Transparent,
					WidthRequest = 320,
					HeightRequest = 15,
					HorizontalOptions = LayoutOptions.Start,
					VerticalOptions = LayoutOptions.Start,
				};

				var imgUniteGPS = new Image 
				{
					Aspect = Aspect.AspectFit,
					//WidthRequest = 200,
					HeightRequest = 100,
					HorizontalOptions = LayoutOptions.FillAndExpand,
					VerticalOptions = LayoutOptions.Start
				};
				imgUniteGPS.Source = ImageSource.FromFile ("Images/UinteGps.png");

				entryUser = new MyEntry 
				{
					Placeholder = "Username",
					TextColor = Color.Black,
					BackgroundColor = Color.Transparent,
					WidthRequest = 295,
					HeightRequest = 30,
				};
				/*
				var imguser = new Image 
				{
					Aspect = Aspect.Fill,
					WidthRequest = 295,
					HeightRequest = 5,
					HorizontalOptions = LayoutOptions.CenterAndExpand,
					VerticalOptions = LayoutOptions.Start
				};
				imguser.Source = ImageSource.FromFile ("Images/xeZOp85EgAhV.png");*/

				entryPassword = new MyEntry 
				{
					Placeholder = "Password",
					TextColor = Color.Black,
					BackgroundColor = Color.Transparent,
					WidthRequest = 295,
					HeightRequest = 30,
					IsPassword = true
				};

				/*
				var imgpwd = new Image 
				{
					Aspect = Aspect.Fill,
					WidthRequest = 295,
					HeightRequest = 5,
					HorizontalOptions = LayoutOptions.CenterAndExpand,
					VerticalOptions = LayoutOptions.Start
				};
				imgpwd.Source = ImageSource.FromFile ("Images/xeZOp85EgAhV.png");*/

				switcher = new Switch 
				{
					HorizontalOptions = LayoutOptions.End,
					IsToggled = true,
				};

				var username = Devices.Storage.Get ("username");
				var pwd = Devices.Storage.Get ("password");
				var switchenable = Devices.Storage.Get ("switchon");
				switchenable = "true";

				if (switchenable == "true") 
				{
					Devices.Storage.Set ("switchon", "true");
					entryUser.Text = username;
					entryPassword.Text = pwd;
					switcher.IsToggled = true;
				} 
				else
				{
					Devices.Storage.Set ("switchon", "false");
					entryUser.Text = string.Empty;
					entryPassword.Text = string.Empty;
					switcher.IsToggled = false;
				}

				var labellslogin = new Label
				{
					Text = "Please Login",
					XAlign = TextAlignment.Center,
					YAlign = TextAlignment.Center,
					TextColor = Color.White,
					BackgroundColor = Color.Accent,
					FontAttributes = FontAttributes.Bold,
					FontSize = Device.GetNamedSize (NamedSize.Small, typeof(Label)),
					WidthRequest = 320,
					HeightRequest = 40
				};

				var lbllogin = new Label 
				{
					Text = "Login",
					TextColor = Color.White,
					XAlign = TextAlignment.Center,
					YAlign = TextAlignment.Center,
					BackgroundColor = Color.Accent,
					FontAttributes = FontAttributes.Bold,
					FontSize = Device.GetNamedSize (NamedSize.Medium, typeof(Label)),
					WidthRequest = 295,
					HeightRequest = 40
				};

				var labelUnit = new Label 
				{
					XAlign = TextAlignment.Center,
					TextColor = Color.White,
					BackgroundColor = Color.Transparent,
					FontAttributes = FontAttributes.Bold,
					FontSize = Device.GetNamedSize (NamedSize.Medium, typeof(Label)),
					WidthRequest = 100,
					HeightRequest = 30
				};
				String date = DateTime.Now.Year.ToString (); 
				labelUnit.Text = "©"+ " "+date+ " "+"UniteGPS";

				var labRemember = new Label 
				{
					Text = "Remember me",
					TextColor = Color.Black,
					XAlign = TextAlignment.Center,
					YAlign = TextAlignment.Center,
					BackgroundColor = Color.White,
					HorizontalOptions = LayoutOptions.CenterAndExpand,
					VerticalOptions = LayoutOptions.CenterAndExpand
				};

				activityIndicator = new ActivityIndicator 
				{
					Color = Device.OnPlatform (Color.Black, Color.Black, Color.Default),
					IsRunning = false,
					WidthRequest = 30,
					HeightRequest = 30,
					HorizontalOptions = LayoutOptions.CenterAndExpand
				};

				var usercontent = new StackLayout 
				{
					Spacing = 5,
					Padding = 10,
					Orientation = StackOrientation.Horizontal,
					BackgroundColor = Color.White,
					Children = {
						new Image{
							Aspect = Aspect.AspectFit,
							WidthRequest = 30,
							HeightRequest = 30,
							Source = ImageSource.FromFile("Images/login_email.png"),
						},
						entryUser/*,imguser*/
					}
				};

				var pwdcontent = new StackLayout 
				{
					Spacing = 5,
					Padding = 10,
					Orientation = StackOrientation.Horizontal,
					BackgroundColor = Color.White,
					Children = {
						new Image{
							Aspect = Aspect.AspectFit,
							WidthRequest = 30,
							HeightRequest = 30,
							Source = ImageSource.FromFile("Images/signin_password.png"),
						},
						entryPassword/*,imgpwd*/
					}
				};

				var userInfoStack = new StackLayout {
					BackgroundColor = Color.White,
					Padding = 0,
					Spacing = 0,
					Children = {
						usercontent,
						pwdcontent,
					}
				};
				/*
				var Swithpart = new StackLayout
				{
					VerticalOptions = LayoutOptions.End,
					Orientation = StackOrientation.Horizontal,
					HorizontalOptions = LayoutOptions.Start,
					Spacing = 15,
					Padding = new Thickness (80, 15, 0, 15),
					Children = { labRemember, switcher },
				};*/

				var loginpart = new StackLayout 
				{
					Spacing = 10,
					Padding = new Thickness (15, 15, 15, 15),
					Children = {imgUniteGPS,lblempty1,
						/*labellslogin,*/userInfoStack,
						lblempty2,lbllogin,/*Swithpart,*/
						activityIndicator,labelUnit},
				};

				var scrollView = new ScrollView 
				{
					HorizontalOptions = LayoutOptions.Fill,
					Orientation = ScrollOrientation.Vertical,
					Content = new StackLayout 
					{
						Children = {loginpart},
					}
				};

				Content = new StackLayout 
				{
					Children = {lblempty,scrollView}
				};

				entryPassword.Completed += delegate 
				{
					entryPassword.Unfocus();
					activityIndicator.IsRunning=true;
					Task.Factory.StartNew (()=>
						{
							login();
						}).ContinueWith ( 
							t => {
								activityIndicator.IsRunning=false;
							}, TaskScheduler.FromCurrentSynchronizationContext()
						);
				};

				var tapGestureRecognizer = new TapGestureRecognizer ();
				tapGestureRecognizer.Tapped += (s, e) => 
				{
					activityIndicator.IsRunning=true;
					Task.Factory.StartNew (()=>
						{
							login();
						}).ContinueWith ( 
							t => {
								activityIndicator.IsRunning=false;
							}, TaskScheduler.FromCurrentSynchronizationContext()
						);
				};
				lbllogin.GestureRecognizers.Add (tapGestureRecognizer);
			} 
			else 
			{
				DisplayAlert ("UniteGPS", "Please check your network and try again", "Ok");
			}
		}
		public  bool IsValidEmail(string s)
		{
			var regex = new Regex (@"^(?=.*[A-Za-z0-9])[A-Za-z0-9, .!@#$%^&*()_]{6,50}$");
			return regex.IsMatch (s);
		}

		public  bool IsValidPassword( string t)
		{
			var regex1 = new Regex(@"^(?=.*[A-Za-z0-9.!@#$%^&*()_])[A-Za-z0-9, .!@#$%^&*()_]{6,25}$");
			return regex1.IsMatch(t);
		}
		private void shoWAdd()
		{
			//if (DependencyService.Get<IAdMobInterstitialAd> ().IsAdLoaded) 
			//	DependencyService.Get<IAdMobInterstitialAd> ().Show ();
		}

		public void login()
		{
			try {
				activityIndicator.IsRunning = true;
				var networkConnection = DependencyService.Get<INetworkConnection> ();
				networkConnection.CheckNetworkConnection ();
				if (networkConnection.IsConnected) {
					//activityIndicator.IsRunning = true;
					UISession.Adddismis = false;
					if (entryUser.Text == null || entryUser.Text == string.Empty) {
						Device.BeginInvokeOnMainThread (() => {
							DisplayAlert ("UniteGPS", "Username cannot be empty ", null, "OK");
							activityIndicator.IsRunning = false;
						});
					} else if (entryPassword.Text == null || entryPassword.Text == string.Empty) {
						Device.BeginInvokeOnMainThread (() => {
							DisplayAlert ("UniteGPS", "Password cannot be empty ", null, "OK");
							activityIndicator.IsRunning = false;
						});

					} else if (entryUser.Text != "" && entryPassword.Text != "") {
						bool isValidEmail = IsValidEmail (entryUser.Text);
						bool isValidPassword = IsValidPassword (entryPassword.Text);
						if (!isValidEmail) {
							Device.BeginInvokeOnMainThread (() => {
								DisplayAlert ("UniteGPS", "Username should be between 6-25 characters", null, "Ok");
								activityIndicator.IsRunning = false;
							});
						} else if (!isValidPassword) {
							Device.BeginInvokeOnMainThread (() => {
								DisplayAlert ("UniteGPS", "Password should be between 6-25 characters", null, "Ok");
								activityIndicator.IsRunning = false;
							});

						} else {
							if (switcher.IsToggled == true) {
								//activityIndicator.IsRunning = true;
								Devices.Storage.Set ("username", entryUser.Text);
								Devices.Storage.Set ("password", entryPassword.Text);
								Devices.Storage.Set ("switchon", "true");
								switcher.IsToggled = true;
								// Calling Service
								var responce = DependencyService.Get<IBusClient> ().LogOnParent (entryUser.Text, entryPassword.Text);
								if (responce != "[]" && responce != "" && responce != null) {
									var obj = JsonConvert.DeserializeObject<LoginResponse> (responce);
									Devices.Storage.Set ("UserId", obj.userId.ToString ());
									var userID = Devices.Storage.Get ("UserId");
									if (Device.OS == TargetPlatform.Android) {										
										BeginInvokeOnMainThreadAsync (shoWAdd);										
										Device.BeginInvokeOnMainThread (() => {
											Navigation.PushModalAsync (new MainMasterDetailPage ());
										});	
									} else if (Device.OS == TargetPlatform.iOS) {
										//										BeginInvokeOnMainThreadAsync (shoWAdd);	
										Device.BeginInvokeOnMainThread (() => {
											activityIndicator.IsRunning=true;
											Navigation.PushModalAsync (new MainMasterDetailPage ());
										});	
									}
								} else {
									activityIndicator.IsRunning = false;
									Device.BeginInvokeOnMainThread (() => {
										DisplayAlert ("UniteGPS", "Invalid Credentials", null, "Ok");
									});
								}
							} 
							else {
								Devices.Storage.Set ("username", string.Empty);
								Devices.Storage.Set ("password", string.Empty);
								Devices.Storage.Set ("switchon", "false");
								switcher.IsToggled = false;
								var responce = DependencyService.Get<IBusClient> ().LogOnParent (entryUser.Text, entryPassword.Text);
								if (responce != "[]" && responce != "" && responce != null) {
									var obj = JsonConvert.DeserializeObject<LoginResponse> (responce);
									Devices.Storage.Set ("UserId", obj.userId.ToString ());
									var userID = Devices.Storage.Get ("UserId");
									if (Device.OS == TargetPlatform.Android) {
										BeginInvokeOnMainThreadAsync (shoWAdd);
										Device.BeginInvokeOnMainThread (() => {
											Navigation.PushModalAsync (new MainMasterDetailPage ());
										});									
									} else if (Device.OS == TargetPlatform.iOS) {
										//										BeginInvokeOnMainThreadAsync (shoWAdd);	
										Device.BeginInvokeOnMainThread (() => {
											activityIndicator.IsRunning=true;
											Navigation.PushModalAsync (new MainMasterDetailPage ());
										});	
									}
								} else {
									Device.BeginInvokeOnMainThread (() => {
										activityIndicator.IsRunning = false;
										DisplayAlert ("UniteGPS", "Invalid Credentials", null, "Ok");
									});								
								}
							}
						}
					}
				} else {
					Device.BeginInvokeOnMainThread (() => {
						DisplayAlert ("UniteGPS", "Please check your network and try again ", null, "OK");
					});

				}
			} catch (Exception ex) {
				string exception = ex.Message;
			}
		}
		public Task BeginInvokeOnMainThreadAsync(Action action)
		{
			TaskCompletionSource<object> tcs = new TaskCompletionSource<object>();
			Device.BeginInvokeOnMainThread(() =>
				{
					try
					{
						activityIndicator.IsRunning=true;
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
		protected override void OnAppearing ()
		{
			base.OnAppearing ();
			if (Device.OS == TargetPlatform.iOS) {
				if (UISession.Adddismis == false) {
					UISession.Adddismis = true;
					Navigation.PushModalAsync (new MainMasterDetailPage ());
				}
			}
		}
	}
}