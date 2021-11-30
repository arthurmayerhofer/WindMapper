using mvc.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace mvc.Repositories
{
    public class WindRepository : IWindRepository
    {
        private readonly ApplicationContext contexto;

        public WindRepository(ApplicationContext contexto)
        {
            this.contexto = contexto;
        }
        
        public void SetWind()
        {
            Random intVel = new Random();
            Random intDir = new Random();

            int cont = 0;

            while(cont <= 300)
            {
                float floatVel = (float)(intVel.NextDouble());
                float floatDir = (float)(intDir.NextDouble()*100);

                if (floatVel > 4) floatVel = 4;
                if (floatVel < 0) floatVel = 0;
                if (floatDir < 0) floatDir = 0;

                string dt = DateTime.UtcNow.AddDays(new Random().Next(90)).ToString();
                
                var wind = new Wind(dt, floatVel, floatDir);

                contexto.Set<Wind>().Add(wind);

                cont += 1;
            }

            cont = 0;
            while (cont <= 700)
            {
                float floatVel = (float)(intVel.NextDouble() * 10);
                float floatDir = (float)(intDir.NextDouble() * 1000) ;

                if (floatVel > 4) floatVel = 4;
                if (floatDir > 360) floatDir = 360;
                if (floatVel < 0) floatVel = 0;
                if (floatDir < 0) floatDir = 0;


                string dt = DateTime.UtcNow.AddDays(new Random().Next(90)).ToString();

                var wind = new Wind(dt, floatVel, floatDir);

                contexto.Set<Wind>().Add(wind);

                cont += 1;
            }
            contexto.SaveChanges();
        }

        public IList<Wind> GetWinds()
        {
            return contexto.Set<Wind>().ToList();
        }
    }
}
