using exemploApi.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace exemploApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GruposController : ControllerBase
    {

        [HttpGet]
        public ActionResult Olá()
        {
            return Ok("olá");
        }


        [HttpGet("ObterGrupos")]
        public ActionResult ObterGrupos()
        {
            var data = new DataContext();
            var result = data.Grupos.ToList();

            if (result == null)
            {
                return BadRequest("Não existe confederações na base de dados.");
            }
            return Ok(result);

        }
    }
}
