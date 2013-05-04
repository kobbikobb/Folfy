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
    public class CourseHolesController : ApiController
    {
        private readonly IRepository<CourseHole> holeRepository;

        public CourseHolesController(IRepository<CourseHole> holeRepository)
        {
            if (holeRepository == null) throw new ArgumentNullException("holeRepository");
            this.holeRepository = holeRepository;
        }

        // GET api/CourseHoles
        public List<CourseHole> GetCourseHoles()
        {
            return holeRepository.GetAll();
        }

        // GET api/CourseHoles/5
        public CourseHole GetCourseHole(int id)
        {
            var coursehole = holeRepository.Get(id);
            if (coursehole == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return coursehole;
        }

        // PUT api/CourseHoles/5
        public HttpResponseMessage PutCourseHole(int id, CourseHole courseHole)
        {
            if (ModelState.IsValid && id == courseHole.Id)
            {
                try
                {
                    holeRepository.Update(courseHole);
                }
                catch (DbUpdateConcurrencyException)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

                return Request.CreateResponse(HttpStatusCode.OK);
            }
         
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        // POST api/CourseHoles
        public HttpResponseMessage PostCourseHole(CourseHole courseHole)
        {
            if (ModelState.IsValid)
            {
                holeRepository.Create(courseHole);

                var response = Request.CreateResponse(HttpStatusCode.Created, courseHole);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = courseHole.Id }));
                return response;
            }
                
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        // DELETE api/CourseHoles/5
        public HttpResponseMessage DeleteCourseHole(int id)
        {
            var coursehole = GetCourseHole(id);

            try
            {
                holeRepository.Delete(coursehole);
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, coursehole);
        }
    }
}