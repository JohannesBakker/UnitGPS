using System;
using System.Collections.Generic;

namespace UniteGPS
{
	public class UISession
	{
		public static bool Adddismis=true;
		public static int i=0;
		public static string SelectedRoute{ set; get;}
		public static bool FirstTime=true;
		public static double lat;
		public static double lng;
		public static int routeId;
		public static bool Routeselected=false;
		public static string[] RoutesData;
		public static bool MovingBus= false;
		public static double CurrentZoomLevel;
		public static List<RoutesResponse>  routeResponse;
		public static List<StopsForRouteResponse> stopsresponse;
		public static double currentlat;
		public static double currentlng;
		public static bool zoomlevelchanged=false;
		public static double radius;
		public static bool changeValue = true;
	}
}
