using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace diskinfo
{
    class Program
    {
        private static String BytesToString(long byteCount)
        {
            string[] suf = { "B", "KB", "MB", "GB", "TB", "PB", "EB" }; //Longs run out around EB
            if (byteCount == 0)
                return "0" + suf[0];
            long mbytes = Math.Abs(byteCount);
            int place = Convert.ToInt32(Math.Floor(Math.Log(mbytes, 1024)));
            double num = Math.Round(mbytes / Math.Pow(1024, place), 1);
            return (Math.Sign(byteCount) * num).ToString() + suf[place];
        }

        static void Main(string[] args)
        {
            Console.WriteLine("AssureStor Disk Info Utility");
            Console.WriteLine();
            DriveInfo[] allDrives = DriveInfo.GetDrives();
            foreach (DriveInfo d in allDrives)
            {
                Console.WriteLine("Drive {0}", d.Name);
                Console.WriteLine("  Drive type: {0}", d.DriveType);
                if (d.IsReady == true)
                {
                    Console.WriteLine("  Volume label: {0}", d.VolumeLabel);
                    Console.WriteLine("  File system: {0}", d.DriveFormat);
                    Console.WriteLine(
                        "  Available space to current user:{0, 15}",
                        BytesToString(d.AvailableFreeSpace));

                    Console.WriteLine(
                        "  Total available space:          {0, 15}",
                         BytesToString(d.TotalFreeSpace));

                    Console.WriteLine(
                        "  Total size of drive:            {0, 15} ",
                         BytesToString(d.TotalSize));

                    Console.WriteLine();
                }
            }
            Console.ReadKey();
        }
    }
}
