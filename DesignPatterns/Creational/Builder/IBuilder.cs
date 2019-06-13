namespace Creational.Builder
{
    public interface IBuilder
    {
        void BuildCoreFramework();
        void BuildDatabase();
        void BuildUI();
        void BuildUnitTestFramework();
        void Integrate();
        Framework GetFramework();
    }
}