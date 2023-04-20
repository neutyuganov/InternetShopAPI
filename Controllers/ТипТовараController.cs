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
    public class ТипТовараController : ApiController
    {
        private EntitiesInternetShop db = new EntitiesInternetShop();

        // GET: api/ТипТовара
        public IQueryable<ТипТовара> GetТипТовара()
        {
            return db.ТипТовара;
        }

        // GET: api/ТипТовара/5
        [ResponseType(typeof(ТипТовара))]
        public IHttpActionResult GetТипТовара(long id)
        {
            ТипТовара типТовара = db.ТипТовара.Find(id);
            if (типТовара == null)
            {
                return NotFound();
            }

            return Ok(типТовара);
        }

        // PUT: api/ТипТовара/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutТипТовара(long id, ТипТовара типТовара)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != типТовара.КодТипа)
            {
                return BadRequest();
            }

            db.Entry(типТовара).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ТипТовараExists(id))
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

        // POST: api/ТипТовара
        [ResponseType(typeof(ТипТовара))]
        public IHttpActionResult PostТипТовара(ТипТовара типТовара)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ТипТовара.Add(типТовара);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = типТовара.КодТипа }, типТовара);
        }

        // DELETE: api/ТипТовара/5
        [ResponseType(typeof(ТипТовара))]
        public IHttpActionResult DeleteТипТовара(long id)
        {
            ТипТовара типТовара = db.ТипТовара.Find(id);
            if (типТовара == null)
            {
                return NotFound();
            }

            db.ТипТовара.Remove(типТовара);
            db.SaveChanges();

            return Ok(типТовара);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ТипТовараExists(long id)
        {
            return db.ТипТовара.Count(e => e.КодТипа == id) > 0;
        }
    }
}