using System;

namespace UniteGPS
{
	public class LoginResponse
	{
		public int uploadInterval {get;set;}
		public int userId {get;set;}
		public string url {get;set;}
		public int radiusStartPoint {get;set;}
		public int radiusEndPoint {get;set;}
		public int countReadingStartPoint {get;set;}
		public int countReadingsEndPoint {get;set;}
		public int accuracy {get;set;}
	}
}

