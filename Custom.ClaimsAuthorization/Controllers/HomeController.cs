using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IdentityModel.Services;
using System.Security.Permissions;

namespace Custom.ClaimsAuthorization.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]
        [ClaimsPrincipalPermission(SecurityAction.Demand, Operation = "View", Resource = "Home")]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}