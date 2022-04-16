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
    public class OrderitemController : ApiController
    {
        private RestraurantDbEntities1 db = new RestraurantDbEntities1();

        // GET: api/Orderitem
        public IQueryable<Orderitem> GetOrderitems()
        {
            return db.Orderitems;
        }

        // GET: api/Orderitem/5
        [ResponseType(typeof(Orderitem))]
        public IHttpActionResult GetOrderitem(long id)
        {
            Orderitem orderitem = db.Orderitems.Find(id);
            if (orderitem == null)
            {
                return NotFound();
            }

            return Ok(orderitem);
        }

        // PUT: api/Orderitem/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutOrderitem(long id, Orderitem orderitem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != orderitem.OrderitemID)
            {
                return BadRequest();
            }

            db.Entry(orderitem).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderitemExists(id))
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

        // POST: api/Orderitem
        [ResponseType(typeof(Orderitem))]
        public IHttpActionResult PostOrderitem(Orderitem orderitem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Orderitems.Add(orderitem);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = orderitem.OrderitemID }, orderitem);
        }

        // DELETE: api/Orderitem/5
        [ResponseType(typeof(Orderitem))]
        public IHttpActionResult DeleteOrderitem(long id)
        {
            Orderitem orderitem = db.Orderitems.Find(id);
            if (orderitem == null)
            {
                return NotFound();
            }

            db.Orderitems.Remove(orderitem);
            db.SaveChanges();

            return Ok(orderitem);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OrderitemExists(long id)
        {
            return db.Orderitems.Count(e => e.OrderitemID == id) > 0;
        }
    }
}