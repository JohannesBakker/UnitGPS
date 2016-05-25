using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.Gms.Ads;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using UniteGPS.Android;
using UniteGPS;

[assembly: ExportRenderer(typeof(MyBanner), typeof(CustomRenderer))]
namespace UniteGPS.Android
{
	public class CustomRenderer : ViewRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<View> e)
		{
			try
			{
				base.OnElementChanged(e);

				if (e.OldElement == null)
				{
					AdView ad = new AdView(this.Context);
					ad.AdSize = AdSize.SmartBanner;
					ad.AdUnitId = "ca-app-pub-1781457367312933/8231916390";
					var requestbuilder = new AdRequest.Builder();
					ad.LoadAd(requestbuilder.Build());
					this.SetNativeControl(ad);
				};
			}
			catch(Exception ex) 
			{
				Console.WriteLine (ex.Message);
			}
		}
	}
}


