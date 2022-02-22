using exemploApi.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SorteioCopa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfederacaoController : ControllerBase
    {

        [HttpGet]
        public ActionResult Olá()
        {
            return Ok("olá");
        }


        [HttpGet("ObterConfederacoes")]
        public ActionResult ObterConfederacoes()
        {
            var data = new DataContext();
            var result = data.Confederacao.ToList();

            if (result == null)
            {
                return BadRequest("Não existe confederações na base de dados.");
            }
            return Ok(result);
        }


        

    }
}