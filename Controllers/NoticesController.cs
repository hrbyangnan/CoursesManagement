using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Pegasus_backend.pegasusContext;

namespace Pegasus_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoticesController : BasicController
    {
        
        public NoticesController(ablemusicContext ablemusicContext, ILogger<StaffController> log) : base(ablemusicContext, log)
        {
            
        }

        // GET: api/Notices
        [HttpGet]
        public IEnumerable<Notices> GetNotices()
        {
            return _ablemusicContext.Notices;
        }

        // GET: api/Notices/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetNotices([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var notices = await _ablemusicContext.Notices.FindAsync(id);

            if (notices == null)
            {
                return NotFound();
            }

            return Ok(notices);
        }

        // PUT: api/Notices/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNotices([FromRoute] int id, [FromBody] Notices notices)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != notices.NoticeId)
            {
                return BadRequest();
            }

            _ablemusicContext.Entry(notices).State = EntityState.Modified;

            try
            {
                await _ablemusicContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NoticesExists(id))
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

        // POST: api/Notices
        [HttpPost]
        public async Task<IActionResult> PostNotices([FromBody] Notices notices)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _ablemusicContext.Notices.Add(notices);
            try
            {
                await _ablemusicContext.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (NoticesExists(notices.NoticeId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetNotices", new { id = notices.NoticeId }, notices);
        }

        // DELETE: api/Notices/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNotices([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var notices = await _ablemusicContext.Notices.FindAsync(id);
            if (notices == null)
            {
                return NotFound();
            }

            _ablemusicContext.Notices.Remove(notices);
            await _ablemusicContext.SaveChangesAsync();

            return Ok(notices);
        }

        private bool NoticesExists(int id)
        {
            return _ablemusicContext.Notices.Any(e => e.NoticeId == id);
        }
    }
}