using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniteGPS
{
	public interface IAdMobInterstitialAd
	{
		string UnitId { get; set; }

		string DeviceId { get; set; }

		bool IsAdLoaded { get; }
		event EventHandler InterstitialAdLoaded;
		void Show();
		void LoadAd ();
	}
}

