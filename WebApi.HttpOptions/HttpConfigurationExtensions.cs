using System.Web.Http;

namespace WebApi.HttpOptions
{
    public static class HttpConfigurationExtensions
    {
        /// <summary>
        /// Adds an instance of <see cref="HttpOptionsHandler"/> to <see cref="HttpConfiguration.MessageHandlers"/>.
        /// </summary>
        public static HttpConfiguration EnableHttpOptions(this HttpConfiguration config)
        {
            config.MessageHandlers.Add(new HttpOptionsHandler());
            return config;
        }
    }
}
