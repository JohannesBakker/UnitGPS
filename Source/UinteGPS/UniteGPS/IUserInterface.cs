using System;

namespace UniteGPS
{
	public interface IUserInterface
	{
		void Set(string key, string value);
		string Get(string key);
	}
}

