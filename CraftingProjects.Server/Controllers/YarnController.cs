using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CraftingProjects.Server.Models;

namespace CraftingProjects.Server.Controllers
{
    [Route("api/yarn")]
    [ApiController]
    public class YarnController : ControllerBase
    {

        private readonly CraftingProjectsContext _dbContext;

        public YarnController(CraftingProjectsContext dbContext) { 
            _dbContext = dbContext;
        }

        [HttpGet]

        public IActionResult GetYarn()
        {
            List<Yarn> list = _dbContext.Yarns.ToList();
            return StatusCode(StatusCodes.Status200OK, list);

        }
    }
}
