using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriverTripsApp.Core.Models
{
    class DriverTripModel
    {
		public DriverTripModel(string driverName, int totalMiles, int averageSpeed)
		{
			DriverName = driverName;
			TotalMiles = totalMiles;
			AverageSpeed = averageSpeed;
		}
		public string DriverName { get; set; }

		public int TotalMiles { get; set; }

		public int AverageSpeed { get; set; }

	}
}
