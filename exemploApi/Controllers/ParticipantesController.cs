using exemploApi.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace exemploApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParticipantesController : ControllerBase
    {
     
            [HttpGet]
            public ActionResult Olá()
            {
                return Ok("olá");
            }


            [HttpGet("ObterParticipantes")]
            public ActionResult ObterParticipantes()
            {
                var data = new DataContext();
                var result = data.Participantes.ToList();

                if (result == null)
                {
                    return BadRequest("Não existe participantes na base de dados.");
                }
                return Ok(result);
            }

          


        }
    }


