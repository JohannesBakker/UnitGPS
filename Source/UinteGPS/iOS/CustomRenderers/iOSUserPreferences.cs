using System;
using MonoTouch.Foundation;
using Xamarin.Forms;
using UniteGPS.iOS;


[assembly: Dependency(typeof(iOSUserPreferences))]
namespace UniteGPS.iOS
{
	public class iOSUserPreferences : IUserInterface
	{
		public void Set (string key, string value)
		{
			NSString newKey = new NSString (key);
			NSString newValue = new NSString (value);
			NSUserDefaults.StandardUserDefaults.SetValueForKey (newValue, newKey);
		}

		public string Get (string key)
		{
			NSString newKey = new NSString (key);
			NSString value = (NSString)NSUserDefaults.StandardUserDefaults.ValueForKey (newKey);
			return value != null ? value.ToString () : null;
		}
	}
}

