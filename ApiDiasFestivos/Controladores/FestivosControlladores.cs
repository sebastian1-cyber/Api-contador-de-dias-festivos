using apidiasfestivos.Core.servicios;
using ApiDiasFestivosDominio;
using Microsoft.AspNetCore.Mvc;

namespace Presentacion.Controladores
{
    public class FestivosControlladores
    {
        [Route("api/Festivos")]
        [ApiController]
        public class FestivoControlador : Controller
        {
            private readonly IFestivoServicio servicio;

            public FestivoControlador(IFestivoServicio servicio)
            {
                this.servicio = servicio;
            }

            [HttpGet]
            [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Festivo>))]
            public async Task<ActionResult<IEnumerable<Festivo>>> ObtenerTodos()
            {
                var lista = await servicio.ObtenerTodos();
                return Ok(lista);
            }

            [HttpGet("pais/{IdPais:int}")]
            [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Festivo>))]
            public async Task<ActionResult<IEnumerable<Festivo>>> ObtenerPais(int IdPais)
            {
                var lista = await servicio.Obtener(IdPais);
                return Ok(lista);
            }

        }
    }
}
