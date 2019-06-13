using Creational.Builder;

namespace Driver
{
    public class BuilderDemo : IDemo
    {
        public void Run()
        {
            Framework framework = new Framework();
            IBuilder javaFrameworkBuilder = new JavaFrameworkBuilder(framework);
            IFrameworkDeveloper javaDeveloper = new Developer(javaFrameworkBuilder);
            javaDeveloper.BuildFramework();
            framework = javaDeveloper.Framework;

            IBuilder dotnetFrameworkBuilder = new DotnetFrameworkBuilder(framework);
            IFrameworkDeveloper dotnetDeveloper = new Developer(dotnetFrameworkBuilder);
            dotnetDeveloper.BuildFramework();
            framework = dotnetDeveloper.Framework;
        }
    }
}
