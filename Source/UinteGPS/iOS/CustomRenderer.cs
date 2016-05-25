using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

using Xamarin.Forms.Platform.iOS;
using UniteGPS.iOS;
using MonoTouch.iAd;
using Xamarin.Forms;
using UniteGPS;
using GoogleAdMobAds;
using MonoTouch.Dialog;

[assembly: ExportRenderer(typeof(MyBanner), typeof(CustomRenderer))]
namespace UniteGPS.iOS
{
	public class CustomRenderer : ViewRenderer
	{
		const string AdmobID = "ca-app-pub-3940256099942544/2934735716";
//		ca-app-pub-3940256099942544/2934735716
		GADBannerView adView;
		bool viewOnScreen = false;

		public static void Init() { }

		protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.View> e)
		{
			base.OnElementChanged(e);

			//convert the element to the control we want
			var adMobElement = Element as MyBanner;

			if (null != adMobElement) //TODO: does need this check here?
			{
				adView = new GADBannerView(size: GADAdSizeCons.Banner)
				{
					AdUnitID = AdmobID,
					RootViewController = UIApplication.SharedApplication.Windows[0].RootViewController
				};

				adView.DidReceiveAd += (sender, args) =>
				{
					if (!viewOnScreen) this.AddSubview(adView);
					viewOnScreen = true;
				};

				adView.LoadRequest (GADRequest.Request);
				base.SetNativeControl(adView);
			}
		}
	}
}

