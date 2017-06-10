using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IOC.Interface.Business;
using IOC.FW.Factory;

namespace IOC.Web.Controllers
{
    public class OcupationController : Controller
    {
        private readonly IOcupationBusiness iBusiness;

        public OcupationController()
        {
            this.iBusiness = InstanceFactory.GetImplementation<IOcupationBusiness>();
        }

        public ActionResult Index()
        {
            var ocupation = this.iBusiness.MethodOcupation();
            return View();
        }
    }
}
