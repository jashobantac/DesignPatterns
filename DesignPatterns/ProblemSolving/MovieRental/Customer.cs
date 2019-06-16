using System.Collections.Generic;

namespace ProblemSolving.MovieRental
{
    public class Customer
    {
        private readonly List<Rental> _rentals = null;

        #region Public Properties.

        public string Name { get; set; }
        public Address Address { get; set; }

        #endregion

        #region Constructors.

        public Customer(string name)
        {
            Name = name;
            _rentals = new List<Rental>();
        }

        public Customer(string name, Address address) : this(name)
        {
            Address = address;
        }

        #endregion

        public void AddRental(Rental rental)
        {
            _rentals.Add(rental);
        }

        public string PrintStatement()
        {
            double totalPrice = 0;
            int frequentRentalPoints = 0;
            string result = "Printing Rental for " + Name;
            foreach (Rental rental in _rentals)
            {
                Movie movie = rental.Movie;
                switch (movie.Category)
                {
                    case Category.Regular:
                        totalPrice += 2;
                        if (rental.NumOfDays > 2)
                        {
                            totalPrice += (rental.NumOfDays - 2) * 1.5;
                        }
                        break;
                    case Category.Kids:
                        totalPrice += rental.NumOfDays * 3;
                        break;
                    case Category.NewRelease:
                        totalPrice += 1.5;
                        if (rental.NumOfDays > 1)
                        {
                            frequentRentalPoints += 1;
                        }
                        if (rental.NumOfDays > 3)
                        {
                            totalPrice += (rental.NumOfDays - 3) * 1.5;
                        }
                        break;
                }
                frequentRentalPoints++;
                result += rental.ToString();
            }
            result += "Total Price : " + totalPrice;
            return result;
        }
    }
}
