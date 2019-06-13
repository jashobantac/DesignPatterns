using System;

namespace Creational.Builder
{
    /// <summary>
    /// Concrete Builder.
    /// </summary>
    ///
    public class JavaFrameworkBuilder : IBuilder
    {
        #region IBuilder Interface Implementation.

        private readonly Framework _framework;

        #endregion

        #region Constructor.

        public JavaFrameworkBuilder(Framework framework)
        {
            _framework = framework;
        }

        #endregion

        #region IBuilder Interface Implementation.

        public void BuildCoreFramework()
        {
            _framework.IsCoreFrameworkReady = true;
            Console.WriteLine("Java Core Framework Build");
        }

        public void BuildDatabase()
        {
            _framework.IsDatabaseReady = true;
            Console.WriteLine("Java Core Database Build");
        }

        public void BuildUI()
        {
            _framework.IsUIReady = true;
            Console.WriteLine("Java Core UI Build");
        }

        public void BuildUnitTestFramework()
        {
            _framework.IsUnitTestFrameworkReady = true;
            Console.WriteLine("Java Unit Test Framework Build");
        }

        public void Integrate()
        {
            _framework.IsIntegrationReady = true;
            Console.WriteLine("Java Integration Framework Build");
        }

        public Framework GetFramework()
        {
            return _framework;
        }

        #endregion
    }
}
