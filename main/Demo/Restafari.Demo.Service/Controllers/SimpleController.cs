using System;
using System.Web.Http;

namespace Restafari.Demo.Service.Controllers
{
    public class SimpleController : ApiController
    {
        public Guid Get()
        {
            return Guid.NewGuid();
        }
    }
}
