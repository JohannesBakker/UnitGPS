using System;
using Xamarin.Forms.Maps;
using System.Collections.Generic;
using Xamarin.Forms;

namespace UniteGPS
{
	public class MyMap : Map 
	{
		public MyMap(MapSpan region) : base(region)
		{
		}

		public static readonly BindableProperty SelectedPinProperty = BindableProperty.Create<MyMap, CustomPin> (x => x.SelectedPin, new CustomPin{ Label = "test123" });

		public CustomPin SelectedPin {
			get{ return (CustomPin)base.GetValue (SelectedPinProperty); }
			set{ base.SetValue (SelectedPinProperty, value); }
		}

		public static readonly BindableProperty CustomPinsProperty = BindableProperty.Create<MyMap, List<CustomPin>> (x => x.CustomPins, new List<CustomPin> (){ new CustomPin (){ Label = "test123" } });

		public List<CustomPin> CustomPins {
			get{ return (List<CustomPin>)base.GetValue (CustomPinsProperty); }
			set{ base.SetValue (CustomPinsProperty, value); }
		}


	}
}

