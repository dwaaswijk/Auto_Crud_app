using AutoApi.Data;
using AutoApi.DTOs;
using AutoApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AutoApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AutomerkenController : ControllerBase
    {
        private readonly AutoContext _context;

        public AutomerkenController(AutoContext context) => _context = context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AutomerkDto>>> Get()
        {
            return await _context.Automerken
                .Select(a => new AutomerkDto { Id = a.Id, Naam = a.Naam })
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AutomerkDto>> GetById(int id)
        {
            var automerk = await _context.Automerken.FindAsync(id);
            if (automerk == null) return NotFound();
            return new AutomerkDto { Id = automerk.Id, Naam = automerk.Naam };
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateAutomerkDto dto)
        {
            var merk = new Automerk { Naam = dto.Naam };
            _context.Automerken.Add(merk);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = merk.Id }, new AutomerkDto { Id = merk.Id, Naam = merk.Naam });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, CreateAutomerkDto dto)
        {
            var merk = await _context.Automerken.FindAsync(id);
            if (merk == null) return NotFound();

            merk.Naam = dto.Naam;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var merk = await _context.Automerken.FindAsync(id);
            if (merk == null) return NotFound();

            _context.Automerken.Remove(merk);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
