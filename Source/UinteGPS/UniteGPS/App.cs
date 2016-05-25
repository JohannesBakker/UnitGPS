using System;
using Xamarin.Forms;
using System.Diagnostics;

namespace UniteGPS
{
	public class App : Application
	{
		#region PUBLIC STATIC MEMBERS
		public static IPageNavigator MainNavigator;
		#endregion

		public App ()
		{	
			var termsflag = Devices.Storage.Get ("flag");
			var switchflag = Devices.Storage.Get ("switchon");
			if (termsflag == "0")
			{
				string userID = Devices.Storage.Get ("UserId");
				if (switchflag == "true" && String.IsNullOrEmpty(userID) == false) 
				{
					MainPage = new MainMasterDetailPage ();
				} 
				else 
				{
					MainPage = new LoginScreen ();
				}
			} 
			else 
			{
				MainPage = new TermsScreen ();
			}
		}

		protected override void OnStart()
		{
			UISession.i = 1;
			Debug.WriteLine ("OnStart");
		}
		protected override void OnSleep ()
		{
			UISession.i = 0;
			Debug.WriteLine ("OnSleep");
		}
		protected override void OnResume ()
		{
			UISession.i = 0;
			Debug.WriteLine ("OnResume");
		}
	}
}

