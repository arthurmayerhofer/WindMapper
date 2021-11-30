using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mvc.Models
{
    public class Humidity : Base
    {
        public string DataHora { get; set; }
        public float UmidTemp { get; set; }
        public float Umidade { get; set; }
        public float UR { get; set; }
    }
}
