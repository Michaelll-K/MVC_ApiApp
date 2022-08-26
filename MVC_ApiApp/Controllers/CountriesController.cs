using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC_ApiApp.Models;
using MVC_ApiApp.Tools;

namespace MVC_ApiApp.Controllers
{
    public class CountriesController : Controller
    {
        // GET: CountriesController
        public ActionResult Index()
        {
            CountryManager cm = new CountryManager();

            List<CountryModel> modelList = cm.GetCountries();

            return View(modelList);
        }
    }
}
