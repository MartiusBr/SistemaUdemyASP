using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema.Datos;
using Sistema.Entidades.Usuarios;
using Sistema.Web.Models.Usuarios.Usuario;

namespace Sistema.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly DbContextSistema _context;

        public UsuariosController(DbContextSistema context)
        {
            _context = context;
        }

        // GET: api/Usuarios/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<UsuarioViewModel>> Listar()
        {
            var usuario = await _context.Usuarios.Include(u => u.rol).ToListAsync();

            return usuario.Select(u => new UsuarioViewModel
            {
                idusuario = u.idusuario,
                idrol= u.idrol,
                rol = u.rol.nombre,
                nombre = u.nombre,
                tipo_documento = u.tipo_documento,
                num_documento = u.num_documento,
                direccion = u.direccion,
                telefono = u.telefono,
                email = u.email,
                password_hash = u.password_hash,
                condicion = u.condicion

            });

        }

        private bool UsuarioExists(int id)
        {
            return _context.Usuarios.Any(e => e.idusuario == id);
        }
    }
}