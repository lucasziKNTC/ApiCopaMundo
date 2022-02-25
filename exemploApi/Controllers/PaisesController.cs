using exemploApi.Context;
using exemploApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace exemploApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaisesController : ControllerBase
    {

        [HttpGet]
        public ActionResult Olá()
        {
            return Ok("olá");
        }


        [HttpGet("ObterPaises")]
        public ActionResult ObterConfederacoes()
        {
            var data = new DataContext();
            var result = data.Paises.ToList();

            if (result == null)
            {
                return BadRequest("Não existe Paises na base de dados.");
            }
            return Ok(result);
        }
        
        [HttpPost("AdicionarPais")]
        public ActionResult AdicionarPais(Paises paises)
        {
            var data = new DataContext();
            var result = data.Paises.FirstOrDefault(f => f.ID == paises.ID);

            if(result == null)
            {
                data.Paises.Add(paises);
                data.SaveChanges();
                return Ok("Pais cadastrado com sucesso!!");
            }


            return BadRequest("ERRO PAIS JA EXISTE NA BASE DE DADOS");
        }



    }
}
