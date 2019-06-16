namespace ProblemSolving.HotelManagement
{
    public class BranchFactory
    {
        public Hotel GetBranch(string location)
        {
            switch (location.ToUpper())
            {
                case "A":
                    return new BranchA(new HotelAPricingStrategy());
                case "B":
                    return new BranchB(new HotelAPricingStrategy());
                case "C":
                    return new BranchC(new HotelAPricingStrategy());
                default:
                    break;
            }
            return null;
        }
    }
}
