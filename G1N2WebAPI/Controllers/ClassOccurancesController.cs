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
    public class ClassOccurancesController : ApiController
    {
        private Database_Sem2Entities db = new Database_Sem2Entities();

        // GET: api/ClassOccurances
        public IQueryable<ClassOccurance> GetClassOccurances()
        {
            return db.ClassOccurances;
        }

        // GET: api/ClassOccurances/5
        [ResponseType(typeof(ClassOccurance))]
        public async Task<IHttpActionResult> GetClassOccurance(int id)
        {
            ClassOccurance classOccurance = await db.ClassOccurances.FindAsync(id);
            if (classOccurance == null)
            {
                return NotFound();
            }

            return Ok(classOccurance);
        }

        // PUT: api/ClassOccurances/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutClassOccurance(int id, ClassOccurance classOccurance)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != classOccurance.Barcode)
            {
                return BadRequest();
            }

            db.Entry(classOccurance).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClassOccuranceExists(id))
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

        // POST: api/ClassOccurances
        [ResponseType(typeof(ClassOccurance))]
        public async Task<IHttpActionResult> PostClassOccurance(ClassOccurance classOccurance)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ClassOccurances.Add(classOccurance);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ClassOccuranceExists(classOccurance.Barcode))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = classOccurance.Barcode }, classOccurance);
        }

        // DELETE: api/ClassOccurances/5
        [ResponseType(typeof(ClassOccurance))]
        public async Task<IHttpActionResult> DeleteClassOccurance(int id)
        {
            ClassOccurance classOccurance = await db.ClassOccurances.FindAsync(id);
            if (classOccurance == null)
            {
                return NotFound();
            }

            db.ClassOccurances.Remove(classOccurance);
            await db.SaveChangesAsync();

            return Ok(classOccurance);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ClassOccuranceExists(int id)
        {
            return db.ClassOccurances.Count(e => e.Barcode == id) > 0;
        }
    }
}