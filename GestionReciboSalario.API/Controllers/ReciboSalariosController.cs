using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using GestionReciboSalario.API.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using FastReport;
using Microsoft.Extensions.Configuration;
using System.IO;
using FastReport.Export.PdfSimple;

namespace GestionReciboSalario.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReciboSalariosController : ControllerBase
    {

        private readonly ApplicationDbContext context;
        private readonly IConfiguration configuration;

        public ReciboSalariosController(ApplicationDbContext context, IConfiguration configuration)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
            this.configuration = configuration;
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
        [HttpGet("reporte/{id}", Name = "Crear reporte del recibo de salario")]
        public ActionResult GetReporteSalario(int id)
        {
            try
            {
                Report report = new Report();
                report.Report.Load("recibosalario.frx");
                report.Report.Dictionary.Connections[0].ConnectionString = configuration.GetConnectionString("DefaultConnection");

                report.Report.SetParameterValue("param", id);
                report.Prepare();

                Response.ContentType = "application/pdf";
                Response.Headers.Add("Content-disposition", "inline");

                using (MemoryStream ms = new MemoryStream())
                {
                    PDFSimpleExport pdfExport = new PDFSimpleExport() { OpenAfterExport = true };
                    pdfExport.Export(report.Report, ms);

                    return File(ms.ToArray(), "application/pdf");
                };
            }
            catch (System.Exception exception)
            {
                System.Console.WriteLine(exception);
                throw new Exception(exception.Message);
            }

        }
    }
}
