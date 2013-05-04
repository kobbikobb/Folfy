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
    public class CoursesController : ApiController
    {
        private readonly IRepository<Course> courseRepository;

        public CoursesController(IRepository<Course> courseRepository)
        {
            if (courseRepository == null) throw new ArgumentNullException("courseRepository");
            this.courseRepository = courseRepository;
        }

        // GET api/Courses
        public List<Course> GetCourses()
        {
            return courseRepository.GetAll();
        }

        // GET api/Courses/5
        public Course GetCourse(int id)
        {
            var course = courseRepository.Get(id);
            if (course == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return course;
        }

        // PUT api/Courses/5
        public HttpResponseMessage PutCourse(int id, Course course)
        {
            if (ModelState.IsValid && id == course.Id)
            {
                try
                {
                    courseRepository.Update(course);
                }
                catch (DbUpdateConcurrencyException)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

                return Request.CreateResponse(HttpStatusCode.OK);
            }
         
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        // POST api/Courses
        public HttpResponseMessage PostCourse(Course course)
        {
            if (ModelState.IsValid)
            {
                courseRepository.Create(course);

                var response = Request.CreateResponse(HttpStatusCode.Created, course);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = course.Id }));
                return response;
            }
         
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        // DELETE api/Courses/5
        public HttpResponseMessage DeleteCourse(int id)
        {
            var course = GetCourse(id);

            try
            {
                courseRepository.Delete(course);
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, course);
        }
    }
}