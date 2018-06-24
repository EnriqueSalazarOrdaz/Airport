using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Airport.Models;

namespace Airport.Core
{
    public class ManagerSchedulePlan
    {
        AirportEntities DB;
        public List<SchedulePlan> getAll()
        {
            /* at this part is better to consult the database but in this case, I put like that, 
             * because when we are using the entity framework is necessary to make some setups, 
             * that's why I decided to make it. 
             * like that just download and run it.
             * PLEASE read the note if you want to know how I implemented EF
             */
            List<SchedulePlan> result = new List<SchedulePlan>()
            {
                new SchedulePlan{Id=1,FromCity="LGA", ToCity="FLL",Depart=new TimeSpan(6,0,0), Arrives=new TimeSpan(8,55,0),LayoverCity=null,LayoverTime=null,Airline="JetBlue",Price=233},
                new SchedulePlan{Id=2,FromCity="JFK", ToCity="MIA",Depart=new TimeSpan(6,0,0), Arrives=new TimeSpan(11,10,0),LayoverCity="IAD",LayoverTime=new TimeSpan(1,0,0),Airline="United",Price=289},
                new SchedulePlan{Id=3,FromCity="LGA", ToCity="MIA",Depart=new TimeSpan(6,10,0), Arrives=new TimeSpan(11,20,0),LayoverCity="CVG",LayoverTime=new TimeSpan(0,30,0),Airline="Delta",Price=220},
                new SchedulePlan{Id=4,FromCity="LGA", ToCity="MIA",Depart=new TimeSpan(6,15,0), Arrives=new TimeSpan(11,30,0),LayoverCity="CVG",LayoverTime=new TimeSpan(0,45,0),Airline="Delta",Price=218},
                new SchedulePlan{Id=5,FromCity="LGA", ToCity="MIA",Depart=new TimeSpan(6,15,0), Arrives=new TimeSpan(11,5,0),LayoverCity="IAD",LayoverTime=new TimeSpan(1,0,0),Airline="United",Price=289},
                new SchedulePlan{Id=6,FromCity="LGA", ToCity="FLL",Depart=new TimeSpan(6,20,0), Arrives=new TimeSpan(12,0,0),LayoverCity="CLE",LayoverTime=new TimeSpan(1,30,0),Airline="Continental",Price=762},
                new SchedulePlan{Id=7,FromCity="EWR", ToCity="MIA",Depart=new TimeSpan(6,30,0), Arrives=new TimeSpan(9,30,0),LayoverCity=null,LayoverTime=null,Airline="Continental",Price=239}
            };
            /* NOTE: I applied Entity Framework, if you want to try how its work, just uncomment "result=GetSchedulePlan()"
             * and ALSO you need to publish the DB (right click-->publish(I already put the script for post deploy),
             * and you must update the connection string 
             */
            
            
            //the next line that you need to uncomment if you want to try using E.F.
            //result = GetSchedulePlan();
            return result;
        }
        private List<SchedulePlan> GetSchedulePlan()
        {
            var cities = GetAllCities();
            var airlines = GetAllAirlines();
            var schedules = GetAllSchedules();
            var schedulePlan = from a in airlines
                               join s in schedules
                                  on a.Id equals s.AirlineID
                               select new SchedulePlan
                               {
                                   Id = s.Id,
                                   FromCity = GetWhichCity(cities, s.FromCityID),
                                   ToCity = GetWhichCity(cities, s.ToCityID),
                                   Depart = s.Depart,
                                   Arrives = s.Arrives,
                                   LayoverCity = GetWhichCity(cities, s.LayoverCityID),
                                   LayoverTime = s.LayoverTime,
                                   Airline = a.name,
                                   Price = s.Price
                               };
            return schedulePlan.ToList<SchedulePlan>();
        }
        private string GetWhichCity(List<City> list, int? id)
        {
            if (id == null)
                return "";
            return list.Where(x => x.Id == id).First().acronyms;
        }
        private List<City> GetAllCities()
        {
            DB = new AirportEntities();
            return DB.City.ToList();
        }
        private List<Airline> GetAllAirlines()
        {
            DB = new AirportEntities();
            return DB.Airline.ToList();
        }
        private List<Schedule> GetAllSchedules()
        {
            DB = new AirportEntities();
            return DB.Schedule.ToList();
        }
    }
}
