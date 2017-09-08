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
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Routing;
using MVCTest;

namespace MVCTest.Controllers
{
    /*
    The WebApiConfig class may require additional changes to add a route for this controller. Merge these statements into the Register method of the WebApiConfig class as applicable. Note that OData URLs are case sensitive.

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using MVCTest;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<CONFIGURATION>("CONFIGURATION");
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class CONFIGURATIONController : ODataController
    {
        private AGISEntities db = new AGISEntities();

        // GET: odata/CONFIGURATION
        [EnableQuery]
        public IQueryable<CONFIGURATION> GetCONFIGURATION()
        {
            return db.CONFIGURATIONs;
        }

        // GET: odata/CONFIGURATION(5)
        [EnableQuery]
        public SingleResult<CONFIGURATION> GetCONFIGURATION([FromODataUri] int key)
        {
            return SingleResult.Create(db.CONFIGURATIONs.Where(cONFIGURATION => cONFIGURATION.ID == key));
        }

        // PUT: odata/CONFIGURATION(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Delta<CONFIGURATION> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            CONFIGURATION cONFIGURATION = await db.CONFIGURATIONs.FindAsync(key);
            if (cONFIGURATION == null)
            {
                return NotFound();
            }

            patch.Put(cONFIGURATION);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CONFIGURATIONExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(cONFIGURATION);
        }

        // POST: odata/CONFIGURATION
        public async Task<IHttpActionResult> Post(CONFIGURATION cONFIGURATION)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CONFIGURATIONs.Add(cONFIGURATION);
            await db.SaveChangesAsync();

            return Created(cONFIGURATION);
        }

        // PATCH: odata/CONFIGURATION(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<CONFIGURATION> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            CONFIGURATION cONFIGURATION = await db.CONFIGURATIONs.FindAsync(key);
            if (cONFIGURATION == null)
            {
                return NotFound();
            }

            patch.Patch(cONFIGURATION);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CONFIGURATIONExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(cONFIGURATION);
        }

        // DELETE: odata/CONFIGURATION(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            CONFIGURATION cONFIGURATION = await db.CONFIGURATIONs.FindAsync(key);
            if (cONFIGURATION == null)
            {
                return NotFound();
            }

            db.CONFIGURATIONs.Remove(cONFIGURATION);
            await db.SaveChangesAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CONFIGURATIONExists(int key)
        {
            return db.CONFIGURATIONs.Count(e => e.ID == key) > 0;
        }
    }
}
