using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Airport.Models
{
    public class SchedulePlan
    {
        public int Id { get; set; }
        public string FromCity { get; set; }
        public string ToCity { get; set; }
        public TimeSpan Depart { get; set; }
        public TimeSpan Arrives { get; set; }
        [DisplayName("Layover City")]
        public string LayoverCity { get; set; }
        [DisplayName("Layover Time")]
        public TimeSpan? LayoverTime { get; set; }
        public decimal Price { get; set; }
        public string Airline { get; set; }
    }
}