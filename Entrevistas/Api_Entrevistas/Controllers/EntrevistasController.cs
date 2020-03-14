namespace Api_Entrevistas.Controllers
{
    using Entrevistas.BusinessLogic.Interfaces;
    using Entrevistas.DataAccess.Contexts;
    using Entrevistas.DataAccess.Entities;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    [ApiController]
    public class EntrevistasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IEntrevistaCrud _entrevistaCrud;

        public EntrevistasController(ApplicationDbContext context, IEntrevistaCrud entrevistaCrud)
        {
            _context = context;
            _entrevistaCrud = entrevistaCrud;
        }

        // GET: api/Entrevistas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Entrevista>>> GetEntrevistas()
        {
            var entrevistas = await _entrevistaCrud.GetEntrevistas();

            return Ok(entrevistas);
        }

        // GET: api/Entrevistas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Entrevista>> GetEntrevista(int id)
        {
            var entrevista = await _context.Entrevistas.FindAsync(id);

            if (entrevista == null)
            {
                return NotFound();
            }

            return entrevista;
        }

        // PUT: api/Entrevistas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEntrevista(int id, Entrevista entrevista)
        {
            if (id != entrevista.Id)
            {
                return BadRequest();
            }

            _context.Entry(entrevista).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EntrevistaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Entrevistas
        [HttpPost]
        public async Task<ActionResult<Entrevista>> PostEntrevista(Entrevista entrevista)
        {
            _context.Entrevistas.Add(entrevista);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEntrevista", new { id = entrevista.Id }, entrevista);
        }

        // DELETE: api/Entrevistas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Entrevista>> DeleteEntrevista(int id)
        {
            var entrevista = await _context.Entrevistas.FindAsync(id);
            if (entrevista == null)
            {
                return NotFound();
            }

            _context.Entrevistas.Remove(entrevista);
            await _context.SaveChangesAsync();

            return entrevista;
        }

        private bool EntrevistaExists(int id)
        {
            return _context.Entrevistas.Any(e => e.Id == id);
        }
    }
}
