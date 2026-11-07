using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace DriverTripsApp
{
    class ReadInputFileData
    {
        public ArrayList ReadFileData(string textFile)
        {
			if (File.Exists(textFile))
			{
				//Console.WriteLine("File Exists");
				string[] lines = File.ReadAllLines(textFile);

				Driver driver;
				Trip trip;
				ArrayList trips = new ArrayList();
				ArrayList tripDrivers = new ArrayList();
				ArrayList tripDriversCopy = new ArrayList();
				ArrayList drivers = new ArrayList();
				ArrayList driverNames = new ArrayList();

				string[] arr;
				foreach (string line in lines)
				{
					arr = line.Split(' ');

					if (line.Contains("Driver"))
					{
						driver = new Driver();
						driver.setDriverName(arr[1]);

						drivers.Add(driver);
						driverNames.Add(driver.getDriverName());
					}

					if (line.Contains("Trip"))
					{
						trip = new Trip();
						trip.setDriverName(arr[1]);
						trip.setStartTime(arr[2]);
						trip.setEndTime(arr[3]);
						trip.setMiles(arr[4]);

						trips.Add(trip);
						tripDrivers.Add(trip.getDriverName());
					}
				}

				tripDriversCopy.Add(tripDrivers.Clone());

				foreach (string s in driverNames)
				{
					tripDriversCopy.Remove(s);
				}

				if (!tripDrivers.Equals(tripDriversCopy))
				{
					Console.WriteLine("Driver does not exist");
				}

				//System.out.println(driverNames.toString());
				//driverNames.removeIf(x->tripDrivers.contains(x));
				foreach (string s in tripDrivers)
				{
					driverNames.Remove(s);
				}

				//System.out.println(driverNames.toString());

				if (driverNames.Count > 0)
				{
					foreach (string driverName in driverNames)
					{
						trip = new Trip();
						trip.setDriverName(driverName);
						trip.setMiles("0");

						trips.Add(trip);
					}
				}
				return trips;
			}
			else
				Console.WriteLine("File Does Not Exist");
				return new ArrayList();
			
        }
    }
}
