using System.Web.Optimization;
using System.Web.Routing;

namespace CitizensWeb
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            //Стили
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
