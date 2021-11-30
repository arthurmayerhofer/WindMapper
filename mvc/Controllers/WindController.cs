using Microsoft.AspNetCore.Mvc;
using mvc.Repositories;

namespace mvc.Controllers
{
    public class WindController : Controller
    {
        private readonly IWindRepository windRepository;

        public WindController(IWindRepository windRepository)
        {
            this.windRepository = windRepository;
        }

        public IActionResult Wind()
        {            
            return View(windRepository.GetWinds());
        }

    }
}
