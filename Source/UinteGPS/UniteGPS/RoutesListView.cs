using System;
using Xamarin.Forms;

namespace UniteGPS
{
	public class RoutesListView : ViewCell
	{
		public RoutesListView ()
		{
			var label1 = new Label { Text = "Label 1 ", FontSize = Device.GetNamedSize (NamedSize.Small, typeof(Label)) ,TextColor = Color.Black};
			label1.SetBinding(Label.TextProperty, new Binding("."));

			View = new StackLayout {
				Orientation = StackOrientation.Vertical,
				HorizontalOptions = LayoutOptions.StartAndExpand,
				Padding = new Thickness (10, 10, 0, 0),
				Children = {
					new StackLayout {
						Orientation = StackOrientation.Vertical,
						Children = { label1}
					},
				}
			};
		}
	}
}

