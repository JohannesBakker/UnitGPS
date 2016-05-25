using System;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

namespace UniteGPS.Android
{
	public class MyListViewRenderer : ListViewRenderer
	{
		protected override void OnElementChanged (ElementChangedEventArgs<Xamarin.Forms.ListView> e)
		{
			try
			{
				base.OnElementChanged (e);

				if (Control == null)
					return;
				
				var listView = Control as global::Android.Widget.ListView;
				listView.DividerHeight = 2;
			}
			catch(Exception ex) 
			{
				Console.WriteLine (ex.Message);
			}
		}
	}
}

