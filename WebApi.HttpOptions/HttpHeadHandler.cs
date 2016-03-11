using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace WebApi.HttpOptions
{
    /// <summary>
    /// Handles HTTP HEAD requests using HTTP GET controller methods.
    /// </summary>
    public class HttpHeadHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (request.Method != HttpMethod.Head)
                return await base.SendAsync(request, cancellationToken);

            request.Method = HttpMethod.Get;
            var response = await base.SendAsync(request, cancellationToken);
            if (response.Content != null)
            {
                if (response.IsSuccessStatusCode) response.StatusCode = HttpStatusCode.NoContent;

                var oldContent = await response.Content.ReadAsByteArrayAsync();

                var content = new StringContent("");
                content.Headers.Clear();
                foreach (var header in response.Content.Headers)
                    content.Headers.Add(header.Key, header.Value);
                content.Headers.ContentLength = oldContent.Length;

                response.Content = content;
            }
            return response;
        }
    }
}