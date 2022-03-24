#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebDeveloperAPI.Data;
using WebDeveloperDataLayer.Model;

namespace WebDeveloperAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BugTrackersController : ControllerBase
    {
        private readonly WebDeveloperAPIContext _context;

        public BugTrackersController(WebDeveloperAPIContext context)
        {
            _context = context;
        }

        // GET: api/BugTrackers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BugTracker>>> GetBugTracker()
        {
            return await _context.BugTracker.ToListAsync();
        }

        // GET: api/BugTrackers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BugTracker>> GetBugTracker(int id)
        {
            var bugTracker = await _context.BugTracker.FindAsync(id);

            if (bugTracker == null)
            {
                return NotFound();
            }

            return bugTracker;
        }

        // PUT: api/BugTrackers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBugTracker(int id, BugTracker bugTracker)
        {
            if (id != bugTracker.Id)
            {
                return BadRequest();
            }

            _context.Entry(bugTracker).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BugTrackerExists(id))
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

        // POST: api/BugTrackers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<BugTracker>> PostBugTracker(BugTracker bugTracker)
        {
            _context.BugTracker.Add(bugTracker);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBugTracker", new { id = bugTracker.Id }, bugTracker);
        }

        // DELETE: api/BugTrackers/5
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBugTracker(int id)
        {
            var bugTracker = await _context.BugTracker.FindAsync(id);
            if (bugTracker == null)
            {
                return NotFound();
            }

            _context.BugTracker.Remove(bugTracker);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BugTrackerExists(int id)
        {
            return _context.BugTracker.Any(e => e.Id == id);
        }
    }
}
