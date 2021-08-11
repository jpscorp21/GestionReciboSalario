using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Extensions.Configuration;
using GestionReciboSalario.API.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using GestionReciboSalario.API.Entities;

namespace GestionReciboSalario.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadosController : ControllerBase
    {

        private readonly ApplicationDbContext context;

        public EmpleadosController(ApplicationDbContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        [HttpGet("", Name = "Obtener todos los empleados")]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                var empleados = await context.Empleados.ToListAsync();
                return Ok(empleados);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
                // throw new Exception(ex.Message);
            }
        }

        [HttpGet("byrol/{rol}", Name = "Obtener empleados por su rol")]
        public async Task<ActionResult> GetByRol(Rol rol)
        {
            try
            {
                var empleados = await context.Empleados.Where(x => x.Rol == rol).ToListAsync();
                return Ok(empleados);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
                // throw new Exception(ex.Message);
            }
        }

        [HttpGet("{id}", Name = "Obtener un empleado por id")]
        public async Task<ActionResult> GetById(int id)
        {

            try
            {
                var empleado = await context.Empleados.Where(x => x.Id == id).FirstOrDefaultAsync();

                if (empleado == null)
                {
                    return NotFound();
                }

                return Ok(empleado);
            }
            catch (System.Exception exception)
            {
                return BadRequest(exception);
                // throw new Exception(exception.Message);
            }

        }

        [HttpPost("login", Name = "Obtener un empleado por sus credenciales")]
        public async Task<ActionResult> Login([FromBody] Empleado data)
        {

            try
            {
                var empleado = await context.Empleados
                    .Where(x => x.Password.Contains(data.Password) && x.Usuario.Contains(data.Usuario))
                    .FirstOrDefaultAsync();

                if (empleado == null)
                {
                    return NotFound();
                }

                return Ok(empleado);
            }
            catch (System.Exception exception)
            {
                return BadRequest(exception);
                // throw new Exception(exception.Message);
            }

        }
    }
}
