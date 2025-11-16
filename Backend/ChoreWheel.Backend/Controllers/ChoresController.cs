using ChoreWheel.Backend.Data.Database;
using ChoreWheel.Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ChoreWheel.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChoresController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ChoresController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Chores
        [HttpGet]
        public async Task<ActionResult<List<Chore>>> GetChore()
        {
            return await _context.Chore.ToListAsync();
        }

        // GET: api/Chores/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Chore>> GetChore(int id)
        {
            var chore = await _context.Chore.FindAsync(id);

            if (chore == null)
            {
                return NotFound();
            }

            return chore;
        }

        // PUT: api/Chores/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChore(int id, Chore chore)
        {
            if (id != chore.Id)
            {
                return BadRequest();
            }

            _context.Entry(chore).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChoreExists(id))
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

        // POST: api/Chores
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Chore>> PostChore(Chore chore)
        {
            _context.Chore.Add(chore);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetChore", new { id = chore.Id }, chore);
        }

        // DELETE: api/Chores/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChore(int id)
        {
            var chore = await _context.Chore.FindAsync(id);
            if (chore == null)
            {
                return NotFound();
            }

            _context.Chore.Remove(chore);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ChoreExists(int id)
        {
            return _context.Chore.Any(e => e.Id == id);
        }
    }
}
