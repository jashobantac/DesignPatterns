namespace Creational.Factory
{
    public interface IPrinter
    {
        string Name { get; }
        void Configure();
        void Print();
    }
}
