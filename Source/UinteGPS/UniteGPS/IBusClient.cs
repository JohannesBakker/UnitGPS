using System;
using System.Collections.Generic;

namespace UniteGPS
{
	public interface IBusClient
	{
		string LogOnParent(string userName, string password);
		string LogOnDriver(string userName, string password);
		List<RoutesResponse> GetRoutes(int userId);
		List<RoutesResponse> GetRoutesWithStops(int userId);
		AuthResponse UpdateRoute(int routeId, string coordinates, string newStops, int createdBy);

		// Removed 17/FEB/2015 10:50 PM
		AuthResponse SaveStudentPosition(double latitude, double longitude, int bearing, int speed, string collectTime, int userId, int studentId, int routeId, Guid executionId);
		string GetStudents(int userId);
		AuthResponse SaveFirstPoint(int routeId, double latitude, double longitude, DateTime collectTime, int userId, int esec, int bearing, int speed, int status, Guid executionId);
		AuthResponse SaveLastPoint(int routeId, double latitude, double longitude, DateTime collectTime, int userId, int esec, int bearing, int speed, int status, Guid executionId);

		// New Implementations 17/FEB/2015  10:34 
		List<StopsForRouteResponse> GetStopsForRoute (int userId,int routeId);
		int SaveRoute (string name, int userId);
		int RouteExists (string name, int userId);
		string GetBusCoordinates (int routeId);
	}
}

