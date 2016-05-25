using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using Xamarin;
using UniteGPS;
using UniteGPS.Android;
using Android.Locations;

[assembly: Dependency(typeof(LoginScreen))]
namespace UniteGPS.Android
{
	[Activity (Label = "UniteGPS", MainLauncher = false, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation  ,Icon="@drawable/SIimg" ,ScreenOrientation = ScreenOrientation.Portrait, Theme = "@android:style/Theme.Holo.Light")]
	public class MainActivity : AndroidActivity, IPageNavigator
	{
		LocationManager _locMgr;
		Location _currentLocation;
		protected override void OnCreate (Bundle bundle)
		{
			UISession.i = 1;
			base.OnCreate (bundle);
			Forms.Init (this, bundle);
			FormsMaps.Init (this, bundle);

			App.MainNavigator = this;

			_locMgr = Forms.Context.GetSystemService(Context.LocationService) as LocationManager;
			Criteria locationCriteria = new Criteria ();
			locationCriteria.Accuracy = Accuracy.Coarse;
			locationCriteria.PowerRequirement = Power.NoRequirement;
			string locationProvider = _locMgr.GetBestProvider (locationCriteria, true);
			Location location = _locMgr.GetLastKnownLocation (locationProvider);
			if (location != null) {
				OnLocationChanged (location);
			}

			Forms.SetTitleBarVisibility (AndroidTitleBarVisibility.Never);

			var termsflag = Devices.Storage.Get ("flag");
			var switchflag = Devices.Storage.Get ("switchon");
			if (termsflag == "0") 
			{
				string userID = Devices.Storage.Get ("UserId");
				if (switchflag == "true" && String.IsNullOrEmpty(userID) == false) 
				{
					MainMasterDetailPage home = new MainMasterDetailPage ();
					SetPage (home);
				} 
				else
				{
					LoginScreen home = new LoginScreen ();
					SetPage (home);
				}
			} 
			else 
			{
				TermsScreen home = new TermsScreen ();
				SetPage (home);
			}
		}
		protected override void OnResume ()
		{
			UISession.i = 1;
			base.OnResume ();
		}
		protected override void OnStop ()
		{
			UISession.i = 0;
			base.OnStop ();
		}
		protected override void OnPause ()
		{
			UISession.i = 0;
			base.OnPause ();
		}
		public void OnLocationChanged(Location location)
		{
			_currentLocation = location;
			if (_currentLocation == null)
			{
				Console.WriteLine( "Unable to determine your location.");
			}
			else
			{
				Console.WriteLine( (_currentLocation.Latitude).ToString()+","+( _currentLocation.Longitude).ToString());
				UISession.currentlat = _currentLocation.Latitude;
				UISession.currentlng = _currentLocation.Longitude;
			}
		}
		public override void OnBackPressed ()
		{
			MoveTaskToBack (true);
		}

		public void Logout()
		{
			LoginScreen home = new LoginScreen ();
			SetPage (home);
		}
	}
}

