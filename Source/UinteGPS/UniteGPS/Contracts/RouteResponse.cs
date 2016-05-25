using System;
using System.Collections.Generic;

namespace UniteGPS
{
	public class RoutesResponse
	{
		public List<RoutePoints> routePoints{get;set;}
		public string name {get;set;}
		public DateTime depart {get;set;}
		public DateTime arrive {get;set;}
		public object lastUpdatedOn {get;set;}
		public int id {get;set;}
	}
}

