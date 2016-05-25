using System;
using System.Collections.Generic;
using System.Linq;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

using Xamarin.Forms;
using UniteGPS;

namespace UniteGPS.iOS
{
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		UIWindow window;
		UIViewController _home;
		#pragma warning disable 162
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			try
			{
				Forms.Init ();
				Xamarin.FormsMaps.Init ();
				window = new UIWindow (UIScreen.MainScreen.Bounds);
				var networkConnection = DependencyService.Get<INetworkConnection>();
				networkConnection.CheckNetworkConnection();
				if (networkConnection.IsConnected) 
				{
					var termsflag = Devices.Storage.Get ("flag");
					var switchflag = Devices.Storage.Get ("switchon");
					if (termsflag == "0")
					{
						if (switchflag == "true")
						{
							LiveMapScreen home = new MainMasterDetailPage ();
							this._home = home.CreateViewController ();
							window.RootViewController = this._home;
						} 
						else 
						{
							LoginScreen home = new LoginScreen ();
							this._home = home.CreateViewController ();
							window.RootViewController = this._home;
						}
					}
					else 
					{
						TermsScreen home = new TermsScreen ();
						this._home = home.CreateViewController ();
						window.RootViewController = this._home;
					}
				} 
				else 
				{
					UIAlertView alert = new UIAlertView ("UniteGPS","Check your connection and try again.", null, "OK", null);
					alert.Show ();
				}
				window.MakeKeyAndVisible ();
				return true;
			}
			catch(Exception ex)
			{
				return false;
				Console.WriteLine (ex.Message);
			}
		}
	}
}

