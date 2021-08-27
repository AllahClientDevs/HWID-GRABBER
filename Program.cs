using System;

namespace Allah_HWID_Grabber
{
    class Program
    {
        static void Main(string[] args)
        {
            HWiDGrabber grabber = new HWiDGrabber();
            Console.WriteLine(grabber.DriveID());
            Console.ReadKey();
        }
    }
}
