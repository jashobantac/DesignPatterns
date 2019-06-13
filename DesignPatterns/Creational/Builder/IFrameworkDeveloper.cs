namespace Creational.Builder
{
    public interface IFrameworkDeveloper
    {
        void BuildFramework();
        Framework Framework { get; }
    }
}