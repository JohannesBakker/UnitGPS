using System;

// BO: Must use the same namespace as in Reference.cs
namespace UniteGPS.iOS.prd_ws.unitegps.com {
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
				throw new NotImplementedException();
			}

			public IAsyncResult BeginSaveFirstPoint(int routeId, double latitude, double longitude, DateTime collectTime, int userId, int esec, int bearing, int speed, int status, Guid executionId, AsyncCallback asyncCallback, object userState)
			{
				throw new NotImplementedException();
			}

			public void EndSaveFirstPoint(IAsyncResult result)
			{
				throw new NotImplementedException();
			}

			public void SaveLastPoint(int routeId, double latitude, double longitude, DateTime collectTime, int userId, int esec, int bearing, int speed, int status, Guid executionId)
			{
				throw new NotImplementedException ();
			}

			public IAsyncResult BeginSaveLastPoint(int routeId, double latitude, double longitude, DateTime collectTime, int userId, int esec, int bearing, int speed, int status, Guid executionId, AsyncCallback asyncCallback, object userState)
			{
				throw new NotImplementedException();
			}

			public void EndSaveLastPoint(IAsyncResult result)
			{
				throw new NotImplementedException();
			}

			public void UpdateRoute(int routeId, string coordinates, string newStops, int createdBy)
			{
				throw new NotImplementedException();
			}

			public IAsyncResult BeginUpdateRoute(int routeId, string coordinates, string newStops, int createdBy, AsyncCallback asyncCallback, object userState)
			{
				throw new NotImplementedException();
			}

			public void EndUpdateRoute(IAsyncResult result)
			{
				throw new NotImplementedException();
			}

			public string GetStudents(int userId)
			{
				throw new NotImplementedException();
			}

			public IAsyncResult BeginGetStudents(int userId, AsyncCallback asyncCallback, object userState)
			{
				throw new NotImplementedException();
			}

			public string EndGetStudents(IAsyncResult result)
			{
				throw new NotImplementedException();
			}

			//			public void SaveStudentPosition(double latitude, double longitude, int bearing, int speed, string collectTime, int userId, int studentId, int routeId, Guid executionId)
			//			{
			//				throw new NotImplementedException();
			//			}
			//
			//			public IAsyncResult BeginSaveStudentPosition(double latitude, double longitude, int bearing, int speed, string collectTime, int userId, int studentId, int routeId, Guid executionId, AsyncCallback asyncCallback, object userState)
			//			{
			//				throw new NotImplementedException();
			//			}
			//
			//			public void EndSaveStudentPosition(IAsyncResult result)
			//			{
			//				throw new NotImplementedException();
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
//			public string GetBusCordinates(int routeId)
//			{
//				object[] args = new object[1];
//				args[0] = routeId;
//				return (string)base.Invoke("GetBusCordinates", args);
//			}
//
//			public IAsyncResult BeginGetBusCordinates(int routeId, AsyncCallback asyncCallback, object userState)
//			{
//				object[] args = new object[1];
//				args[0] = routeId;
//				return (IAsyncResult)base.BeginInvoke("GetBusCordinates", args, asyncCallback, userState );
//			}
//
//
//			public string EndGetBusCordinates(IAsyncResult result)
//			{
//				object[] _args = new object[0];
//				return (string)base.EndInvoke("GetBusCordinates", _args, result);
//			}
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
}