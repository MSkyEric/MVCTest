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
using MVCTest;
using Newtonsoft.Json;

namespace MVCTest.Controllers
{
    public class APIController : ApiController
    {
        private AGISEntities db = new AGISEntities();

        // GET: api/API
        [Route("api/api")]
        public object GetAGENCies()
        {
            return Json<object>(db.AGENCies.ToList());
            //return db.AGENCies;
        }

        // GET: api/API/5
        [ResponseType(typeof(AGENCY))]
        public async Task<IHttpActionResult> GetAGENCY(int id)
        {
            AGENCY aGENCY = await db.AGENCies.FindAsync(id);
            if (aGENCY == null)
            {
                return NotFound();
            }

            return Ok(aGENCY);
        }

        // PUT: api/API/5
        [Route("api/api")]
        //[HttpPut]
        //[HttpPatch]
        public async Task<IHttpActionResult> PutAGENCY(int id, AGENCY aGENCY)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != aGENCY.AGENCYID)
            {
                return BadRequest();
            }

            db.Entry(aGENCY).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AGENCYExists(id))
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

        // POST: api/API
        [Route("api/api")]
        [HttpPost]
        public async Task<string> PostAGENCY([FromBody]AGENCY aGENCY)
        {
            //AGENCY aGENCY = JsonConvert.DeserializeObject<AGENCY>(s);
            if (!ModelState.IsValid)
            {
                return "fail";//BadRequest(ModelState);
            }
            aGENCY.CREATEDTIME = DateTime.Now;
            db.AGENCies.Add(aGENCY);
            await db.SaveChangesAsync();

            //return CreatedAtRoute("DefaultApi", new { id = aGENCY.AGENCYID }, aGENCY);
            return "OK";
        }

        // DELETE: api/API/5
        [Route("api/api")]
        [ResponseType(typeof(AGENCY))]
        public async Task<IHttpActionResult> DeleteAGENCY(int id)
        {
            AGENCY aGENCY = await db.AGENCies.FindAsync(id);
            if (aGENCY == null)
            {
                return NotFound();
            }

            db.AGENCies.Remove(aGENCY);
            await db.SaveChangesAsync();

            return Ok(aGENCY);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AGENCYExists(int id)
        {
            return db.AGENCies.Count(e => e.AGENCYID == id) > 0;
        }
    }
}