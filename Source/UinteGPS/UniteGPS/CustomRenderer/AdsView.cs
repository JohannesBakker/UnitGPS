using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace UniteGPS
{
	public class AdsView : ContentView
	{
		public AdsView ()
		{
			var myBanner = new MyBanner
			{
				BackgroundColor = Color.Transparent,
			};

			Content = new StackLayout
			{
				Children = {  myBanner }
			};
		}
	}
}

