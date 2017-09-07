using EasyWork.App_Start;
using System.Web;
using System.Web.Http;

namespace EasyWork
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            //GlobalConfiguration.Configure(WebApiConfig.Register);

            var config = GlobalConfiguration.Configuration;            
            WebApiConfig.Register(config);
            Bootstrapper.Run();
            GlobalConfiguration.Configuration.EnsureInitialized();
            AutoMapperConfig.ReguisterMappings();
        }
    }
}
