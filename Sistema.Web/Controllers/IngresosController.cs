using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema.Datos;
using Sistema.Entidades.Almacen;
using Sistema.Web.Models.Almacen.Ingreso;

namespace Sistema.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngresosController : ControllerBase
    {
        private readonly DbContextSistema _context;

        public IngresosController(DbContextSistema context)
        {
            _context = context;
        }

        // GET: api/Ingresos/Listar
        [Authorize(Roles = "Administrador,Almacenero")]
        [HttpGet("[action]")]
        public async Task<IEnumerable<IngresoViewModel>> Listar()
        {
            var ingreso = await _context.Ingresos
                    .Include(i => i.usuario)
                    .Include(i => i.persona)
                    .OrderByDescending(i => i.idingreso)//Obtener los mas recientes primeros
                    .Take(100)
                    .ToListAsync();

            return ingreso.Select(i => new IngresoViewModel
            {
                idingreso   = i.idingreso,
                idproveedor = i.idproveedor,
                proveedor   = i.persona.nombre,
                idusuario   = i.idusuario,
                usuario     = i.usuario.nombre,
                tipo_comprobante = i.tipo_comprobante,
                serie_comprobante = i.serie_comprobante,
                num_comprobante  = i.num_comprobante,
                fecha_hora       = i.fecha_hora,
                impuesto    = i.impuesto,
                total       = i.total,
                estado      = i.estado,

            });

        }

        // POST: api/Imgresos/Crear
        [Authorize(Roles = "Administrador,Almacenero")]
        [HttpPost("[action]")]
        public async Task<IActionResult> Crear([FromBody] CrearViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var fechaHora = DateTime.Now;

            Ingreso ingreso = new Ingreso {
                idproveedor = model.idproveedor,
                idusuario = model.idusuario,
                tipo_comprobante = model.tipo_comprobante,
                serie_comprobante = model.serie_comprobante,
                num_comprobante = model.num_comprobante,
                fecha_hora = fechaHora,
                impuesto   = model.impuesto,
                total      = model.total,
                estado     = "Aceptado",
                
            };

            try
            {
                _context.Ingresos.Add(ingreso);
                await _context.SaveChangesAsync();

                var id = ingreso.idingreso;
                foreach (var det in model.dellates) {

                    DetalleIngreso detalle = new DetalleIngreso {
                        idingreso  = id,
                        idarticulo = det.idarticulo,
                        cantidad   = det.cantidad,
                        precio     = det.precio
                    };
                    _context.DetallesIngresos.Add(detalle);
                }
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

            return Ok();
        }



        private bool IngresoExists(int id)
        {
            return _context.Ingresos.Any(e => e.idingreso == id);
        }
    }
}
