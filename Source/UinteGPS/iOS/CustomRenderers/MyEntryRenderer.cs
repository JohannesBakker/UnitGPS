using System;
using Xamarin.Forms;
using UniteGPS;
using UniteGPS.iOS;
using Xamarin.Forms.Platform.iOS;
using MonoTouch.UIKit;

[assembly: ExportRenderer (typeof (MyEntry), typeof (MyEntryRenderer))]
namespace UniteGPS.iOS
{
	public class MyEntryRenderer : EntryRenderer
	{
		protected override void OnElementChanged (ElementChangedEventArgs<Entry> e)
		{
			try
			{
				base.OnElementChanged (e);

				if (e.OldElement == null) {
					var nativeTextField = (UITextField)Control;
					nativeTextField.BackgroundColor = UIColor.White;
					nativeTextField.BorderStyle = UITextBorderStyle.RoundedRect;
					nativeTextField.TintColor = UIColor.LightGray;
					nativeTextField.TintColor = UIColor.LightGray;
				}
			}
			catch(Exception ex)
			{
				Console.WriteLine (ex.Message);
			}
		}
	}
}

