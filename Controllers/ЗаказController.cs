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
    public class ЗаказController : ApiController
    {
        private EntitiesInternetShop db = new EntitiesInternetShop();

        // GET: api/Заказ
        public IQueryable<Заказ> GetЗаказ()
        {
            return db.Заказ;
        }

        // GET: api/Заказ/5
        [ResponseType(typeof(Заказ))]
        public IHttpActionResult GetЗаказ(long id)
        {
            Заказ заказ = db.Заказ.Find(id);
            if (заказ == null)
            {
                return NotFound();
            }

            return Ok(заказ);
        }

        // PUT: api/Заказ/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutЗаказ(long id, Заказ заказ)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != заказ.КодЗаказа)
            {
                return BadRequest();
            }

            db.Entry(заказ).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ЗаказExists(id))
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

        // POST: api/Заказ
        [ResponseType(typeof(Заказ))]
        public IHttpActionResult PostЗаказ(Заказ заказ)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Заказ.Add(заказ);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = заказ.КодЗаказа }, заказ);
        }

        // DELETE: api/Заказ/5
        [ResponseType(typeof(Заказ))]
        public IHttpActionResult DeleteЗаказ(long id)
        {
            Заказ заказ = db.Заказ.Find(id);
            if (заказ == null)
            {
                return NotFound();
            }

            db.Заказ.Remove(заказ);
            db.SaveChanges();

            return Ok(заказ);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ЗаказExists(long id)
        {
            return db.Заказ.Count(e => e.КодЗаказа == id) > 0;
        }
    }
}