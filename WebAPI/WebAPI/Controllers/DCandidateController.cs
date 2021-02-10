using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DCandidateController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public DCandidateController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: api/DCandidate
        [HttpGet]
        [Authorize(AuthenticationSchemes =  JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<IEnumerable<DPost>>> GetPosts()
        {
            return await _context.Posts.ToListAsync();
        }

        // GET: api/DCandidate/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DPost>> GetDCandidate(int id)
        {
            var dCandidate = await _context.Posts.FindAsync(id);

            if (dCandidate == null)
            {
                return NotFound();
            }

            return dCandidate;
        }

        // PUT: api/DCandidate/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDCandidate(int id, DPost dCandidate)
        {
            dCandidate.id = id;

            _context.Entry(dCandidate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DCandidateExists(id))
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

        // POST: api/DCandidate
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<DPost>> PostDCandidate(DPost dCandidate)
        {
            _context.Posts.Add(dCandidate);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDCandidate", new { id = dCandidate.id }, dCandidate);
        }

        // DELETE: api/DCandidate/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DPost>> DeleteDCandidate(int id)
        {
            var dCandidate = await _context.Posts.FindAsync(id);
            if (dCandidate == null)
            {
                return NotFound();
            }

            _context.Posts.Remove(dCandidate);
            await _context.SaveChangesAsync();

            return dCandidate;
        }

        private bool DCandidateExists(int id)
        {
            return _context.Posts.Any(e => e.id == id);
        }
    }
}
