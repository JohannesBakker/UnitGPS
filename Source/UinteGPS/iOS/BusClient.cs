using System;
using UniteGPS.iOS;
using System.ServiceModel;
using System.Collections.Generic;
using Newtonsoft.Json;
using UniteGPS.iOS.prd_ws.unitegps.com;

[assembly: Xamarin.Forms.Dependency (typeof (BusClient))]
namespace UniteGPS.iOS
{
	public class BusClient : IBusClient
	{
		public static readonly EndpointAddress EndPoint = new EndpointAddress("http://prd-ws.unitegps.com/UniteGPSBusService/BusService.svc/basic");

		private static BasicHttpBinding CreateBasicHttp()
		{
			BasicHttpBinding binding = new BasicHttpBinding
			{
				Name = "basicHttpBinding",
				MaxBufferSize = 2147483647,
				MaxReceivedMessageSize = 2147483647
			};
			TimeSpan timeout = new TimeSpan(0, 0, 30);
			binding.SendTimeout = timeout;
			binding.OpenTimeout = timeout;
			binding.ReceiveTimeout = timeout;
			return binding;
		}

		public string LogOnParent(string userName, string password)
		{
			var responce = string.Empty;
			try
			{
				BasicHttpBinding binding = CreateBasicHttp();
				BusServiceClient busservice = new BusServiceClient (binding,EndPoint);
				responce = busservice.LogOnParent (userName, password);
				return responce;
			} 
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
			finally 
			{
				// Clear object
			}
			return responce;
		}


		public string LogOnDriver(string userName, string password)
		{
			var responce = string.Empty;
			try 
			{
				BasicHttpBinding binding = CreateBasicHttp();
				BusServiceClient busservice = new BusServiceClient (binding,EndPoint);
				responce = busservice.LogOnDriver (userName, password);
				return responce;
			} 
			catch (Exception ex) 
			{
				Console.WriteLine(ex.Message);
			}
			finally 
			{
				// Clear object
			}
			return responce;
		}

		public List<RoutesResponse> GetRoutes(int UserId)
		{
			List<RoutesResponse> routesResponse = new List<RoutesResponse> ();
			try 
			{
				BasicHttpBinding binding = CreateBasicHttp();
				BusServiceClient busservice = new BusServiceClient (binding,EndPoint);
				var responce = busservice.GetRoutes (UserId);
				routesResponse= JsonConvert.DeserializeObject<List<RoutesResponse>> (responce);
				return routesResponse;
			} 
			catch (Exception ex) 
			{
				Console.WriteLine(ex.Message);
			}
			finally {
				// Clear object
			}
			return routesResponse;
		}
		public List<RoutesResponse> GetRoutesWithStops(int UserId)
		{
			List<RoutesResponse> routesSTOPSResponse = new List<RoutesResponse> ();
			try
			{
				BasicHttpBinding binding = CreateBasicHttp();
				BusServiceClient busservice = new BusServiceClient (binding,EndPoint);
				Console.WriteLine(busservice);
				//var responce = busservice.GetRoutesWithStops (UserId);
				//routesSTOPSResponse= JsonConvert.DeserializeObject<List<RoutesResponse>> (responce);
				return routesSTOPSResponse;
			} 
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
			finally
			{
				// Clear object
			}
			return routesSTOPSResponse;
		}

		public AuthResponse SaveFirstPoint(int routeId, double latitude, double longitude, DateTime collectTime, int userId, int esec, int bearing, int speed, int status, Guid executionId)
		{
			var responce = new AuthResponse();
			try 
			{
				BasicHttpBinding binding = CreateBasicHttp();
				BusServiceClient busservice = new BusServiceClient (binding,EndPoint);
				Console.WriteLine(busservice);
				//busservice.SaveFirstPoint(routeId,latitude,longitude,collectTime,userId,esec,bearing,speed,status,executionId);
				responce.Status="0";
				responce.StatusText="Success.";
			} 
			catch (Exception ex) 
			{
				responce.Status="1";
				responce.StatusText="Please try again.";
				Console.WriteLine(ex.Message);
			}
			finally 
			{
				// Clear object
			}
			return responce;
		}
		public AuthResponse SaveLastPoint(int routeId, double latitude, double longitude, DateTime collectTime, int userId, int esec, int bearing, int speed, int status, Guid executionId)
		{
			var responce = new AuthResponse ();
			try 
			{
				BasicHttpBinding binding = CreateBasicHttp();
				BusServiceClient busservice = new BusServiceClient (binding,EndPoint);
				Console.WriteLine(busservice);
				//busservice.SaveLastPoint(routeId,latitude,longitude,collectTime,userId,esec,bearing,speed,status,executionId);
				responce.Status="0";
				responce.StatusText="Success.";
			} 
			catch (Exception ex) 
			{
				responce.Status="1";
				responce.StatusText="Please try again.";
				Console.WriteLine(ex.Message);
			}
			finally
			{
				// Clear object
			}
			return responce;
		}

		public AuthResponse UpdateRoute(int routeId, string coordinates, string newStops, int createdBy)
		{
			var responce = new AuthResponse();
			try 
			{

				BasicHttpBinding binding = CreateBasicHttp();
				BusServiceClient busservice = new BusServiceClient (binding,EndPoint);
				busservice.UpdateRoute(routeId,coordinates,newStops,createdBy);
				responce.Status="0";
				responce.StatusText="Success.";
			} 
			catch (Exception ex) 
			{
				responce.Status="1";
				responce.StatusText="Please try again.";
				Console.WriteLine(ex.Message);
			}
			finally 
			{
				// Clear object
			}
			return responce;
		}

		public string GetStudents(int userId)
		{
			var responce = string.Empty;
			try 
			{
				BasicHttpBinding binding = CreateBasicHttp();
				BusServiceClient busservice = new BusServiceClient (binding,EndPoint);
				Console.WriteLine(busservice);
				//responce = busservice.GetStudents(userId);
				return responce;
			} 
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
			finally 
			{
				// Clear object
			}
			return responce;
		}

		public AuthResponse SaveStudentPosition(double latitude, double longitude, int bearing, int speed, string collectTime, int userId, int studentId, int routeId, Guid executionId)
		{
			var responce = new AuthResponse ();
			try 
			{
				BasicHttpBinding binding = CreateBasicHttp();
				BusServiceClient busservice = new BusServiceClient (binding,EndPoint);
				Console.WriteLine(busservice);
				//busservice.SaveStudentPosition(latitude,longitude,bearing,speed,collectTime,userId,studentId,routeId,executionId);
				responce.Status="0";
				responce.StatusText="Success.";
			} 
			catch (Exception ex) 
			{
				responce.Status="1";
				responce.StatusText="Please try again.";
				Console.WriteLine(ex.Message);

			}
			finally 
			{
				// Clear object
			}
			return responce;
		}

		// New Implementation 17/FEB/2015  10:38pm
		public List<StopsForRouteResponse> GetStopsForRoute (int userId,int routeId)
		{
			List<StopsForRouteResponse> stopsForRouteResponse = new List<StopsForRouteResponse> ();
			try 
			{
				BasicHttpBinding binding = CreateBasicHttp();
				BusServiceClient busservice = new BusServiceClient (binding,EndPoint);
				var responce = busservice.GetStopsForRoute (userId,routeId);
				stopsForRouteResponse= JsonConvert.DeserializeObject<List<StopsForRouteResponse>> (responce);
				return stopsForRouteResponse;
			} 
			catch (Exception ex) 
			{
				Console.WriteLine(ex.Message);
			}
			finally 
			{
				// Clear object
			}
			return stopsForRouteResponse;
		}
		public int SaveRoute (string name, int userId)
		{
			int responce = 0;
			try 
			{
				BasicHttpBinding binding = CreateBasicHttp();
				BusServiceClient busservice = new BusServiceClient (binding,EndPoint);
				responce = busservice.SaveRoute (name,userId);
				//routesSTOPSResponse= JsonConvert.DeserializeObject<List<RoutesResponse>> (responce);
				return responce;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
			finally 
			{
				// Clear object
			}
			return responce;
		}
		public int RouteExists (string name, int userId)
		{
			int responce = 0;
			try 
			{
				BasicHttpBinding binding = CreateBasicHttp();
				BusServiceClient busservice = new BusServiceClient (binding,EndPoint);
		 		responce = busservice.RouteExists (name,userId);
				//routesSTOPSResponse= JsonConvert.DeserializeObject<List<RoutesResponse>> (responce);
				return responce;
			} 
			catch (Exception ex) 
			{
				Console.WriteLine(ex.Message);
			}
			finally
			{
				// Clear object
			}
			return responce;
		}
		public string GetBusCoordinates(int routeId)
		{
			var responce = string.Empty;
			try 
			{
				BasicHttpBinding binding = CreateBasicHttp();
				BusServiceClient busservice = new BusServiceClient (binding,EndPoint);
				responce = busservice.GetBusCoordinates(routeId);
				return responce;
			} 
			catch (Exception ex) 
			{
				Console.WriteLine(ex.Message);
			}
			finally 
			{
				// Clear object
			}
			return responce;
		}
	}
}

