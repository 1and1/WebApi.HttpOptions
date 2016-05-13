using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace WebApi.HttpOptions
{
    /// <summary>
    /// Adds a header to all responses.
    /// </summary>
    public class CustomHeaderHandler : DelegatingHandler
    {
        private readonly string _name, _value;

        /// <summary>
        /// Creates a new custom header handler.
        /// </summary>
        /// <param name="name">The name of the header to add.</param>
        /// <param name="value">The value of the header to add.</param>
        public CustomHeaderHandler(string name, string value)
        {
            _name = name;
            _value = value;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var result = await base.SendAsync(request, cancellationToken);
            result.Headers.Add(_name, _value);
            return result;
        }
    }
}