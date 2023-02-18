namespace ConsoleApp1.LangReview
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Asset
    {
        public string Name { get; set; }

        public virtual decimal GetLiability()
        {
            return 0;
        }
    }
}
