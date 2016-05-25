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
		const string AdmobID = "ca-app-pub-1781457367312933/8092315597";
		GADBannerView adView;
		bool viewOnScreen = false;
		#pragma warning disable 108
		public static void Init() { }

		protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.View> e)
		{
			base.OnElementChanged(e);

			var adMobElement = Element as MyBanner;

			if (null != adMobElement)
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

