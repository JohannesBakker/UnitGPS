
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Gms.Ads;
using Xamarin.Forms;
using UniteGPS.Android;
using AdMobInterstitialAds.Droid;

namespace UniteGPS.Android
{
	[Activity (Label = "AdMobInterstitialActivity")]
	public class AdMobInterstitialActivity :Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			if (AdMobInterstitialAd.FinalAd.IsLoaded) {
				var adlistener = AdMobInterstitialAd.FinalAd.AdListener as AdMobInterstitialAdListener;
				adlistener.AdClosed += () => Finish();
				AdMobInterstitialAd.FinalAd.Show ();
			}
			else
				Finish ();
		}
	}
}


