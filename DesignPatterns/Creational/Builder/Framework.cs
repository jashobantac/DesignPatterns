namespace Creational.Builder
{
    public class Framework
    {
        public bool IsCoreFrameworkReady { get; set; }
        public bool IsDatabaseReady { get; set; }
        public bool IsUIReady { get; set; }
        public bool IsUnitTestFrameworkReady { get; set; }
        public bool IsIntegrationReady { get; set; }
    }
}