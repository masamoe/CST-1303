using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace DocumentAPITestApp
{
    public static class ApiTestHelper
    {
        public static void WriteTestStart(string name)
        {
            Console.WriteLine($"\n === Starting test {name}. ===");
        }
    }
}
