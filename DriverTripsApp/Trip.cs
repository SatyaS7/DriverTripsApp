using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriverTripsApp
{
    class Trip
    {
		private String driverName;
		public String getDriverName()
		{
			return driverName;
		}
		public void setDriverName(String driverName)
		{
			if (string.IsNullOrEmpty(driverName))
			{
				this.driverName = "";
			}
			this.driverName = driverName;
		}

		private String startTime;
		public String getStartTime()
		{
			return startTime;
		}
		public void setStartTime(String startTime)
		{
			if (string.IsNullOrEmpty(startTime))
			{
				this.startTime = "";
			}
			this.startTime = startTime;
		}

		private String endTime;
		public String getEndTime()
		{
			return endTime;
		}
		public void setEndTime(String endTime)
		{
			if (string.IsNullOrEmpty(endTime))
			{
				this.endTime = "";
			}
			this.endTime = endTime;
		}

		private String miles;
		public String getMiles()
		{
			return miles;
		}
		public void setMiles(String miles)
		{
			if (string.IsNullOrEmpty(miles))
			{
				this.miles = "";
			}
			this.miles = miles;
		}

	public override String ToString()
		{
			return "Trip [driverName=" + driverName + ", startTime=" + startTime + ", endTime=" + endTime + ", miles="
					+ miles + "]";
		}
	}
}
