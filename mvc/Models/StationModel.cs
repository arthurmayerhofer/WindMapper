using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mvc.Models
{
    public class Station : Base
    {
        public string Nome { get; set; }
        public string Local { get; set; }
        public float Temperatura { get; set; }
        public Wind Vento { get; set; }
        public Humidity Umidade { get; set; }

    }
}
