using System;
using Xamarin.Forms;

namespace UniteGPS
{
	public static class Devices
	{
		public static IUserInterface Storage { get { return DependencyService.Get<IUserInterface> ();}}
	}
}

