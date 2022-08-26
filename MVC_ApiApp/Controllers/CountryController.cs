using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC_ApiApp.Models;
using MVC_ApiApp.Tools;

namespace MVC_ApiApp.Controllers
{
    public class CountryController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            CountryManager cm = new CountryManager();

            List<CountryModel> modelList = cm.GetCountries();

            //Sorted list of Countries
            modelList = modelList.OrderByDescending(x => x.TotalConfirmed).Take(20).ToList();

            return View(modelList);
        }

    }
}
