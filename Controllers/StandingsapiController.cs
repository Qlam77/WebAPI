using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SQLiteWeb.Data;
using SQLiteWeb.Models;

namespace SQLiteWeb.Controllers
{
    [Produces("application/json")]
    [Route("api/Standingsapi")]
    public class StandingsapiController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StandingsapiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Standingsapi
        [HttpGet]
        public IEnumerable<Standings> GetStandings()
        {
            return _context.Standings;
        }

        // GET: api/Standingsapi/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStandings([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var standings = await _context.Standings.SingleOrDefaultAsync(m => m.StandingsId == id);

            if (standings == null)
            {
                return NotFound();
            }

            return Ok(standings);
        }

        // PUT: api/Standingsapi/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStandings([FromRoute] int id, [FromBody] Standings standings)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != standings.StandingsId)
            {
                return BadRequest();
            }

            _context.Entry(standings).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StandingsExists(id))
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

        // POST: api/Standingsapi
        [HttpPost]
        public async Task<IActionResult> PostStandings([FromBody] Standings standings)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Standings.Add(standings);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStandings", new { id = standings.StandingsId }, standings);
        }

        // DELETE: api/Standingsapi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStandings([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var standings = await _context.Standings.SingleOrDefaultAsync(m => m.StandingsId == id);
            if (standings == null)
            {
                return NotFound();
            }

            _context.Standings.Remove(standings);
            await _context.SaveChangesAsync();

            return Ok(standings);
        }

        private bool StandingsExists(int id)
        {
            return _context.Standings.Any(e => e.StandingsId == id);
        }
    }
}