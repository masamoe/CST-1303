namespace ConsoleApp1
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            var program = new Program();
            program.TestHostInformation();
        }

        private void TestHostInformation()
        {
            var hostInformation = new Network.HostInformation();
            var hostEntry = hostInformation.GetHostInformation("localhost");
            Console.WriteLine(hostEntry.HostName);
        }
    }
}