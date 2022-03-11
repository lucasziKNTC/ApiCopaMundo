using exemploApi.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace exemploApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SorteioController : ControllerBase
    {
        [HttpGet]
        public ActionResult Olá()
        {
            return Ok("olá");
        }

        [HttpPost("RealizarSorteio")] 
        public ActionResult Sorteio()
        {
            var data = new DataContext();
            var listaPaises  = data.Paises.ToList();

            foreach (var pais in listaPaises)
            {
                if(pais.Sede == true)
                {
                    data.Participantes.AddAsync(pais);
                }
            }
            
            return Ok (listaPaises);
        }





    }
}
