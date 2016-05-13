using System.Reflection;
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

        /// <summary>
        /// Adds an instance of <see cref="HttpHeadHandler"/> to <see cref="HttpConfiguration.MessageHandlers"/>.
        /// </summary>
        public static HttpConfiguration EnableHttpHead(this HttpConfiguration config)
        {
            config.MessageHandlers.Add(new HttpHeadHandler());
            return config;
        }

        /// <summary>
        /// Adds an instance of <see cref="CustomHeaderHandler"/> to <see cref="HttpConfiguration.MessageHandlers"/> using the calling assembly name and version.
        /// </summary>
        public static HttpConfiguration EnableVersionHeader(this HttpConfiguration config)
        {
            var assembly = Assembly.GetCallingAssembly().GetName();

            config.MessageHandlers.Add(new CustomHeaderHandler(
                name: "X-" + assembly.Name + "-Version",
                value: assembly.Version.ToString()));
            return config;
        }
    }
}
