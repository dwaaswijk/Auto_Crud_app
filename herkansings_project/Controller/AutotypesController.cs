using AutoApi.Data;
using AutoApi.DTOs;
using AutoApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AutoApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AutotypesController : ControllerBase
    {
        private readonly AutoContext _context;

        public AutotypesController(AutoContext context) => _context = context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AutotypeDto>>> Get()
        {
            return await _context.Autotypes
                .Select(t => new AutotypeDto
                {
                    Id = t.Id,
                    Naam = t.Naam,
                    AutomerkId = t.AutomerkId
                }).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AutotypeDto>> GetById(int id)
        {
            var t = await _context.Autotypes.FindAsync(id);
            if (t == null) return NotFound();

            return new AutotypeDto { Id = t.Id, Naam = t.Naam, AutomerkId = t.AutomerkId };
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateAutotypeDto dto)
        {
            var t = new Autotype { Naam = dto.Naam, AutomerkId = dto.AutomerkId };
            _context.Autotypes.Add(t);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = t.Id }, new AutotypeDto { Id = t.Id, Naam = t.Naam, AutomerkId = t.AutomerkId });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, CreateAutotypeDto dto)
        {
            var t = await _context.Autotypes.FindAsync(id);
            if (t == null) return NotFound();

            t.Naam = dto.Naam;
            t.AutomerkId = dto.AutomerkId;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var t = await _context.Autotypes.FindAsync(id);
            if (t == null) return NotFound();

            _context.Autotypes.Remove(t);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
