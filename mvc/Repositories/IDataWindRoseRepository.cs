using mvc.DTO;
using System.Threading.Tasks;

namespace mvc.Repositories
{
    public interface IDataWindRoseRepository
    {
        Task<DataWindRoseViewModel> GetDataWindRose();
    }
}