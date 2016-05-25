using System;
using Xamarin.Forms;

namespace UniteGPS
{
	public class MyBanner : View
	{
		public static readonly BindableProperty AdUnitIdProperty = BindableProperty.Create<MyBanner, string>(p => p.AdUnitId, "ca-app-pub-2398347475015144/3845541915");

		public string AdUnitId
		{
			get { return (string)GetValue(AdUnitIdProperty); }
			set { SetValue(AdUnitIdProperty, value); }
		}

	}
}

