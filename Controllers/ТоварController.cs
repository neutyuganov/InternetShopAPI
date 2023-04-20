using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using InternetShopAPI;

namespace InternetShopAPI.Controllers
{
    public class ТоварController : ApiController
    {
        private EntitiesInternetShop db = new EntitiesInternetShop();

        // GET: api/Товар
        public IQueryable<Товар> GetТовар()
        {
            return db.Товар;
        }

        // GET: api/Товар/5
        [ResponseType(typeof(Товар))]
        public IHttpActionResult GetТовар(long id)
        {
            Товар товар = db.Товар.Find(id);
            if (товар == null)
            {
                return NotFound();
            }

            return Ok(товар);
        }

        // PUT: api/Товар/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutТовар(long id, Товар товар)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != товар.КодТовара)
            {
                return BadRequest();
            }

            db.Entry(товар).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ТоварExists(id))
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

        // POST: api/Товар
        [ResponseType(typeof(Товар))]
        public IHttpActionResult PostТовар(Товар товар)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Товар.Add(товар);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = товар.КодТовара }, товар);
        }

        // DELETE: api/Товар/5
        [ResponseType(typeof(Товар))]
        public IHttpActionResult DeleteТовар(long id)
        {
            Товар товар = db.Товар.Find(id);
            if (товар == null)
            {
                return NotFound();
            }

            db.Товар.Remove(товар);
            db.SaveChanges();

            return Ok(товар);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ТоварExists(long id)
        {
            return db.Товар.Count(e => e.КодТовара == id) > 0;
        }
    }
}