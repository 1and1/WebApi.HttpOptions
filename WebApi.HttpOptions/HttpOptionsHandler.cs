using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Routing;

namespace WebApi.HttpOptions
{
    /// <summary>
    /// Handles HTTP OPTIONS requests and injects "Allow" headers into HTTP responses.
    /// </summary>
    public class HttpOptionsHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var supportedMethods = GetSupportedMethods(request).ToList();

            var resp = (request.Method == HttpMethod.Options)
                ? request.CreateResponse(HttpStatusCode.OK,
                    "Supported HTTP Methods: " + string.Join(",", supportedMethods.Select(x => x.Method)))
                : await base.SendAsync(request, cancellationToken);

            if (resp.Content != null && resp.Content.Headers.Allow.Count == 0)
            {
                foreach (var method in supportedMethods)
                    resp.Content.Headers.Allow.Add(method.Method);
            }

            return resp;
        }

        private IEnumerable<HttpMethod> GetSupportedMethods(HttpRequestMessage request)
        {
            var routeData = request.GetRouteData();
            if (routeData == null) return Enumerable.Empty<HttpMethod>();
            else if (routeData.Values.ContainsKey("controller"))
            {
                var apiExplorer = request.GetConfiguration().Services.GetApiExplorer();
                return apiExplorer.ApiDescriptions
                    .Where(x => x.ActionDescriptor.ControllerDescriptor.ControllerName.Equals(
                        routeData.Values["controller"] as string, StringComparison.OrdinalIgnoreCase))
                    .Select(d => d.HttpMethod)
                    .Distinct();
            }
            else if (routeData.Values.ContainsKey("MS_SubRoutes"))
            {
                return routeData.GetSubRoutes()
                    .SelectMany(x => (HttpActionDescriptor[]) x.Route.DataTokens["actions"])
                    .SelectMany(x => x.SupportedHttpMethods).Distinct();
            }
            else return Enumerable.Empty<HttpMethod>();
        }
    }
}