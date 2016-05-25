// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 4.0.30319.17020
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------

namespace UniteGPS.iOS.prd_ws.unitegps.com {
    



	[System.ServiceModel.ServiceContractAttribute(Namespace="http://www.unitegps.com/bus/10/2013", ConfigurationName="IBusService")]
public interface IBusService {
    
    [System.ServiceModel.OperationContractAttribute(Action="http://www.unitegps.com/bus/10/2013/IBusService/LogOnParent", ReplyAction="http://www.unitegps.com/bus/10/2013/IBusService/LogOnParentResponse")]
    string LogOnParent(string userName, string password);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://www.unitegps.com/bus/10/2013/IBusService/LogOnParent", ReplyAction="http://www.unitegps.com/bus/10/2013/IBusService/LogOnParentResponse", AsyncPattern=true)]
    System.IAsyncResult BeginLogOnParent(string userName, string password, System.AsyncCallback asyncCallback, object userState);
    
    string EndLogOnParent(System.IAsyncResult result);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://www.unitegps.com/bus/10/2013/IBusService/LogOnDriver", ReplyAction="http://www.unitegps.com/bus/10/2013/IBusService/LogOnDriverResponse")]
    string LogOnDriver(string userName, string password);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://www.unitegps.com/bus/10/2013/IBusService/LogOnDriver", ReplyAction="http://www.unitegps.com/bus/10/2013/IBusService/LogOnDriverResponse", AsyncPattern=true)]
    System.IAsyncResult BeginLogOnDriver(string userName, string password, System.AsyncCallback asyncCallback, object userState);
    
    string EndLogOnDriver(System.IAsyncResult result);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://www.unitegps.com/bus/10/2013/IBusService/GetRoutes", ReplyAction="http://www.unitegps.com/bus/10/2013/IBusService/GetRoutesResponse")]
    string GetRoutes(int userId);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://www.unitegps.com/bus/10/2013/IBusService/GetRoutes", ReplyAction="http://www.unitegps.com/bus/10/2013/IBusService/GetRoutesResponse", AsyncPattern=true)]
    System.IAsyncResult BeginGetRoutes(int userId, System.AsyncCallback asyncCallback, object userState);
    
    string EndGetRoutes(System.IAsyncResult result);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://www.unitegps.com/bus/10/2013/IBusService/UpdateRoute", ReplyAction="http://www.unitegps.com/bus/10/2013/IBusService/UpdateRouteResponse")]
    void UpdateRoute(int routeId, string coordinates, string newStops, int createdBy);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://www.unitegps.com/bus/10/2013/IBusService/UpdateRoute", ReplyAction="http://www.unitegps.com/bus/10/2013/IBusService/UpdateRouteResponse", AsyncPattern=true)]
    System.IAsyncResult BeginUpdateRoute(int routeId, string coordinates, string newStops, int createdBy, System.AsyncCallback asyncCallback, object userState);
    
    void EndUpdateRoute(System.IAsyncResult result);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://www.unitegps.com/bus/10/2013/IBusService/SaveRoute", ReplyAction="http://www.unitegps.com/bus/10/2013/IBusService/SaveRouteResponse")]
    int SaveRoute(string name, int userId);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://www.unitegps.com/bus/10/2013/IBusService/SaveRoute", ReplyAction="http://www.unitegps.com/bus/10/2013/IBusService/SaveRouteResponse", AsyncPattern=true)]
    System.IAsyncResult BeginSaveRoute(string name, int userId, System.AsyncCallback asyncCallback, object userState);
    
    int EndSaveRoute(System.IAsyncResult result);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://www.unitegps.com/bus/10/2013/IBusService/RouteExists", ReplyAction="http://www.unitegps.com/bus/10/2013/IBusService/RouteExistsResponse")]
    int RouteExists(string name, int userId);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://www.unitegps.com/bus/10/2013/IBusService/RouteExists", ReplyAction="http://www.unitegps.com/bus/10/2013/IBusService/RouteExistsResponse", AsyncPattern=true)]
    System.IAsyncResult BeginRouteExists(string name, int userId, System.AsyncCallback asyncCallback, object userState);
    
    int EndRouteExists(System.IAsyncResult result);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://www.unitegps.com/bus/10/2013/IBusService/GetStopsForRoute", ReplyAction="http://www.unitegps.com/bus/10/2013/IBusService/GetStopsForRouteResponse")]
    string GetStopsForRoute(int userId, int routeId);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://www.unitegps.com/bus/10/2013/IBusService/GetStopsForRoute", ReplyAction="http://www.unitegps.com/bus/10/2013/IBusService/GetStopsForRouteResponse", AsyncPattern=true)]
    System.IAsyncResult BeginGetStopsForRoute(int userId, int routeId, System.AsyncCallback asyncCallback, object userState);
    
    string EndGetStopsForRoute(System.IAsyncResult result);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://www.unitegps.com/bus/10/2013/IBusService/GetBusCoordinates", ReplyAction="http://www.unitegps.com/bus/10/2013/IBusService/GetBusCoordinatesResponse")]
    string GetBusCoordinates(int routeId);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://www.unitegps.com/bus/10/2013/IBusService/GetBusCoordinates", ReplyAction="http://www.unitegps.com/bus/10/2013/IBusService/GetBusCoordinatesResponse", AsyncPattern=true)]
    System.IAsyncResult BeginGetBusCoordinates(int routeId, System.AsyncCallback asyncCallback, object userState);
    
    string EndGetBusCoordinates(System.IAsyncResult result);
}

public interface IBusServiceChannel {
}

public partial class BusServiceClient : System.ServiceModel.ClientBase<IBusService>, IBusService {
    
    public BusServiceClient() {
    }
    
    public BusServiceClient(string endpointConfigurationName) : 
            base(endpointConfigurationName) {
    }
    
    public BusServiceClient(string endpointConfigurationName, string remoteAddress) : 
            base(endpointConfigurationName, remoteAddress) {
    }
    
    public BusServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(endpointConfigurationName, remoteAddress) {
    }
    
    public BusServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress endpoint) : 
            base(binding, endpoint) {
    }
    
    public string LogOnParent(string userName, string password) {
        return base.Channel.LogOnParent(userName, password);
    }
    
    public System.IAsyncResult BeginLogOnParent(string userName, string password, System.AsyncCallback asyncCallback, object userState) {
        return base.Channel.BeginLogOnParent(userName, password, asyncCallback, userState);
    }
    
    public string EndLogOnParent(System.IAsyncResult result) {
        return base.Channel.EndLogOnParent(result);
    }
    
    public string LogOnDriver(string userName, string password) {
        return base.Channel.LogOnDriver(userName, password);
    }
    
    public System.IAsyncResult BeginLogOnDriver(string userName, string password, System.AsyncCallback asyncCallback, object userState) {
        return base.Channel.BeginLogOnDriver(userName, password, asyncCallback, userState);
    }
    
    public string EndLogOnDriver(System.IAsyncResult result) {
        return base.Channel.EndLogOnDriver(result);
    }
    
    public string GetRoutes(int userId) {
        return base.Channel.GetRoutes(userId);
    }
    
    public System.IAsyncResult BeginGetRoutes(int userId, System.AsyncCallback asyncCallback, object userState) {
        return base.Channel.BeginGetRoutes(userId, asyncCallback, userState);
    }
    
    public string EndGetRoutes(System.IAsyncResult result) {
        return base.Channel.EndGetRoutes(result);
    }
    
    public void UpdateRoute(int routeId, string coordinates, string newStops, int createdBy) {
        base.Channel.UpdateRoute(routeId, coordinates, newStops, createdBy);
    }
    
    public System.IAsyncResult BeginUpdateRoute(int routeId, string coordinates, string newStops, int createdBy, System.AsyncCallback asyncCallback, object userState) {
        return base.Channel.BeginUpdateRoute(routeId, coordinates, newStops, createdBy, asyncCallback, userState);
    }
    
    public void EndUpdateRoute(System.IAsyncResult result) {
        base.Channel.EndUpdateRoute(result);
    }
    
    public int SaveRoute(string name, int userId) {
        return base.Channel.SaveRoute(name, userId);
    }
    
    public System.IAsyncResult BeginSaveRoute(string name, int userId, System.AsyncCallback asyncCallback, object userState) {
        return base.Channel.BeginSaveRoute(name, userId, asyncCallback, userState);
    }
    
    public int EndSaveRoute(System.IAsyncResult result) {
        return base.Channel.EndSaveRoute(result);
    }
    
    public int RouteExists(string name, int userId) {
        return base.Channel.RouteExists(name, userId);
    }
    
    public System.IAsyncResult BeginRouteExists(string name, int userId, System.AsyncCallback asyncCallback, object userState) {
        return base.Channel.BeginRouteExists(name, userId, asyncCallback, userState);
    }
    
    public int EndRouteExists(System.IAsyncResult result) {
        return base.Channel.EndRouteExists(result);
    }
    
    public string GetStopsForRoute(int userId, int routeId) {
        return base.Channel.GetStopsForRoute(userId, routeId);
    }
    
    public System.IAsyncResult BeginGetStopsForRoute(int userId, int routeId, System.AsyncCallback asyncCallback, object userState) {
        return base.Channel.BeginGetStopsForRoute(userId, routeId, asyncCallback, userState);
    }
    
    public string EndGetStopsForRoute(System.IAsyncResult result) {
        return base.Channel.EndGetStopsForRoute(result);
    }
    
    public string GetBusCoordinates(int routeId) {
        return base.Channel.GetBusCoordinates(routeId);
    }
    
    public System.IAsyncResult BeginGetBusCoordinates(int routeId, System.AsyncCallback asyncCallback, object userState) {
        return base.Channel.BeginGetBusCoordinates(routeId, asyncCallback, userState);
    }
    
    public string EndGetBusCoordinates(System.IAsyncResult result) {
        return base.Channel.EndGetBusCoordinates(result);
    }
    
//    protected override IBusService CreateChannel() {
//        return ((IBusService)(new BusServiceChannel(this)));
//    }
    
    private class BusServiceChannel : ChannelBase<IBusService>, IBusService {
        
        public BusServiceChannel(System.ServiceModel.ClientBase<IBusService> client) : 
                base(client) {
        }
        
        public string LogOnParent(string userName, string password) {
            object[] args = new object[] {
                    userName,
                    password};
            return ((string)(base.Invoke("LogOnParent", args)));
        }
        
        public System.IAsyncResult BeginLogOnParent(string userName, string password, System.AsyncCallback asyncCallback, object userState) {
            return base.BeginInvoke("LogOnParent", new object[] {
                        userName,
                        password}, asyncCallback, userState);
        }
        
        public string EndLogOnParent(System.IAsyncResult result) {
            object[] args = new object[0];
            return ((string)(base.EndInvoke("LogOnParent", args, result)));
        }
        
        public string LogOnDriver(string userName, string password) {
            object[] args = new object[] {
                    userName,
                    password};
            return ((string)(base.Invoke("LogOnDriver", args)));
        }
        
        public System.IAsyncResult BeginLogOnDriver(string userName, string password, System.AsyncCallback asyncCallback, object userState) {
            return base.BeginInvoke("LogOnDriver", new object[] {
                        userName,
                        password}, asyncCallback, userState);
        }
        
        public string EndLogOnDriver(System.IAsyncResult result) {
            object[] args = new object[0];
            return ((string)(base.EndInvoke("LogOnDriver", args, result)));
        }
        
        public string GetRoutes(int userId) {
            object[] args = new object[] {
                    userId};
            return ((string)(base.Invoke("GetRoutes", args)));
        }
        
        public System.IAsyncResult BeginGetRoutes(int userId, System.AsyncCallback asyncCallback, object userState) {
            return base.BeginInvoke("GetRoutes", new object[] {
                        userId}, asyncCallback, userState);
        }
        
        public string EndGetRoutes(System.IAsyncResult result) {
            object[] args = new object[0];
            return ((string)(base.EndInvoke("GetRoutes", args, result)));
        }
        
        public void UpdateRoute(int routeId, string coordinates, string newStops, int createdBy) {
            object[] args = new object[] {
                    routeId,
                    coordinates,
                    newStops,
                    createdBy};
            base.Invoke("UpdateRoute", args);
        }
        
        public System.IAsyncResult BeginUpdateRoute(int routeId, string coordinates, string newStops, int createdBy, System.AsyncCallback asyncCallback, object userState) {
            return base.BeginInvoke("UpdateRoute", new object[] {
                        routeId,
                        coordinates,
                        newStops,
                        createdBy}, asyncCallback, userState);
        }
        
        public void EndUpdateRoute(System.IAsyncResult result) {
            object[] args = new object[0];
            base.EndInvoke("UpdateRoute", args, result);
        }
        
        public int SaveRoute(string name, int userId) {
            object[] args = new object[] {
                    name,
                    userId};
            return ((int)(base.Invoke("SaveRoute", args)));
        }
        
        public System.IAsyncResult BeginSaveRoute(string name, int userId, System.AsyncCallback asyncCallback, object userState) {
            return base.BeginInvoke("SaveRoute", new object[] {
                        name,
                        userId}, asyncCallback, userState);
        }
        
        public int EndSaveRoute(System.IAsyncResult result) {
            object[] args = new object[0];
            return ((int)(base.EndInvoke("SaveRoute", args, result)));
        }
        
        public int RouteExists(string name, int userId) {
            object[] args = new object[] {
                    name,
                    userId};
            return ((int)(base.Invoke("RouteExists", args)));
        }
        
        public System.IAsyncResult BeginRouteExists(string name, int userId, System.AsyncCallback asyncCallback, object userState) {
            return base.BeginInvoke("RouteExists", new object[] {
                        name,
                        userId}, asyncCallback, userState);
        }
        
        public int EndRouteExists(System.IAsyncResult result) {
            object[] args = new object[0];
            return ((int)(base.EndInvoke("RouteExists", args, result)));
        }
        
        public string GetStopsForRoute(int userId, int routeId) {
            object[] args = new object[] {
                    userId,
                    routeId};
            return ((string)(base.Invoke("GetStopsForRoute", args)));
        }
        
        public System.IAsyncResult BeginGetStopsForRoute(int userId, int routeId, System.AsyncCallback asyncCallback, object userState) {
            return base.BeginInvoke("GetStopsForRoute", new object[] {
                        userId,
                        routeId}, asyncCallback, userState);
        }
        
        public string EndGetStopsForRoute(System.IAsyncResult result) {
            object[] args = new object[0];
            return ((string)(base.EndInvoke("GetStopsForRoute", args, result)));
        }
        
        public string GetBusCoordinates(int routeId) {
            object[] args = new object[] {
                    routeId};
            return ((string)(base.Invoke("GetBusCoordinates", args)));
        }
        
        public System.IAsyncResult BeginGetBusCoordinates(int routeId, System.AsyncCallback asyncCallback, object userState) {
            return base.BeginInvoke("GetBusCoordinates", new object[] {
                        routeId}, asyncCallback, userState);
        }
        
        public string EndGetBusCoordinates(System.IAsyncResult result) {
            object[] args = new object[0];
            return ((string)(base.EndInvoke("GetBusCoordinates", args, result)));
        }
    }
}
}