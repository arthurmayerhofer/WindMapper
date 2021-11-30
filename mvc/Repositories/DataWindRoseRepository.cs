using Microsoft.EntityFrameworkCore;
using mvc.DTO;
using mvc.Models;
using System.Linq;
using System.Threading.Tasks;

namespace mvc.Repositories
{
    public class DataWindRoseRepository : IDataWindRoseRepository
    {
        private readonly ApplicationContext contexto;
        protected readonly DbSet<Wind> DbSet;

        public DataWindRoseRepository(ApplicationContext contexto)
        {
            this.contexto = contexto;
            DbSet = contexto.Set<Wind>();
        }
       
        public async Task<DataWindRoseViewModel> GetDataWindRose()
        {
            var dataWindRoseViewModel = new DataWindRoseViewModel();

            foreach (var h in await contexto.Set<Wind>().AsNoTracking()
                .Select(p => new { p.Velocidade, p.Direcao })
                .Take(1000)
                .ToListAsync())
            {
                dataWindRoseViewModel.Velocidade.Add(h.Velocidade);	

                dataWindRoseViewModel.Direcao.Add(h.Direcao);
            }

            return dataWindRoseViewModel;
        }
    }
}


