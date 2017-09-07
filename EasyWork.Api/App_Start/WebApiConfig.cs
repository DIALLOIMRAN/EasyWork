using System.Web.Http;

namespace EasyWork
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuration et services API Web

            // Itinéraires de l'API Web
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //var json = config.Formatters.JsonFormatter;
            //    json.SerializerSettings.NullValueHandling =
            //    Newtonsoft.Json.NullValueHandling.Include;

            config.Formatters.Remove(config.Formatters.XmlFormatter);
            //config.Formatters.Add()
        }
    }
}
