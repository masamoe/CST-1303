namespace ConsoleApp1.Network
{
    using System;
    using System.Net;
    using System.Collections.Generic;
    using System.Text;

    public class HostInformation
    {
        public IPAddress[] GetHostIPAddresses(string hostName)
        {
            // IPHostEntry hostEntry = Dns.Resolve(hostName); // legacy method

            IPHostEntry hostEntry2 = Dns.GetHostEntry(hostName);
            
            return hostEntry2.AddressList;
        }
    }
}