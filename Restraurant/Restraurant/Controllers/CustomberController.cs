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
using Restraurant.Models;

namespace Restraurant.Controllers
{
    public class CustomberController : ApiController
    {
        private RestraurantDbEntities1 db = new RestraurantDbEntities1();

        // GET: api/Customber
        public IQueryable<Customber> GetCustombers()
        {
            return db.Custombers;
        }

        // GET: api/Customber/5
        [ResponseType(typeof(Customber))]
        public IHttpActionResult GetCustomber(int id)
        {
            Customber customber = db.Custombers.Find(id);
            if (customber == null)
            {
                return NotFound();
            }

            return Ok(customber);
        }

        // PUT: api/Customber/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCustomber(int id, Customber customber)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != customber.CustomberId)
            {
                return BadRequest();
            }

            db.Entry(customber).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomberExists(id))
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

        // POST: api/Customber
        [ResponseType(typeof(Customber))]
        public IHttpActionResult PostCustomber(Customber customber)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Custombers.Add(customber);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = customber.CustomberId }, customber);
        }

        // DELETE: api/Customber/5
        [ResponseType(typeof(Customber))]
        public IHttpActionResult DeleteCustomber(int id)
        {
            Customber customber = db.Custombers.Find(id);
            if (customber == null)
            {
                return NotFound();
            }

            db.Custombers.Remove(customber);
            db.SaveChanges();

            return Ok(customber);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CustomberExists(int id)
        {
            return db.Custombers.Count(e => e.CustomberId == id) > 0;
        }
    }
}