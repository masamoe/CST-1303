namespace ConsoleApp1.Network
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Text;

    public class HostInformation
    {
        public IPAddress[] GetHostIPAddresses(string hostName)
        {
            // IPHostEntry hostEntry = Dns.Resolve(hostName); // legacy method
            IPHostEntry hostEntry = Dns.GetHostEntry(hostName);

            return hostEntry.AddressList;
        }
    }
}
