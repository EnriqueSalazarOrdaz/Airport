using Airport.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Airport.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetFlights()
        {
            IEnumerable<SchedulePlan> schedulePlan = GetDataFromAPI("http://localhost:64648/api/AirportSchedule/", "GetAllSchedulePlan");


            return View("Index",schedulePlan);
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

        public ActionResult Detail(int Id)
        {
            IEnumerable<SchedulePlan> schedulePlan = GetDataFromAPI("http://localhost:64648/api/AirportSchedule/", "GetAllSchedulePlan");
            SchedulePlan element = schedulePlan.Where(x => x.Id == Id).First();
            return View(element);
        }
        
        private IEnumerable<SchedulePlan> GetDataFromAPI(string url,string action)
        {
            IEnumerable<SchedulePlan> schedulePlan = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);

                var responseTask = client.GetAsync(action);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<SchedulePlan>>();
                    readTask.Wait();
                    schedulePlan = readTask.Result;
                }
                else
                {
                    schedulePlan = Enumerable.Empty<SchedulePlan>();
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return schedulePlan;
        }
    }
}