using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using DriverTripsApp.Common.Helpers;
using DriverTripsApp.Core.Helpers;
using DriverTripsApp.Core.Services;
using Unity;
using DriverTripsApp.Core.Interfaces;

namespace DriverTripsApp
{
    class Program
    {
		string[] startTime, endTime;
		int startHour, startMinute, endHour, endMinute;
		double timeDiff, speed;

        static void Main(string[] args)
        {
			//ArrayList trips = new ArrayList();
			//string textFile = @"\\AppData\DriverTrips.txt";
			//string textFile = "DriverTrips.txt";
			string[] textFile = System.IO.Directory.GetFiles("AppData");
			IUnityContainer container = new UnityContainer();
			container.RegisterType<IDriverService, DriverService>();
			container.RegisterType<ITripService, TripService>();
			//If there is another service called Trip2Service that implements the ITripService? (1)
			var tripService = container.Resolve<TripService>();

			foreach (string s in textFile)
            {
				var data = FileHelper.ReadAllLines(s);
				if(data.Count > 0)
                {
					var trips = TripHelper.ReadFileData(data);
					if(trips.Count > 0)
					{
						// When call the below method, which TripService is executed, TripServcie or Trip2Service (2)
						tripService.ReportDriverTrips(trips);
					}
                }
			}
			Console.ReadLine();
		}
    }
}
