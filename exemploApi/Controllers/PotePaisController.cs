using exemploApi.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace exemploApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PotePaisController : ControllerBase
    {


        [HttpGet]
        public ActionResult Olá()
        {
            return Ok("olá");
        }


        [HttpGet("ObterPaises")]
        public ActionResult ObterPotePais()
        {
            var data = new DataContext();
            var result = data.PotePais.ToList();

            if (result == null)
            {
                return BadRequest("Não existe Paises na base de dados.");
            }
            return Ok(result);
        }
    }
}

