using System.Web.Http;
using WebApi.HttpOptions;

namespace HttpOptionsSample
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.EnableHttpOptions();
            config.EnableHttpHead();

            config.EnsureInitialized();
        }
    }
}