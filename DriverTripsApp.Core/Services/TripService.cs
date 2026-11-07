using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DriverTripsApp.Core.Interfaces;
using DriverTripsApp.Core.Models;

namespace DriverTripsApp.Core.Services
{
    public class TripService : ITripService
    {
        string[] startTime, endTime;
        int startHour, startMinute, endHour, endMinute;
        decimal timeDiff, speed;

        private readonly IDriverService _driverService;

        public TripService(IDriverService driverService)
        {
            _driverService = driverService;
        }

        public void ReportDriverTrips(List<TripModel> Trips)
        {
            _driverService.Save();

            int calculatedSpeed = 0, totalSpeed = 0, averageSpeed = 0, totalMiles = 0, tripsCount = 0, mapValue = 0;
            Dictionary<string, int> map = new Dictionary<string, int>();

            foreach (TripModel trip in Trips)
            {
                int count = 1;
                if (map.TryGetValue(trip.DriverName, out mapValue))
                {
                    if (mapValue == 0)
                    {
                        map.Add(trip.DriverName, 1);
                    }
                }
                else
                {
                    count = count + 1;
                    map.Add(trip.DriverName, count);
                }
            }

            List<Output> outputList = new List<Output>();
            foreach (KeyValuePair<string, int> pair in map)
            {
                if (int.Parse(map[pair.Key].ToString()) > 1)
                {
                    //System.out.println("Key: " + entry.getKey() + "   " + "Value: " + entry.getValue());
                    totalMiles = 0;
                    tripsCount = 0;
                    foreach (TripModel trip in Trips)
                    {

                        if (trip.DriverName.Equals(pair.Key))
                        {
                            tripsCount = tripsCount + 1;
                            calculatedSpeed = (int)CalculatedSpeed(trip);
                            totalSpeed = totalSpeed + calculatedSpeed;
                            averageSpeed = totalSpeed / tripsCount;
                            totalMiles = totalMiles + (int)Math.Round((trip.Miles));

                            //System.out.println("Key: " + entry.getKey() + "   " + "Value: " + entry.getValue() + " tripsCount " + tripsCount);
                            if (tripsCount == pair.Value)
                            {
                                Output output = new Output(trip.DriverName, totalMiles, averageSpeed);
                                outputList.Add(output);
                            }
                        }
                    }
                }
                else if (int.Parse(map[pair.Key].ToString()) == 1)
                {
                    foreach (TripModel trip in Trips)
                    {
                        if (trip.Miles.Equals(pair.Key))
                        {
                            if (trip.Miles != 0)
                            {
                                totalMiles = (int)Math.Round((trip.Miles));                                
                                calculatedSpeed = (int)CalculatedSpeed(trip);
                                Output output = new Output(trip.DriverName, totalMiles, calculatedSpeed);
                                outputList.Add(output);
                            }
                            else
                            {
                                totalMiles = 0;
                                calculatedSpeed = 0;
                                Output output = new Output(trip.DriverName, totalMiles, calculatedSpeed);
                                outputList.Add(output);
                            }
                        }
                    }
                }
            }

            //outputList.Sort();
            foreach (Output output in outputList.OrderByDescending(o => o.TotalMiles))
            {
                if (output.TotalMiles != 0)
                {
                    Console.WriteLine(output.DriverName + ": " + output.TotalMiles + " miles " + "@ " + output.AverageSpeed + " mph");
                }
                else
                {
                    Console.WriteLine(output.DriverName + ": " + output.TotalMiles + " miles");
                }
            }
        }

        public decimal CalculatedSpeed(TripModel trip)
        {
            if (trip.StartTime != null && !string.IsNullOrEmpty(trip.StartTime))
            {
                startTime = trip.StartTime.Split(':');
                startHour = int.Parse(startTime[0].Trim());
                startMinute = int.Parse(startTime[1].Trim());
            }

            if (trip.EndTime != null && !string.IsNullOrEmpty(trip.EndTime))
            {
                endTime = trip.EndTime.Split(':');
                endHour = int.Parse(endTime[0].Trim());
                endMinute = int.Parse(endTime[1].Trim());
            }

            timeDiff = ((endHour - startHour) * 60 + (endMinute - startMinute));
            speed = Math.Round((trip.Miles * 60) / timeDiff);
            //System.out.println(speed);
            return speed;
        }
    }
}
