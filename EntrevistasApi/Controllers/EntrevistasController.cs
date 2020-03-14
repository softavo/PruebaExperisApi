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
using EntrevistasApi.Models;

namespace EntrevistasApi.Controllers
{
    public class EntrevistasController : ApiController
    {
        private BD_EntrevistasEntities db = new BD_EntrevistasEntities();

        // GET: api/Entrevistas
        public IQueryable<Entrevistas> GetEntrevistas()
        {
            return db.Entrevistas;
        }

        // GET: api/Entrevistas/5
        [ResponseType(typeof(Entrevistas))]
        public async Task<IHttpActionResult> GetEntrevistas(int id)
        {
            Entrevistas entrevistas = await db.Entrevistas.FindAsync(id);
            if (entrevistas == null)
            {
                return NotFound();
            }

            return Ok(entrevistas);
        }

        // PUT: api/Entrevistas/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutEntrevistas(int id, Entrevistas entrevistas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != entrevistas.Id)
            {
                return BadRequest();
            }

            db.Entry(entrevistas).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EntrevistasExists(id))
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

        // POST: api/Entrevistas
        [ResponseType(typeof(Entrevistas))]
        public async Task<IHttpActionResult> PostEntrevistas(Entrevistas entrevistas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Entrevistas.Add(entrevistas);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = entrevistas.Id }, entrevistas);
        }

        // DELETE: api/Entrevistas/5
        [ResponseType(typeof(Entrevistas))]
        public async Task<IHttpActionResult> DeleteEntrevistas(int id)
        {
            Entrevistas entrevistas = await db.Entrevistas.FindAsync(id);
            if (entrevistas == null)
            {
                return NotFound();
            }

            db.Entrevistas.Remove(entrevistas);
            await db.SaveChangesAsync();

            return Ok(entrevistas);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EntrevistasExists(int id)
        {
            return db.Entrevistas.Count(e => e.Id == id) > 0;
        }
    }
}