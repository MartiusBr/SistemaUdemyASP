using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema.Datos;
using Sistema.Entidades.Almacen;

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

     

        private bool IngresoExists(int id)
        {
            return _context.Ingresos.Any(e => e.idingreso == id);
        }
    }
}
