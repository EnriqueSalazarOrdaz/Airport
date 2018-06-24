using System;
using System.Collections.Generic;
using Airport.Models;
using Airport.Core;
namespace Airport.Client
{
    public class ReadSchedule
    {
        public List<SchedulePlan> getAll()
        {
            ManagerSchedulePlan managerSchedulePlan = new ManagerSchedulePlan();
            return managerSchedulePlan.getAll();
        }
    }
}
