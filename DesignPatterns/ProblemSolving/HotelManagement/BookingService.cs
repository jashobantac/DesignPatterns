using System;
using System.Collections.Generic;
using System.Linq;

namespace ProblemSolving.HotelManagement
{
    public class BookingService
    {
        private readonly BranchFactory _branchFactory;
        public BookingService()
        {
            _branchFactory = new BranchFactory();
        }

        public string GetBestPrice(Customer customer, DateTime date)
        {
            Hotel branchA = _branchFactory.GetBranch("A");
            Hotel branchB = _branchFactory.GetBranch("B");
            Hotel branchC = _branchFactory.GetBranch("C");

            List<Hotel> hotels = new List<Hotel>() { branchA, branchB, branchC };
            Hotel bestHotel = hotels.FirstOrDefault();
            int bestPrice = bestHotel.GetPrice(customer, date);
            foreach (Hotel hotel in hotels.Skip(1))
            {
                int price = hotel.GetPrice(customer, date);
                if (price < bestPrice || (price == bestPrice && hotel.Rating > bestHotel.Rating))
                {
                    bestHotel = hotel;
                    bestPrice = price;
                }
            }
            return string.Format("Hotel : {0} | Price {1}", bestHotel.GetType().Name, bestPrice);
        }
    }
}
