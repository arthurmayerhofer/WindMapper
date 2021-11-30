using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace mvc.Controllers
{
    [Route("windrose")]
    [ApiController]
    public class DataWindRoseController : ControllerBase
    {
        private readonly IDataWindRoseService dataWindRoseService;

        public DataWindRoseController(IDataWindRoseService dataWindRoseService)
        {
            this.dataWindRoseService = dataWindRoseService;
        }

        [Route("getdata")]
        public async Task<ObjectResult> GetDataWindRose()
        {
            var result = await dataWindRoseService.GetDataWindRose();

            return Ok(result);
        }
    }
}

