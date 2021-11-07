using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LightFeather.Models
{
    public class Supervisor
    {
        public long id { get; set; }
        public string phone { get; set; }
        public string jurisdiction { get; set; }
        public string identificationNumber { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
    }

    public class Submit
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string supervisor { get; set; }
    }
}
