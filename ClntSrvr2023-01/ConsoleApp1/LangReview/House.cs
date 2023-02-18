namespace ConsoleApp1.LangReview
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class House : Asset
    {
        public decimal Mortgage { get; set; }

        public override decimal GetLiability()
        {
            var baseValue = base.GetLiability();

            return baseValue + ( Mortgage / 2);
        }
    }
}
