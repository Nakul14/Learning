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
using WebAPIForAngularApp.Models;

namespace WebAPIForAngularApp.Controllers
{
    [Authorize]
    public class UmUserMastersController : ApiController
    {
        private TUKBGFEntities db = new TUKBGFEntities();

        // GET: api/UmUserMasters
        public IQueryable<UmUserMaster> GetUmUserMasters()
        {
            return db.UmUserMasters;
        }

        // GET: api/UmUserMasters/5
        [ResponseType(typeof(UmUserMaster))]
        public IHttpActionResult GetUmUserMaster(int id)
        {
            UmUserMaster umUserMaster = db.UmUserMasters.Find(id);
            if (umUserMaster == null)
            {
                return NotFound();
            }

            return Ok(umUserMaster);
        }

        // PUT: api/UmUserMasters/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUmUserMaster(int id, UmUserMaster umUserMaster)
        {            

            if (id != umUserMaster.ID)
            {
                return BadRequest();
            }

            db.Entry(umUserMaster).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UmUserMasterExists(id))
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

        // POST: api/UmUserMasters
        [ResponseType(typeof(UmUserMaster))]
        public IHttpActionResult PostUmUserMaster(UmUserMaster umUserMaster)
        {           

            db.UmUserMasters.Add(umUserMaster);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = umUserMaster.ID }, umUserMaster);
        }

        // DELETE: api/UmUserMasters/5
        [ResponseType(typeof(UmUserMaster))]
        public IHttpActionResult DeleteUmUserMaster(int id)
        {
            UmUserMaster umUserMaster = db.UmUserMasters.Find(id);
            if (umUserMaster == null)
            {
                return NotFound();
            }

            db.UmUserMasters.Remove(umUserMaster);
            db.SaveChanges();

            return Ok(umUserMaster);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UmUserMasterExists(int id)
        {
            return db.UmUserMasters.Count(e => e.ID == id) > 0;
        }
    }
}