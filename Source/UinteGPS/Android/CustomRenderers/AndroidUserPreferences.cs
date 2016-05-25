using System;

using Xamarin.Forms;
using Android.Content;
using UniteGPS.Android;

[assembly: Dependency(typeof(AndroidUserPreferences))]
namespace UniteGPS.Android
{
	public class AndroidUserPreferences : IUserInterface
	{
		#pragma warning disable 162
		public void Set (string key, string value)
		{
			try
			{
				var prefs = Forms.Context.GetSharedPreferences("MyApp", FileCreationMode.Private);
				var prefEditor = prefs.Edit();
				prefEditor.PutString (key, value);
				prefEditor.Commit();
			}
			catch(Exception ex) 
			{
				Console.WriteLine (ex.Message);
			}
		}
		public string Get (string key)
		{
			try
			{
				var prefs = Forms.Context.GetSharedPreferences("MyApp", FileCreationMode.Private);
				return prefs.GetString(key, null);
			}
			catch(Exception ex) 
			{
				return null;
				Console.WriteLine (ex.Message);
			}
		}
	}
}


