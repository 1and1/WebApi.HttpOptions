using System.Web.Http;

namespace WebApi.HttpOptions.Sample
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();
            config.EnableHttpOptions();
        }
    }
}