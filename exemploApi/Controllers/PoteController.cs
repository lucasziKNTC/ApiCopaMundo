using exemploApi.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace exemploApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PoteController : ControllerBase
    {

        [HttpGet]

        public ActionResult AdicionarPote()
        {
            return Ok("oksdfkskdfksdfs");
        }

        [HttpGet("ObterPote")]

        public ActionResult ObterPotes()
        {
            var data = new DataContext();
            var result = data.Pote.ToList();

            if (result == null)
            {
                return BadRequest("Não existe potes na base de dados.");
            }
            return Ok(result);
        }

    }
}