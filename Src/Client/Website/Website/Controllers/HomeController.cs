using System.Collections.Generic;
using System.Web.Mvc;
using Kallivayalil.Client;
using Website.Helpers;
using Website.Models;

namespace Website.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var constituentData = HttpHelper.Get<ConstituentData>(@"http://localhost/kallivayalilService/KallivayalilService.svc/Constituents/1");
            var mapper = new AutoDataContractMapper();
            var constituent = new Constituent();
            mapper.Map(constituentData, constituent);


            return View(constituent);
        }

        public ActionResult About()
        {
            return View();
        }

       
    }
}
