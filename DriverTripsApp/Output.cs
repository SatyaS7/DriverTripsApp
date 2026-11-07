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

		/*public int Compare(object x, object y)
        {
			Output o1 = (Output)x;
			Output o2 = (Output)y;

			if (o1.TotalMiles > o2.TotalMiles)
			{
				return -1;
			}
			else if (o1.TotalMiles < o2.TotalMiles)
			{
				return 1;
			}
			else
				return 0;
		}*/

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
