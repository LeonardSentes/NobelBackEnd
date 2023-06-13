using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.UI.WebControls;
using NobelBackEnd.Models;
using NobelBackEnd.Models.Dtos;
using NobelBackEnd.MyDatabase;
using NobelBackEnd.Persistence;

namespace NobelBackEnd.Controllers
{
    public class LaureatesController : ApiController
    {
        private UnitOfWork unit;
        public LaureatesController()
        {
            unit = new UnitOfWork(new ApplicationDbContext());
        }


        // GET: api/Laureates
        public IEnumerable<object> GetLaureates()
        {
            var laureatesDto = unit.Laureates.GetAll().Select(laureate => new LaureateDto(laureate));
            return laureatesDto;
        }

        // GET: api/Laureates/5
        [ResponseType(typeof(Laureate))]
        public IHttpActionResult GetLaureate(int id)
        {
            Laureate laureate = unit.Laureates.GetById(id);
            if (laureate == null)
            {
                return NotFound();
            }
            var laureateDto = new LaureateDto(laureate);

            return Ok(laureateDto);
        }

        // PUT: api/Laureates/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLaureate(int id, Laureate laureate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != laureate.Id)
            {
                return BadRequest();
            }

            unit.Laureates.Update(laureate);

            try
            {
                unit.Laureates.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LaureateExists(id))
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

        // POST: api/Laureates
        [ResponseType(typeof(Laureate))]
        public IHttpActionResult PostLaureate(Laureate laureate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            unit.Laureates.Insert(laureate);
            unit.Laureates.Save();

            return CreatedAtRoute("DefaultApi", new { id = laureate.Id }, laureate);
        }

        // DELETE: api/Laureates/5
        [ResponseType(typeof(Laureate))]
        public IHttpActionResult DeleteLaureate(int id)
        {
            Laureate laureate = unit.Laureates.GetById(id);
            if (laureate == null)
            {
                return NotFound();
            }

            unit.Laureates.Delete(id);
            unit.Laureates.Save();

            return Ok(laureate);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                unit.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LaureateExists(int id)
        {
            return unit.Laureates.GetAll().Count(e => e.Id == id) > 0;
        }
    }
}