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
using eg_api.Data;
using eg_api.Models;

namespace eg_api.Controllers
{
    public class SatellitesController : ApiController
    {
        private eg_apiContext db = new eg_apiContext();

        // GET: api/Satellites
        public IQueryable<Satellite> GetSatellites()
        {
            return db.Satellites;
        }

        // GET: api/Satellites/5
        [ResponseType(typeof(Satellite))]
        public async Task<IHttpActionResult> GetSatellite(int id)
        {
            Satellite satellite = await db.Satellites.FindAsync(id);
            if (satellite == null)
            {
                return NotFound();
            }

            return Ok(satellite);
        }

        // PUT: api/Satellites/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSatellite(int id, Satellite satellite)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != satellite.Sat_id)
            {
                return BadRequest();
            }

            db.Entry(satellite).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SatelliteExists(id))
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

        // POST: api/Satellites
        [ResponseType(typeof(Satellite))]
        public async Task<IHttpActionResult> PostSatellite(Satellite satellite)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Satellites.Add(satellite);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = satellite.Sat_id }, satellite);
        }

        // DELETE: api/Satellites/5
        [ResponseType(typeof(Satellite))]
        public async Task<IHttpActionResult> DeleteSatellite(int id)
        {
            Satellite satellite = await db.Satellites.FindAsync(id);
            if (satellite == null)
            {
                return NotFound();
            }

            db.Satellites.Remove(satellite);
            await db.SaveChangesAsync();

            return Ok(satellite);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SatelliteExists(int id)
        {
            return db.Satellites.Count(e => e.Sat_id == id) > 0;
        }
    }
}