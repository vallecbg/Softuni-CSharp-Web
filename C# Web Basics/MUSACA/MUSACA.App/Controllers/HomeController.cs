using System;
using SIS.MvcFramework;
using SIS.MvcFramework.Attributes;
using SIS.MvcFramework.Result;

namespace MUSACA.App.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet(Url = "/")]
        public ActionResult IndexSlash()
        {
            return Index();
        }
        public ActionResult Index()
        {
            if (User != null)
            {
                return this.Redirect("Users/Index");
            }
            return this.View();
        }
    }
}
