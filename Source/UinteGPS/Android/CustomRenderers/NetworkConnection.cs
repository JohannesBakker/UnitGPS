using System;
using System.Runtime.CompilerServices;
using Android.Net;
using Android.App;
using Android.Content;
using UniteGPS.Android;

//[assembly: Dependency(typeof(NetworkConnection))]
[assembly: Xamarin.Forms.Dependency (typeof (NetworkConnection))]

namespace UniteGPS.Android
{
	public class NetworkConnection : INetworkConnection
	{
		public bool IsConnected { get; set; }
		public void CheckNetworkConnection()
		{
			try
			{
				var connectivityManager = (ConnectivityManager)Application.Context.GetSystemService(Context.ConnectivityService);
				var activeNetworkInfo = connectivityManager.ActiveNetworkInfo;

				if (activeNetworkInfo != null && activeNetworkInfo.IsConnectedOrConnecting)
					IsConnected = true;
				else
					IsConnected = false;
			}
			catch(Exception ex) 
			{
				Console.WriteLine (ex.Message);
			}
		}
	}
}

