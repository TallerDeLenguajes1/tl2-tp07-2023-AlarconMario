using Microsoft.AspNetCore.Mvc;
using TP7;

namespace tl2_tp07_2023_AlarconMario.Controllers
{

    [ApiController]
    [Route("Tarea")]
    public class TareaController : ControllerBase
    {
        private ManejoDeTareas manejoTarea;
        private readonly ILogger<TareaController> _logger;

        public TareaController(ILogger<TareaController> logger)
        {
            _logger = logger;
            AccesoADatos accesoTareas = new AccesoADatos();
            manejoTarea = new ManejoDeTareas(accesoTareas);
        }

        [HttpPost]
        [Route("CrearTarea")]
        public ActionResult<Tarea> CrearTarea(Tarea tarea)
        {
            var newTarea = manejoTarea.crearTarea(tarea);
            return Ok(newTarea);
        }

        [HttpGet("Buscartarea")]
        public ActionResult<Tarea> BuscarTarea(int id)
        {
            if(manejoTarea.IdTareaExiste(id))
            {
                var tarea = manejoTarea.ObtenerTarea(id);
                return tarea;
            }
            else
            {
                return BadRequest("Tarea no econtrada");
            }
        }

        [HttpPut("ActualizarTarea")]
        public ActionResult<Tarea> actualizarTarea(int idTarea, int estado)
        {
            if(manejoTarea.IdTareaExiste(idTarea))
            {
                List<Tarea> listaActualizada = manejoTarea.actualizarTarea(idTarea, estado);
                return Ok($"El estado de la Tarea {idTarea} fue cambiado a {estado}");
            }
            else
            {
                return BadRequest($"La tarea {idTarea} no existe");
            }
            
        }

        [HttpPut("EliminarTarea")]

        public IActionResult eliminarTarea(int idTarea)
        {
            if(manejoTarea.IdTareaExiste(idTarea))
            {
                manejoTarea.EliminarTarea(idTarea);
                return Ok("Tarea eliminda con exito");
            }
            else
            {
                return BadRequest($"La tarea {idTarea} no existe.");
            }
            
        }

        [HttpGet("ListaDeTareas")]
        public ActionResult<List<Tarea>> ListaTareas()
        {
            return Ok(manejoTarea.ListarTareas());
        }

        
        [HttpGet("ListaDeTareasCompletadas")]
        public ActionResult<List<Tarea>> TareasCompletadas()
        {
            return Ok(manejoTarea.ListaTareasCompletadas());
        }
    }
}