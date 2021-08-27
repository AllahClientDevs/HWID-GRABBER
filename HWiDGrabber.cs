using System;
using System.Collections.Generic;
using System.Text;
using System.Management;

public class HWiDGrabber
{
    public string DriveID(string ID = null)
    {
        return GetWin32("Win32_DiskDrive", ID ?? "SerialNumber");
    }

    public string GetWin32(string Selection, string ID)
    {
        using (ManagementObjectSearcher searcher = new ManagementObjectSearcher($"SELECT * FROM {Selection}"))
        {
            try
            {
                var collection = searcher.Get().GetEnumerator();
                return collection.MoveNext() ? collection.Current[ID].ToString() : "0";
            }
            catch (ManagementException Error)
            {
                switch (Error.ErrorCode)
                {
                    case ManagementStatus.NotFound:
                        return "ID Not Found";
                    case ManagementStatus.InvalidClass:
                        return "Invalid Class";
                    default:
                        return "0";
                }
            }
        }
    }
}
