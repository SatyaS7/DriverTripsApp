using DriverTripsApp.Core.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriverTripsApp.Core.Helpers
{
    public class TripHelper
    {
        public static List<TripModel> ReadFileData(List<string> data)
        {
            var drivers = data.Where(x => x.ToLower().Contains("driver"));
            var trips = data.Where(x => x.ToLower().Contains("trip"));

            var driverData = drivers.Select(x => x.Split(' '));

			var tripData = trips.Select(x => x.Split(' '));

			var driverModelData = driverData.Select(x => new DriverModel()
			{
				Name = x[1].Trim()
			});
			
			var tripModelData = tripData.Select(x => new TripModel()
								{
									DriverName = x[1].Trim(),
									StartTime = x.Length <= 2 ? string.Empty: x[2].Trim(),
									EndTime = x.Length <= 2 ? string.Empty : x[3].Trim(),
									Miles = x.Length <= 2 ? 0 : Convert.ToDecimal(x[4].Trim())
								}).ToList();


			var tripDriverNames = tripData.Select(x => x[1]).ToList();
			var driversNoTrips = driverModelData.Where(x => !tripDriverNames.Contains(x.Name));

/*			foreach(var d in driversNoTrips)
            {
				tripModelData.Add(new TripModel() { DriverName = d.Name });
			}

			foreach(var s in tripModelData)
            {
				Console.WriteLine($"{s.DriverName}, {s.StartTime}, {s.EndTime}, {s.Miles} ");
            }*/

			var driverNames = driverData.Select(x => x[1]).ToList();
            var invalidDrivers = tripModelData.Where(x => !driverNames.Contains(x.DriverName));

            return tripModelData;

        }
    }
}
