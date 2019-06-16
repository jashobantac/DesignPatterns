using System;

namespace ProblemSolving.HotelManagement
{
    public abstract class Hotel
    {
        private readonly PricingStrategy _strategy;

        public abstract int Rating { get; set; }

        public Hotel(PricingStrategy strategy)
        {
            _strategy = strategy;
        }

        public virtual int GetPrice(Customer customer, DateTime date)
        {
            return _strategy.GetPrice(customer, date);
        }
    }

    public class BranchA : Hotel
    {
        public override int Rating { get; set; }
        public BranchA(PricingStrategy strategy) : base(strategy)
        {
            Rating = 3;
        }
    }

    public class BranchB : Hotel
    {
        public override int Rating { get; set; }
        public BranchB(PricingStrategy strategy) : base(strategy)
        {
            Rating = 5;
        }
    }

    public class BranchC : Hotel
    {
        public override int Rating { get; set; }

        public BranchC(PricingStrategy strategy) : base(strategy)
        {
            Rating = 4;
        }
    }
}
