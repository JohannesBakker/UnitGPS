using System;
using Xamarin.Forms;
using UniteGPS;
using UniteGPS.Android;
using Xamarin.Forms.Platform.Android;
using Android.Views;
using System.Threading;

[assembly: ExportRenderer (typeof (MyEntry), typeof (MyEntryRenderer))]
namespace UniteGPS.Android
{
	public class MyEntryRenderer : EntryRenderer
	{
		private bool _inititialized = false;
		protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
		{
			base.OnElementChanged(e);

			var view = (MyEntry)Element;

			Control.SetPadding (10, 0, 10, 0);

			if (this.Control != null)
			{
				if(!_inititialized)
				{
					this.Control.FocusChange+=((sender, evt) => {
						if(evt.HasFocus)
						{
							ThreadPool.QueueUserWorkItem(s =>
								{
									Thread.Sleep(100); // For some reason, a short delay is required here.
									((global::Android.Views.InputMethods.InputMethodManager)Context.GetSystemService(global::Android.Content.Context.InputMethodService)).ShowSoftInput(this.Control, global::Android.Views.InputMethods.ShowFlags.Implicit);
								});
						}
					});
					_inititialized = true;
				}
			}
		}

		protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged(sender, e);

			var view = (MyEntry)Element;

			Control.SetBackgroundColor(global::Android.Graphics.Color.Transparent);
		}
	}
}

