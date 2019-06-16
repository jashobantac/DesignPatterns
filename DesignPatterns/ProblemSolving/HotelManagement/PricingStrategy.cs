using System;
using ProblemSolving.HotelManagement.Extensions;

namespace ProblemSolving.HotelManagement
{
    public abstract class PricingStrategy
    {
        public abstract int RegularCustWeekendPrice { get; set; }
        public abstract int RegularCustWeekdayPrice { get; set; }
        public abstract int RewardeeCustWeekendPrice { get; set; }
        public abstract int RewardeeCustWeekdayPrice { get; set; }
        public virtual int GetPrice(Customer customer, DateTime date)
        {
            if (customer is Rewardee)
            {
                if (date.IsWeekend())
                {
                    return RewardeeCustWeekendPrice;
                }
                return RewardeeCustWeekdayPrice;
            }
            else if (customer is Regular)
            {
                if (date.IsWeekend())
                {
                    return RegularCustWeekendPrice;
                }
                return RegularCustWeekdayPrice;
            }
            return RegularCustWeekdayPrice;
        }
    }

    public class HotelAPricingStrategy : PricingStrategy
    {
        public override int RegularCustWeekendPrice { get; set; }
        public override int RegularCustWeekdayPrice { get; set; }
        public override int RewardeeCustWeekendPrice { get; set; }
        public override int RewardeeCustWeekdayPrice { get; set; }

        public HotelAPricingStrategy()
        {
            RegularCustWeekdayPrice = 100;
            RegularCustWeekendPrice = 120;
            RewardeeCustWeekdayPrice = 90;
            RewardeeCustWeekendPrice = 60;
        }
    }

    public class HotelBPricingStrategy : PricingStrategy
    {
        public override int RegularCustWeekendPrice { get; set; }
        public override int RegularCustWeekdayPrice { get; set; }
        public override int RewardeeCustWeekendPrice { get; set; }
        public override int RewardeeCustWeekdayPrice { get; set; }

        public HotelBPricingStrategy()
        {
            RegularCustWeekdayPrice = 130;
            RegularCustWeekendPrice = 150;
            RewardeeCustWeekdayPrice = 100;
            RewardeeCustWeekendPrice = 95;
        }
    }

    public class HotelCPricingStrategy : PricingStrategy
    {
        public override int RegularCustWeekendPrice { get; set; }
        public override int RegularCustWeekdayPrice { get; set; }
        public override int RewardeeCustWeekendPrice { get; set; }
        public override int RewardeeCustWeekdayPrice { get; set; }

        public HotelCPricingStrategy()
        {
            RegularCustWeekdayPrice = 195;
            RegularCustWeekendPrice = 150;
            RewardeeCustWeekdayPrice = 120;
            RewardeeCustWeekendPrice = 90;
        }
    }
}
