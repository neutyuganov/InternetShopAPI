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
    public class СоставЗаказаController : ApiController
    {
        private EntitiesInternetShop db = new EntitiesInternetShop();

        // GET: api/СоставЗаказа
        public IQueryable<СоставЗаказа> GetСоставЗаказа()
        {
            return db.СоставЗаказа;
        }

        // GET: api/СоставЗаказа/5
        [ResponseType(typeof(СоставЗаказа))]
        public IHttpActionResult GetСоставЗаказа(long id)
        {
            СоставЗаказа составЗаказа = db.СоставЗаказа.Find(id);
            if (составЗаказа == null)
            {
                return NotFound();
            }

            return Ok(составЗаказа);
        }

        // PUT: api/СоставЗаказа/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutСоставЗаказа(long id, СоставЗаказа составЗаказа)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != составЗаказа.КодСоставаЗаказа)
            {
                return BadRequest();
            }

            db.Entry(составЗаказа).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!СоставЗаказаExists(id))
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

        // POST: api/СоставЗаказа
        [ResponseType(typeof(СоставЗаказа))]
        public IHttpActionResult PostСоставЗаказа(СоставЗаказа составЗаказа)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.СоставЗаказа.Add(составЗаказа);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = составЗаказа.КодСоставаЗаказа }, составЗаказа);
        }

        // DELETE: api/СоставЗаказа/5
        [ResponseType(typeof(СоставЗаказа))]
        public IHttpActionResult DeleteСоставЗаказа(long id)
        {
            СоставЗаказа составЗаказа = db.СоставЗаказа.Find(id);
            if (составЗаказа == null)
            {
                return NotFound();
            }

            db.СоставЗаказа.Remove(составЗаказа);
            db.SaveChanges();

            return Ok(составЗаказа);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool СоставЗаказаExists(long id)
        {
            return db.СоставЗаказа.Count(e => e.КодСоставаЗаказа == id) > 0;
        }
    }
}