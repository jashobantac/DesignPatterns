using System;

namespace Creational.Builder
{
    /// <summary>
    /// Concrete Builder.
    /// </summary>
    public class DotnetFrameworkBuilder : IBuilder
    {
        #region Private Variable Declarations.

        private readonly Framework _framework;

        #endregion

        #region Constructors.

        public DotnetFrameworkBuilder(Framework framework)
        {
            _framework = framework;
        }

        #endregion

        #region IBuilder Interface Implementation.

        public void BuildCoreFramework()
        {
            _framework.IsCoreFrameworkReady = true;
            Console.WriteLine("Dotnet Core Framework Build");
        }

        public void BuildDatabase()
        {
            _framework.IsDatabaseReady = true;
            Console.WriteLine("Dotnet Core Database Build");
        }

        public void BuildUI()
        {
            _framework.IsUIReady = true;
            Console.WriteLine("Dotnet Core UI Build");
        }

        public void BuildUnitTestFramework()
        {
            _framework.IsUnitTestFrameworkReady = true;
            Console.WriteLine("Dotnet Unit Test Framework Build");
        }

        public void Integrate()
        {
            _framework.IsIntegrationReady = true;
            Console.WriteLine("Dotnet Integration Framework Build");
        }

        public Framework GetFramework()
        {
            return _framework;
        }

        #endregion
    }
}