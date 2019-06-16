namespace ProblemSolving.MovieRental
{
    //[Flags()]
    public enum Category
    {
        Regular,
        Kids,
        NewRelease
    }

    public abstract class Movie
    {
        public string Title { get; set; }
        private Price Price { get; set; }
        public Category Category { get; set; }

        public Movie(string title, int price, Category category)
        {
            Title = title;
            Price = price;
            Category = category;
        }

        public virtual int GetPrice()
        {
            return Price;
        }
    }
}
