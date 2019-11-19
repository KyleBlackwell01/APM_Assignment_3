using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using G1N2WebAPI.Models;

namespace G1N2WebAPI.Controllers
{
    public class ScanEventsController : ApiController
    {
        private Database_Sem2Entities db = new Database_Sem2Entities();

        // GET: api/ScanEvents
        public IQueryable<ScanEvent> GetScanEvents()
        {
            return db.ScanEvents;
        }

        // GET: api/ScanEvents/5
        [ResponseType(typeof(ScanEvent))]
        public async Task<IHttpActionResult> GetScanEvent(DateTime id)
        {
            ScanEvent scanEvent = await db.ScanEvents.FindAsync(id);
            if (scanEvent == null)
            {
                return NotFound();
            }

            return Ok(scanEvent);
        }

        // PUT: api/ScanEvents/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutScanEvent(DateTime id, ScanEvent scanEvent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != scanEvent.TIME)
            {
                return BadRequest();
            }

            db.Entry(scanEvent).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ScanEventExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/ScanEvents
        [ResponseType(typeof(ScanEvent))]
        public async Task<IHttpActionResult> PostScanEvent(ScanEvent scanEvent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ScanEvents.Add(scanEvent);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ScanEventExists(scanEvent.TIME))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = scanEvent.TIME }, scanEvent);
        }

        // DELETE: api/ScanEvents/5
        [ResponseType(typeof(ScanEvent))]
        public async Task<IHttpActionResult> DeleteScanEvent(DateTime id)
        {
            ScanEvent scanEvent = await db.ScanEvents.FindAsync(id);
            if (scanEvent == null)
            {
                return NotFound();
            }

            db.ScanEvents.Remove(scanEvent);
            await db.SaveChangesAsync();

            return Ok(scanEvent);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ScanEventExists(DateTime id)
        {
            return db.ScanEvents.Count(e => e.TIME == id) > 0;
        }
    }
}