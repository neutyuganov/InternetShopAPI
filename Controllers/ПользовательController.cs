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
    public class ПользовательController : ApiController
    {
        private EntitiesInternetShop db = new EntitiesInternetShop();

        // GET: api/Пользователь
        public IQueryable<Пользователь> GetПользователь()
        {
            return db.Пользователь;
        }

        // GET: api/Пользователь/5
        [ResponseType(typeof(Пользователь))]
        public IHttpActionResult GetПользователь(long id)
        {
            Пользователь пользователь = db.Пользователь.Find(id);
            if (пользователь == null)
            {
                return NotFound();
            }

            return Ok(пользователь);
        }

        // PUT: api/Пользователь/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutПользователь(long id, Пользователь пользователь)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != пользователь.КодПользователя)
            {
                return BadRequest();
            }

            db.Entry(пользователь).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ПользовательExists(id))
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

        // POST: api/Пользователь
        [ResponseType(typeof(Пользователь))]
        public IHttpActionResult PostПользователь(Пользователь пользователь)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Пользователь.Add(пользователь);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = пользователь.КодПользователя }, пользователь);
        }

        // DELETE: api/Пользователь/5
        [ResponseType(typeof(Пользователь))]
        public IHttpActionResult DeleteПользователь(long id)
        {
            Пользователь пользователь = db.Пользователь.Find(id);
            if (пользователь == null)
            {
                return NotFound();
            }

            db.Пользователь.Remove(пользователь);
            db.SaveChanges();

            return Ok(пользователь);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ПользовательExists(long id)
        {
            return db.Пользователь.Count(e => e.КодПользователя == id) > 0;
        }
    }
}