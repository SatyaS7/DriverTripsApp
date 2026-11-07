using DriverTripsApp.Core.Models;
using System.Collections.Generic;

namespace DriverTripsApp.Core.Interfaces
{
    public interface ITripService
    {
        decimal CalculatedSpeed(TripModel trip);
        void ReportDriverTrips(List<TripModel> Trips);
    }
}