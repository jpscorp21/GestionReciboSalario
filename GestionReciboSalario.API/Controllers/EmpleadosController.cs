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
using System.Net.Http;
using FastReport;
using FastReport.Export.PdfSimple;

namespace GestionReciboSalario.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadosController : ControllerBase
    {

        private readonly IHttpClientFactory httpClientFactory;
        private readonly ApplicationDbContext context;

        private readonly IConfiguration configuration;

        public EmpleadosController(ApplicationDbContext context, IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
            this.httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(IHttpClientFactory));
            this.configuration = configuration;
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

        [HttpGet("firmaempleado/{id}/{reciboid}")]
        public async Task<ActionResult> GetTest(int id, int reciboid)
        {
            try
            {
                var recibo = await context.ReciboSalarios.Include(x => x.Empleado).Include(x => x.Gerente).Where(x => x.EmpleadoId == id && x.Id == reciboid).FirstOrDefaultAsync();
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

                    var multiForm = new MultipartFormDataContent();
                    multiForm.Add(new StringContent(recibo.Empleado.NombreEmpleado), "nombre_empleado");
                    multiForm.Add(new StringContent(recibo.Gerente.NombreEmpleado), "nombre_gerente");
                    multiForm.Add(new ByteArrayContent(ms.ToArray()), "salario_pdf", "doc.pdf");

                    var client = httpClientFactory.CreateClient();
                    var res = await client.PostAsync("http://localhost:3000/api/firmarPdfEmpleadoGerente", multiForm);

                    recibo.FirmaEmpleado = true;
                    context.Update(recibo);
                    await context.SaveChangesAsync();

                    // return Ok(res.Content.ReadAsStream());

                    return File(res.Content.ReadAsStream(), "application/pdf");
                    // return File(ms.ToArray(), "application/pdf");
                };
            }
            // try
            // {

            //     mul
            //     var request = new HttpRequestMessage(HttpMethod.Get,
            //         "https://jsonplaceholder.typicode.com/todos"
            //     );

            //     var client = httpClientFactory.CreateClient();
            //     var response = await client.SendAsync(request);
            //     var result = await response.Content.ReadAsStringAsync();




            //     // var empleados = await context.Empleados.ToListAsync();
            //     return Ok(result);
            // }
            catch (Exception ex)
            {
                return BadRequest(ex);
                // throw new Exception(ex.Message);
            }
        }

        [HttpGet("firmagerente/{id}/{reciboid}")]
        public async Task<ActionResult> GetGerente(int id, int reciboid)
        {
            try
            {

                var recibo = await context.ReciboSalarios.Include(x => x.Gerente).Where(x => x.GerenteId == id && x.Id == reciboid).FirstOrDefaultAsync();

                Report report = new Report();
                report.Report.Load("recibosalario.frx");
                report.Report.Dictionary.Connections[0].ConnectionString = configuration.GetConnectionString("DefaultConnection");

                report.Report.SetParameterValue("param", recibo.EmpleadoId);
                report.Prepare();

                Response.ContentType = "application/pdf";
                Response.Headers.Add("Content-disposition", "inline");

                using (MemoryStream ms = new MemoryStream())
                {
                    PDFSimpleExport pdfExport = new PDFSimpleExport() { OpenAfterExport = true };
                    pdfExport.Export(report.Report, ms);

                    var multiForm = new MultipartFormDataContent();
                    multiForm.Add(new StringContent(recibo.Gerente.NombreEmpleado), "nombre_gerente");
                    multiForm.Add(new ByteArrayContent(ms.ToArray()), "salario_pdf", "doc.pdf");



                    var client = httpClientFactory.CreateClient();
                    var res = await client.PostAsync("http://localhost:3000/api/firmarPdfGerente", multiForm);

                    recibo.FirmaGerente = true;
                    context.ReciboSalarios.Update(recibo);
                    await context.SaveChangesAsync();

                    return File(res.Content.ReadAsStream(), "application/pdf");
                    // return File(ms.ToArray(), "application/pdf");
                };
            }
            // try
            // {

            //     mul
            //     var request = new HttpRequestMessage(HttpMethod.Get,
            //         "https://jsonplaceholder.typicode.com/todos"
            //     );

            //     var client = httpClientFactory.CreateClient();
            //     var response = await client.SendAsync(request);
            //     var result = await response.Content.ReadAsStringAsync();




            //     // var empleados = await context.Empleados.ToListAsync();
            //     return Ok(result);
            // }
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
