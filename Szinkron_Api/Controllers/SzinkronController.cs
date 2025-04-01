using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Szinkron_Api.Data;
using Szinkron_Api.Models;

namespace Szinkron_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SzinkronController : ControllerBase
    {
        private readonly Szinkron_ApiContext _context;

        public SzinkronController(Szinkron_ApiContext context)
        {
            _context = context;
        }

        // GET: api/Szinkron
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Szinkron>>> GetSzinkron()
        {
            return await _context.Szinkron.ToListAsync();
        }

        // GET: api/Szinkron/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Szinkron>> GetSzinkron(int id)
        {
            var szinkron = await _context.Szinkron.FindAsync(id);

            if (szinkron == null)
            {
                return NotFound();
            }

            return szinkron;
        }

        // PUT: api/Szinkron/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSzinkron(int id, Szinkron szinkron)
        {
            if (id != szinkron.Id)
            {
                return BadRequest();
            }

            _context.Entry(szinkron).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SzinkronExists(id))
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

        // POST: api/Szinkron
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Szinkron>> PostSzinkron(Szinkron szinkron)
        {
            _context.Szinkron.Add(szinkron);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSzinkron", new { id = szinkron.Id }, szinkron);
        }

        // DELETE: api/Szinkron/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSzinkron(int id)
        {
            var szinkron = await _context.Szinkron.FindAsync(id);
            if (szinkron == null)
            {
                return NotFound();
            }

            _context.Szinkron.Remove(szinkron);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SzinkronExists(int id)
        {
            return _context.Szinkron.Any(e => e.Id == id);
        }
        [HttpGet("heltai-olga")]
        public async Task<IActionResult> HeltaiOlga()
        {
            var filmek = await _context
                .Film
                .Where(f => f.MagyarSzoveg == "Heltai Olga")
                .Select(f => new
                {
                    angol = f.Eredeti,
                    magyar = f.Cim
                })
                .ToListAsync();

            return Ok(filmek);
        }
        [HttpGet("uj-rendezok")]
        public async Task<IActionResult> UjRendezok()
        {
            var rendezok = (await _context.
                Film
                .Where(f => f.Ev >= 2000)
                .Select(f => new
                {
                    filmrendezo = f.Rendezo,
                    szinkronrendezo = f.SzinkronRendezo
                })
                .ToListAsync())
                .Distinct();
            return Ok(rendezok);
        }
        [HttpGet("nolan-mafilm")]
        public async Task<IActionResult> NolanMafilmAudio()
        {
            var szovegirok = await _context
                .Film
                .Where(f => f.Rendezo == "Christopher Nolan" && f.Studio == "Mafilm Audio Kft.")
                .Select(f => new
                    {
                        iro = f.MagyarSzoveg,
                        cim = f.Cim
                    }
                )
                .OrderBy(f => f.iro)
                .ToListAsync();

            return Ok(szovegirok);
        }
    }
}
