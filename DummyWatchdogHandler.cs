using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Routing;

namespace PersistentWebService
{
    public class DummyWatchdogHandler : IHttpHandler,IRouteHandler
    {
        public bool IsReusable
        {
            get { return false; }
        }

        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            return this;
        }

        public void ProcessRequest(HttpContext context)
        {
            context.Response.Write("FeedDog");
        }
    }
}
