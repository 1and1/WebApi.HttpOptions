using System.Web.Http;

namespace WebApi.HttpOptions.Sample.Controllers
{
    public class SampleController : ApiController
    {
        /// <summary>
        /// Endpoint that only supports HTTP GET.
        /// </summary>
        [HttpGet, Route("get-only")]
        public string GetOnly()
        {
            return "Some content";
        }

        /// <summary>
        /// The HTTP GET implementation of an endpoint that supports both HTTP GET and PUT.
        /// </summary>
        [HttpGet, Route("read-writable")]
        public string ReadWritableGet()
        {
            return "Some content";
        }

        /// <summary>
        /// The HTTP GET implementation of an endpoint that supports both HTTP GET and PUT.
        /// </summary>
        [HttpPut, Route("read-writable")]
        public void ReadWritablePut()
        {
        }

        /// <summary>
        /// Endpoint that only supports HTTP POST.
        /// </summary>
        [HttpPost, Route("post-only")]
        public string PostOnly()
        {
            return "Some content";
        }
    }
}