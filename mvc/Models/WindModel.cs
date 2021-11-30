using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace mvc.Models
{
    public class Wind : Base
    {
       
        public string DataHora { get; set; }
        public float Velocidade { get; set; }
        public float Direcao { get; set; }

        public Wind()
        {
        }
        public Wind(string data, float v, float d)
        {
            DataHora = data;
            Velocidade = v;
            Direcao = d;
        }
    }
}
