using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using GestionReciboSalario.API.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace GestionReciboSalario.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReciboSalariosController : ControllerBase
    {

        private readonly ApplicationDbContext context;

        public ReciboSalariosController(ApplicationDbContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        [HttpGet("", Name = "Obtener todos los recibos")]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                var recibos = await context.ReciboSalarios.ToListAsync();
                return Ok(recibos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
                // throw new Exception(ex.Message);
            }
        }

        [HttpGet("byempleado/{id}", Name = "Obtener los recibos por empleado")]
        public async Task<ActionResult> GetByEmpleadoId(int id)
        {
            try
            {
                var recibos = await context.ReciboSalarios.Where(x => x.EmpleadoId == id).ToListAsync();
                return Ok(recibos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
                // throw new Exception(ex.Message);
            }
        }

        [HttpGet("bygerente/{id}", Name = "Obtener los recibos por gerente")]
        public async Task<ActionResult> GetByRol(int id)
        {
            try
            {
                var recibo = await context.ReciboSalarios.Where(x => x.GerenteId == id).ToListAsync();
                return Ok(recibo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
                // throw new Exception(ex.Message);
            }
        }

        [HttpGet("{id}", Name = "Obtener un recibo por id")]
        public async Task<ActionResult> GetById(int id)
        {

            try
            {
                var recibo = await context.ReciboSalarios.Where(x => x.Id == id).FirstOrDefaultAsync();

                if (recibo == null)
                {
                    return NotFound();
                }

                return Ok(recibo);
            }
            catch (System.Exception exception)
            {
                return BadRequest(exception);
                // throw new Exception(exception.Message);
            }

        }
    }
}
