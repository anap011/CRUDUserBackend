using CRUDUser.DTOs;
using CRUDUser.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUDUser.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private TestContext _context;

        public UsuarioController(TestContext context) {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<UsuarioDto>> Get() =>
            await _context.Usuarios.Select(u => new UsuarioDto
            {
                Id = u.IdUsuario,
                Name = u.NameUsuario
            }).ToListAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioDto>> GetById(int id) {
            var usuario = await _context.Usuarios.FindAsync(id);

            if (usuario == null) { 
                return NotFound();
            }

            var usuarioDto = new UsuarioDto
            {
                Id = usuario.IdUsuario,
                Name = usuario.NameUsuario
            };

            return Ok(usuarioDto);
        }



    }
}
