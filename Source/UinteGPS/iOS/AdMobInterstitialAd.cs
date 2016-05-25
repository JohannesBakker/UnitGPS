using System;
using GoogleAdMobAds;
using Xamarin.Forms;
using AdMobInterstitialAds.iOS;
using MonoTouch.UIKit;
using UniteGPS;

[assembly: Xamarin.Forms.Dependency (typeof (AdMobInterstitialAd))]
namespace AdMobInterstitialAds.iOS
{
	#pragma warning disable 169
    public class AdMobInterstitialAd : IAdMobInterstitialAd
    {
		#region IAdMobInterstitialAd implementation
		public event EventHandler InterstitialAdLoaded;
		UIWindow window;
		public void Show()
		{
			try
			{
				UIWindow window = new UIWindow ();
				UIViewController viewController = new UIViewController ();
				window = UIApplication.SharedApplication.KeyWindow;
				viewController = window.RootViewController;
				ShowInterstitialIfReady(viewController);
			}
			catch(Exception ex)
			{
				Console.WriteLine (ex.Message);
			}
		}
//		public void Show()
//		{
//			window = UIApplication.SharedApplication.KeyWindow;
//			//window = new UIWindow ();
//			//window.RootViewController = new UIViewController ();
//			UIViewController viewController = window.RootViewController;
//			viewController = window.RootViewController;
//			ShowInterstitialIfReady(viewController);
//			//window.MakeKeyAndVisible();
//		}
		public static GADInterstitial FinalAd{ get; private set; }

		public void LoadAd()
		{
			InitInterstitial(UnitId);
			FinalAd.DidReceiveAd += (sender, e) => 
			{
				if (FinalAd.IsReady)
				{
					if(InterstitialAdLoaded != null)
						InterstitialAdLoaded(null,null);
				}

			};
			FinalAd.DidDismissScreen += (sender, e) => {
				LoadAd ();
//				window.MakeKeyAndVisible();
			};
		}

		public string UnitId { get; set; }

		public string DeviceId { get; set; }


		public bool IsAdLoaded
		{
			get
			{
				return FinalAd.IsReady;
			}
		}
		public void InitInterstitial(string adUnitId) 
		{ 
			FinalAd = new GADInterstitial { AdUnitID = adUnitId }; 
			var request = GADRequest.Request;
			if(DeviceId != "")
				request.TestDevices = new string[]{GADRequest.GAD_SIMULATOR_ID,DeviceId};
			FinalAd.LoadRequest(request); 
		} 
		public static bool ShowInterstitialIfReady(UIViewController viewController) 
		{ 
			if (FinalAd.IsReady) 
			{ 
				FinalAd.PresentFromRootViewController(viewController); 
				return true;
			} 
			return false;
		}
		#endregion
    }
}

