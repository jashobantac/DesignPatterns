namespace ProblemSolving.MovieRental
{
    public class Rental
    {
        public Movie Movie { get; set; }
        public int NumOfDays { get; set; }

        public Rental(Movie movie, int numOfDays)
        {
            Movie = movie;
            NumOfDays = numOfDays;
        }

        public override string ToString()
        {
            return string.Format("Name : {0} Number of Days :{1}", Movie.Title, NumOfDays);
        }
    }
}
