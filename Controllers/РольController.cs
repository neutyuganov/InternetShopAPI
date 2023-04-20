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
    public class РольController : ApiController
    {
        private EntitiesInternetShop db = new EntitiesInternetShop();

        // GET: api/Роль
        public IQueryable<Роль> GetРоль()
        {
            return db.Роль;
        }

        // GET: api/Роль/5
        [ResponseType(typeof(Роль))]
        public IHttpActionResult GetРоль(long id)
        {
            Роль роль = db.Роль.Find(id);
            if (роль == null)
            {
                return NotFound();
            }

            return Ok(роль);
        }

        // PUT: api/Роль/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutРоль(long id, Роль роль)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != роль.КодРоли)
            {
                return BadRequest();
            }

            db.Entry(роль).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!РольExists(id))
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

        // POST: api/Роль
        [ResponseType(typeof(Роль))]
        public IHttpActionResult PostРоль(Роль роль)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Роль.Add(роль);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = роль.КодРоли }, роль);
        }

        // DELETE: api/Роль/5
        [ResponseType(typeof(Роль))]
        public IHttpActionResult DeleteРоль(long id)
        {
            Роль роль = db.Роль.Find(id);
            if (роль == null)
            {
                return NotFound();
            }

            db.Роль.Remove(роль);
            db.SaveChanges();

            return Ok(роль);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool РольExists(long id)
        {
            return db.Роль.Count(e => e.КодРоли == id) > 0;
        }
    }
}