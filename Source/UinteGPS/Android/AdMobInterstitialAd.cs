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
using UniteGPS;
using UniteGPS.Android;
using AdMobInterstitialAds.Droid;

[assembly: Xamarin.Forms.Dependency (typeof (AdMobInterstitialAd))]
namespace UniteGPS.Android
{	
	public class AdMobInterstitialAd : Java.Lang.Object, IAdMobInterstitialAd
	{
		/// <summary>
		/// Used for registration with dependency service
		/// </summary>
		public static void Init()
		{

		}

		public string UnitId { get; set; }

		public string DeviceId { get; set; }

		public bool IsAdLoaded
		{
			get
			{
				if (FinalAd != null)
				{
					return FinalAd.IsLoaded;
				}
				else
				{
					return false;
				}
			}
		}

		public static InterstitialAd FinalAd{ get; private set; }

		public event EventHandler InterstitialAdLoaded;
		public void LoadAd()
		{
			FinalAd = ConstructFullPageAdd(Forms.Context, UnitId);
			var intlistener = new AdMobInterstitialAdListener();
			intlistener.AdLoaded += () => {
				if (FinalAd.IsLoaded)
				{
					if(InterstitialAdLoaded != null)
						InterstitialAdLoaded(null,null);
				}
			};
			intlistener.AdClosed += () =>
			{
				LoadAd();
			};
			FinalAd.AdListener = intlistener;
			CustomBuild(FinalAd);
		}
		public void Show()
		{
			//Forms.Context.StartActivity(typeof(AdMobInterstitialActivity));

		}
		public InterstitialAd ConstructFullPageAdd(Context con, string UnitID)
		{
			var ad = new InterstitialAd(con);
			ad.AdUnitId = UnitID;
			return ad;
		}
		public InterstitialAd CustomBuild(InterstitialAd ad)
		{
			var requestbuilder = new AdRequest.Builder ();
			if (DeviceId != "")
				requestbuilder = requestbuilder.AddTestDevice (AdRequest.DeviceIdEmulator).AddTestDevice (DeviceId);
			//	var requestbuilder = new AdRequest.Builder().AddTestDevice(AdRequest.DeviceIdEmulator).AddTestDevice("1423F3A29B67BDA144473E14709997B3");
			ad.LoadAd(requestbuilder.Build());
			return ad;
		}
	}
}

