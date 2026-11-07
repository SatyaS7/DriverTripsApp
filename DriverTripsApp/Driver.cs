using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriverTripsApp
{
    class Driver
    {
		private String DriverName;

		public String getDriverName()
		{
			return DriverName;
		}

		public void setDriverName(String driverName)
		{
			DriverName = driverName;
		}

		public override string ToString()
		{
			return "Driver [DriverName=" + DriverName + "]";
		}
    }

}
