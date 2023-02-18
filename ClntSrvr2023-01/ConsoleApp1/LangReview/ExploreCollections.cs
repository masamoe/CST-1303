namespace ConsoleApp1.LangReview
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Text;

    public class ExploreCollections
    {
        public void UsePrintNames()
        {
            StringCollection names = new StringCollection();
            names.Add("Tom");
            names.Add("Helm");
            names.Add("Gama");

            this.PrintNames(names);
        }

        public void PrintNames(StringCollection names)
        {
            foreach(string name in names)
            {
                Console.WriteLine(name);
            }
        }

        public void PrintNames(List<string> names)
        {
            foreach (string name in names)
            {
                Console.WriteLine(name);
            }
        }
    }
}
