namespace ConsoleApp1.Network
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;

    public class HostInformation
    {
        public IPAddress[] GetHostIPAddresses(string hostName)
        {
            // IPHostEntry hostEntry = Dns.Resolve(hostName); // legacy method
            IPHostEntry hostEntry = Dns.GetHostEntry(hostName);

            return hostEntry.AddressList;
        }

        public void IPAddressing()
        {
            IPAddress ip1 = IPAddress.Parse("101.102.103.104");
            IPEndPoint ep1 = new IPEndPoint(ip1, 55555);
        }


        public async Task<string> GetFromService(string baseUri, string id)
        {
            string documentAsString = null;
            try
            {
                var httpClient = new HttpClient();

                // https://localhost:44385/api/document?id=ha12 -- https://localhost:44385/api/document?id={id}";
                var uri = $"{baseUri}?id={id}";
                documentAsString = await httpClient.GetStringAsync(uri);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return documentAsString;
        }

        public async void GetAsync()
        {
            var httpClient = new HttpClient();
            var uri = "https://localhost:44385/api/document?id=ha12";
            HttpResponseMessage response = await httpClient.GetAsync(uri);

            var httpRequest = new HttpRequestMessage(HttpMethod.Post, uri);

            httpRequest.Content = new StringContent("the string test content");
            var response2 = await httpClient.SendAsync(httpRequest);

            response2.EnsureSuccessStatusCode();
        }

    }
}
