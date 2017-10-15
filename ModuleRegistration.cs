using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

[assembly: PreApplicationStartMethod(typeof(PersistentWebService.ModuleRegistration), "RegisterDummyWatchdogModule")]
namespace PersistentWebService
{
    public class ModuleRegistration
    {
        public static void RegisterDummyWatchdogModule()
        {
            HttpApplication.RegisterModule(typeof(DummyWatchdogModule));
        }
    }
}
