using Microsoft.EntityFrameworkCore;
using mvc.DTO;
using mvc.Models;
using mvc.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mvc
{
    public partial class Startup
    {
        class DataService : IDataService
        {
            private readonly ApplicationContext contexto; 
            private readonly IWindRepository windRepository;

            public DataService(ApplicationContext contexto, IWindRepository windRepository)
            {
                this.contexto = contexto;
                this.windRepository = windRepository;
            }

            public void InicializaDB()
            {
                contexto.Database.Migrate();
                windRepository.SetWind();
            }

        }
    }
}
