namespace ConsoleApp1.LangReview
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class SpecialStock : AbstractAsset
    {
        public decimal CurrentPrice;
        public long Shares;

        public override decimal NetValue
        {
            get
            {
                return CurrentPrice* Shares;
            }
        }
    }
}
