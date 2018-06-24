using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Airport.Models;
using Airport.Client;
using Newtonsoft.Json;

namespace Airport.WebAPI.Controllers
{
    public class AirportScheduleController : ApiController
    {
        public IEnumerable<SchedulePlan> GetAllSchedulePlan()
        {
            ReadSchedule readSchedule = new ReadSchedule();
//            var result=JsonConvert.SerializeObject(readSchedule.getAll());
            return readSchedule.getAll();
        }
        
    }
}
