using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Folfy.WebApi.Data;
using Folfy.WebApi.Models;
using Folfy.WebApi.Models.Data;

namespace Folfy.WebApi.Controllers
{
    public class HolesController : ApiController
    {
        private readonly IRepository<Hole> holeRepository;

        public HolesController(IRepository<Hole> holeRepository)
        {
            if (holeRepository == null) throw new ArgumentNullException("holeRepository");
            this.holeRepository = holeRepository;
        }

        // GET api/Holes
        public List<Hole> GetHoles()
        {
            return holeRepository.GetAll();
        }

        // GET api/Holes/5
        public Hole GetHole(int id)
        {
            var hole = holeRepository.Get(id);
            if (hole == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return hole;
        }

        // PUT api/Holes/5
        public HttpResponseMessage PutHole(int id, Hole hole)
        {
            if (ModelState.IsValid && id == hole.Id)
            {
                try
                {
                    holeRepository.Update(hole);
                }
                catch (DbUpdateConcurrencyException)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

                return Request.CreateResponse(HttpStatusCode.OK);
            }
                
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        // POST api/Holes
        public HttpResponseMessage PostHole(Hole hole)
        {
            if (ModelState.IsValid)
            {
                holeRepository.Create(hole);

                var response = Request.CreateResponse(HttpStatusCode.Created, hole);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = hole.Id }));
                return response;
            }
             
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        // DELETE api/Holes/5
        public HttpResponseMessage DeleteHole(int id)
        {
            var hole = GetHole(id);

            try
            {
                holeRepository.Delete(hole);
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, hole);
        }
    }
}