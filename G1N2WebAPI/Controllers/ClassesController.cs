﻿using System;
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
    public class ClassesController : ApiController
    {
        private G1N2Entities db = new G1N2Entities();

        // GET: api/Classes
        public IQueryable<Class> GetClasses()
        {
            return db.Classes;
        }

        // GET: api/Classes/5
        [ResponseType(typeof(Class))]
        public async Task<IHttpActionResult> GetClass(int id)
        {
            Class @class = await db.Classes.FindAsync(id);
            if (@class == null)
            {
                return NotFound();
            }

            return Ok(@class);
        }

        // PUT: api/Classes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutClass(int id, Class @class)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != @class.ClassID)
            {
                return BadRequest();
            }

            db.Entry(@class).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClassExists(id))
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

        // POST: api/Classes
        [ResponseType(typeof(Class))]
        public async Task<IHttpActionResult> PostClass(Class @class)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Classes.Add(@class);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ClassExists(@class.ClassID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = @class.ClassID }, @class);
        }

        // DELETE: api/Classes/5
        [ResponseType(typeof(Class))]
        public async Task<IHttpActionResult> DeleteClass(int id)
        {
            Class @class = await db.Classes.FindAsync(id);
            if (@class == null)
            {
                return NotFound();
            }

            db.Classes.Remove(@class);
            await db.SaveChangesAsync();

            return Ok(@class);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ClassExists(int id)
        {
            return db.Classes.Count(e => e.ClassID == id) > 0;
        }
    }
}