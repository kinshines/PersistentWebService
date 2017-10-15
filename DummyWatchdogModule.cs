using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace PersistentWebService
{
    public class DummyWatchdogModule:IHttpModule
    {
        private static string _domainUrl = "";
        
        private const string DummyPageUrl = "/handler/_dummywatchdog";
        public void Init(HttpApplication app)
        {
            app.BeginRequest += (src, args) =>
            {
                if (_domainUrl == "")
                {
                    var iisBindPort = ConfigurationManager.AppSettings["iisbindport"];
                    if (!string.IsNullOrWhiteSpace(iisBindPort))
                    {
                        _domainUrl = "http://localhost:" + iisBindPort;
                    }
                    else
                    {
                        _domainUrl = app.Request.Url.Scheme + "://" + app.Request.Url.Host;
                        if (app.Request.Url.Port != 80)
                        {
                            _domainUrl += ":" + app.Request.Url.Port;
                        }
                        if (app.Request.ApplicationPath != "/")
                        {
                            _domainUrl += app.Request.ApplicationPath;
                        }
                    }
                    
                    CacheHandle.RegisterCacheEntry(_domainUrl + DummyPageUrl);
                }
                if (app.Request.Url.ToString() == _domainUrl + DummyPageUrl)
                {
                    CacheHandle.RegisterCacheEntry(app.Request.Url.ToString());
                }
            };
        }

        public void Dispose()
        {
        }
    }
}
