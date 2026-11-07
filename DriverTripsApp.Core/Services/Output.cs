using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriverTripsApp
{
    class Output //IComparer
    {
		public Output(string driverName, int totalMiles, int averageSpeed)
		{
			DriverName = driverName;
			TotalMiles = totalMiles;
			AverageSpeed = averageSpeed;
		}
		public string DriverName { get; set; }

		public int TotalMiles { get; set; }
		
		public int AverageSpeed { get; set; }

		public void printResult()
		{
			if (TotalMiles != 0)
			{
				Console.WriteLine(DriverName + ": " + TotalMiles + " miles " + "@ " + AverageSpeed + " mph");
			}
			else
			{
				Console.WriteLine(DriverName + ": " + TotalMiles + " miles");
			}
		}
	}
}
