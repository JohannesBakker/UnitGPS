using System;
using Android.App;
using Android.OS;
using System.Threading;
//using Xamarin.Forms;
using Android.Content;
using System.Threading.Tasks;

namespace UniteGPS.Android
{
	[Activity(Label="UniteGPS",Theme = "@style/Theme.Splash",MainLauncher=true,NoHistory=true,Icon="@drawable/SIimg")]
	public class SplashActivity : Activity
	{
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView (Resource.Layout.Splash);

			new Task (() => {
				Thread.Sleep (180);
				RunOnUiThread(() => {
					StartActivity (typeof(MainActivity));
				});
			}).Start();
		}
	}
}

