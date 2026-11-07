using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriverTripsApp.Core.Models
{
    public class TripModel
    {
        public int DriverId { get; set; }

        public string DriverName { get; set; }

        public string StartTime { get; set; }

        public string EndTime { get; set; }

        public decimal Miles { get; set; }

        //private DriverModel driverModel;// Entity Framework class to database
    }
}
