using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriverTripsApp.Common.Helpers
{
    public static class FileHelper
    {
        public static List<string> ReadAllLines(string filePath)
        {
            if (File.Exists(filePath))
            {
                return File.ReadAllLines(filePath).ToList();
            }
            throw new Exception("File not found");            
        }
    }
}
