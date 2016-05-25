using System;
/*
// BO: Must use the same namespace as in Reference.cs
namespace UniteGPS.Android.dev_ws.unitegps.com {
	public partial class BusServiceClient
	{
		protected override IBusService CreateChannel()
		{
			return new ConsumerServiceClientChannel(this);
		}

		private class ConsumerServiceClientChannel : ChannelBase<IBusService>, IBusService
		{
			//BO: Must implement IBusService interface
			#region IBusService implementation

			// BO: Sync version
			public string LogOnParent(string userName, string password)
			{
				object[] args = new object[2];
				args[0] = userName;
				args[1] = password;
				return (string)base.Invoke("LogOnParent", args);
			}

			// BO: Async version
			public IAsyncResult BeginLogOnParent(string userName, string password, AsyncCallback asyncCallback, object userState)
			{
				object[] args = new object[2];
				args[0] = userName;
				args[1] = password;
				return (IAsyncResult)base.BeginInvoke("LogOnParent", args, asyncCallback, userState );
			}

			public string EndLogOnParent(IAsyncResult result)
			{
				object[] _args = new object[0];
				return (string)base.EndInvoke("LogOnParent", _args, result);
			}

			public string LogOnDriver(string userName, string password)
			{
				object[] args = new object[2];
				args[0] = userName;
				args[1] = password;
				return (string)base.Invoke("LogOnDriver", args);
			}

			public IAsyncResult BeginLogOnDriver(string userName, string password, AsyncCallback asyncCallback, object userState)
			{
				object[] args = new object[2];
				args[0] = userName;
				args[1] = password;
				return (IAsyncResult)base.BeginInvoke("LogOnDriver", args, asyncCallback, userState );
			}

			public string EndLogOnDriver(IAsyncResult result)
			{
				object[] _args = new object[0];
				return (string)base.EndInvoke("LogOnDriver", _args, result);
			}

			public string GetRoutes(int userId)
			{
				object[] args = new object[1];
				args[0] = userId;
				return (string)base.Invoke("GetRoutes", args);
			}

			public IAsyncResult BeginGetRoutes(int userId, AsyncCallback asyncCallback, object userState)
			{
				object[] args = new object[1];
				args[0] = userId;
				return (IAsyncResult)base.BeginInvoke("GetRoutes", args, asyncCallback, userState );
			}

			public string EndGetRoutes(IAsyncResult result)
			{
				object[] _args = new object[0];
				return (string)base.EndInvoke("GetRoutes", _args, result);
			}

			public string GetRoutesWithStops(int userId)
			{
				object[] args = new object[1];
				args[0] = userId;
				return (string)base.Invoke("GetRoutesWithStops", args);
			}

			public IAsyncResult BeginGetRoutesWithStops(int userId, AsyncCallback asyncCallback, object userState)
			{
				object[] args = new object[1];
				args[0] = userId;
				return (IAsyncResult)base.BeginInvoke("GetRoutesWithStops", args, asyncCallback, userState );
			}

			public string EndGetRoutesWithStops(IAsyncResult result)
			{
				object[] _args = new object[0];
				return (string)base.EndInvoke("GetRoutesWithStops", _args, result);
			}

			public void SaveFirstPoint(int routeId, double latitude, double longitude, DateTime collectTime, int userId, int esec, int bearing, int speed, int status, Guid executionId)
			{
				object[] args = new object[10];
				args[0] = routeId;
				args[1] = latitude;
				args[2] = longitude;
				args[3] = collectTime;
				args[4] = userId;
				args[5] = esec;
				args[6] = bearing;
				args[7] = speed;
				args[8] = status;
				args[9] = executionId;

				base.Invoke("SaveFirstPoint", args);
			}

			public IAsyncResult BeginSaveFirstPoint(int routeId, double latitude, double longitude, DateTime collectTime, int userId, int esec, int bearing, int speed, int status, Guid executionId, AsyncCallback asyncCallback, object userState)
			{
				object[] args = new object[10];
				args[0] = routeId;
				args[1] = latitude;
				args[2] = longitude;
				args[3] = collectTime;
				args[4] = userId;
				args[5] = esec;
				args[6] = bearing;
				args[7] = speed;
				args[8] = status;
				args[9] = executionId;
				return (IAsyncResult)base.BeginInvoke("SaveFirstPoint", args, asyncCallback, userState );
			}

			public void EndSaveFirstPoint(IAsyncResult result)
			{
				object[] _args = new object[0];
				base.EndInvoke("SaveFirstPoint", _args, result);
			}

			public void SaveLastPoint(int routeId, double latitude, double longitude, DateTime collectTime, int userId, int esec, int bearing, int speed, int status, Guid executionId)
			{
				object[] args = new object[10];
				args[0] = routeId;
				args[1] = latitude;
				args[2] = longitude;
				args[3] = collectTime;
				args[4] = userId;
				args[5] = esec;
				args[6] = bearing;
				args[7] = speed;
				args[8] = status;
				args[9] = executionId;
				base.Invoke("SaveLastPoint", args);
			}

			public IAsyncResult BeginSaveLastPoint(int routeId, double latitude, double longitude, DateTime collectTime, int userId, int esec, int bearing, int speed, int status, Guid executionId, AsyncCallback asyncCallback, object userState)
			{
				object[] args = new object[10];
				args[0] = routeId;
				args[1] = latitude;
				args[2] = longitude;
				args[3] = collectTime;
				args[4] = userId;
				args[5] = esec;
				args[6] = bearing;
				args[7] = speed;
				args[8] = status;
				args[9] = executionId;
				return (IAsyncResult)base.BeginInvoke("SaveLastPoint", args, asyncCallback, userState );
			}

			public void EndSaveLastPoint(IAsyncResult result)
			{
				object[] _args = new object[0];
				base.EndInvoke("SaveLastPoint", _args, result);
			}

			public void UpdateRoute(int routeId, string coordinates, string newStops, int createdBy)
			{
				object[] args = new object[4];
				args[0] = routeId;
				args[1] = coordinates;
				args[2] = newStops;
				args[3] = createdBy;
				base.Invoke("UpdateRoute", args);
			}

			public IAsyncResult BeginUpdateRoute(int routeId, string coordinates, string newStops, int createdBy, AsyncCallback asyncCallback, object userState)
			{
				object[] args = new object[4];
				args[0] = routeId;
				args[1] = coordinates;
				args[2] = newStops;
				args[3] = createdBy;
				return (IAsyncResult)base.BeginInvoke("UpdateRoute", args, asyncCallback, userState );
			}

			public void EndUpdateRoute(IAsyncResult result)
			{
				object[] _args = new object[0];
				base.EndInvoke("UpdateRoute", _args, result);
			}

			public string GetStudents(int userId)
			{
				object[] args = new object[1];
				args[0] = userId;
				return (string)base.Invoke("GetStudents", args);
			}

			public IAsyncResult BeginGetStudents(int userId, AsyncCallback asyncCallback, object userState)
			{
				object[] args = new object[1];
				args[0] = userId;
				return (IAsyncResult)base.BeginInvoke("GetStudents", args, asyncCallback, userState );
			}

			public string EndGetStudents(IAsyncResult result)
			{
				object[] _args = new object[0];
				return (string)base.EndInvoke("GetStudents", _args, result);
			}

			//			public void SaveStudentPosition(double latitude, double longitude, int bearing, int speed, string collectTime, int userId, int studentId, int routeId, Guid executionId)
			//			{
			//				object[] args = new object[9];
			//				args[0] = latitude;
			//				args[1] = longitude;
			//				args[2] = bearing;
			//				args[3] = speed;
			//				args[4] = collectTime;
			//				args[5] = userId;
			//				args[6] = studentId;
			//				args[7] = routeId;
			//				args[8] = executionId;
			//				base.Invoke("SaveStudentPosition", args);
			//			}
			//
			//			public IAsyncResult BeginSaveStudentPosition(double latitude, double longitude, int bearing, int speed, string collectTime, int userId, int studentId, int routeId, Guid executionId, AsyncCallback asyncCallback, object userState)
			//			{
			//				object[] args = new object[9];
			//				args[0] = latitude;
			//				args[1] = longitude;AuthResponse
			//				args[2] = bearing;
			//				args[3] = speed;
			//				args[4] = collectTime;
			//				args[5] = userId;
			//				args[6] = studentId;
			//				args[7] = routeId;
			//				args[8] = executionId;
			//				return (IAsyncResult)base.BeginInvoke("SaveStudentPosition", args, asyncCallback, userState );
			//			}
			//
			//			public void EndSaveStudentPosition(IAsyncResult result)
			//			{
			//				object[] _args = new object[0];
			//				base.EndInvoke("SaveStudentPosition", _args, result);
			//			}




			// New Implementations 17/FEB/2015  10:34 

			public int SaveRoute(string name, int userId) {
				object[] args = new object[2];
				args[0] = name;
				args[1] = userId;
				return (int)base.Invoke("SaveRoute", args);
			}

			public IAsyncResult BeginSaveRoute(string name, int userId, AsyncCallback asyncCallback, object userState)
			{
				object[] args = new object[2];
				args[0] = name;
				args[1] = userId;
				return (IAsyncResult)base.BeginInvoke("SaveRoute", args, asyncCallback, userState );
			}

			public int EndSaveRoute(IAsyncResult result)
			{
				object[] _args = new object[0];
				return (int)base.EndInvoke("SaveRoute", _args, result);
			}


			public int RouteExists(string name, int userId) {
				object[] args = new object[2];
				args[0] = name;
				args[1] = userId;
				return (int)base.Invoke("RouteExists", args);
			}

			public IAsyncResult BeginRouteExists(string name, int userId, AsyncCallback asyncCallback, object userState)
			{
				object[] args = new object[2];
				args[0] = name;
				args[1] = userId;
				return (IAsyncResult)base.BeginInvoke("RouteExists", args, asyncCallback, userState );
			}

			public int EndRouteExists(IAsyncResult result)
			{
				object[] _args = new object[0];
				return (int)base.EndInvoke("RouteExists", _args, result);
			}

			public string GetStopsForRoute(int userId,int routeId)
			{
				object[] args = new object[2];
				args[0] = userId;
				args[1] = routeId;
				return (string)base.Invoke("GetStopsForRoute", args);
			}

			public IAsyncResult BeginGetStopsForRoute(int userId,int routeId, AsyncCallback asyncCallback, object userState)
			{
				object[] args = new object[2];
				args[0] = userId;
				args[1] = routeId;
				return (IAsyncResult)base.BeginInvoke("GetStopsForRoute", args, asyncCallback, userState );
			}

			public string EndGetStopsForRoute(IAsyncResult result)
			{
				object[] _args = new object[0];
				return (string)base.EndInvoke("GetStopsForRoute", _args, result);
			}
			public string GetBusCoordinates(int routeId)
			{
				object[] args = new object[1];
				args[0] = routeId;
				return (string)base.Invoke("GetBusCoordinates", args);
			}

			public IAsyncResult BeginGetBusCoordinates(int routeId, AsyncCallback asyncCallback, object userState)
			{
				object[] args = new object[1];
				args[0] = routeId;
				return (IAsyncResult)base.BeginInvoke("GetBusCoordinates", args, asyncCallback, userState );
			}


			public string EndGetBusCoordinates(IAsyncResult result)
			{
				object[] _args = new object[0];
				return (string)base.EndInvoke("GetBusCoordinates", _args, result);
			}
			#endregion

			public ConsumerServiceClientChannel(System.ServiceModel.ClientBase<IBusService> client) :
			base(client)
			{

			}

			//            // Sync version
			//            public AccountBalanceResponse GetAccountBalance(AccountBalanceQuery query)
			//            {
			//                object[] _args = new object[1];
			//                _args[0] = query;
			//                return (AccountBalanceResponse)base.Invoke("GetAccountBalance", _args);
			//            }

			//            // Async version
			//            public IAsyncResult BeginGetAccountBalance(AccountBalanceQuery query, AsyncCallback callback, object asyncState )
			//            {
			//                object[] _args = new object[1];
			//                _args[0] = query;
			//                return (IAsyncResult)base.BeginInvoke("GetAccountBalance", _args, callback, asyncState );
			//            }
			//
			//
			//            public AccountBalanceResponse EndGetAccountBalance(IAsyncResult asyncResult)
			//            {
			//                object[] _args = new object[0];
			//                return (AccountBalanceResponse)base.EndInvoke("GetAccountBalance", _args, asyncResult);
			//            }
		}
	}
}*/