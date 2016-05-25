using System;
using Xamarin.Forms;

namespace UniteGPS
{
	public class Test : ContentPage
	{
		public Test ()
		{
			this.BackgroundColor = Color.White;
			Padding = new Thickness(0);
			var red = new Label
			{
				HeightRequest = 70,
				BackgroundColor = Color.Red,
				Font = Font.SystemFontOfSize (20)
			};
//			var yellow = new Label
//			{
//				Text = "Slow down",
//				BackgroundColor = Color.Yellow,
//				Font = Font.SystemFontOfSize (20)
//			};
//			var green = new Label
//			{
//				Text = "Go",
//				BackgroundColor = Color.Green,
//				Font = Font.SystemFontOfSize (20)
//			};

			Content = new StackLayout
			{
				Spacing = 10,
				Children = { red
//					yellow, green 
				}
			};
		}
	}
}

