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
    public class UsersController : ApiController
    {
        private readonly IRepository<User> userRepository;
        
        public UsersController(IRepository<User> userRepository)
        {
            if (userRepository == null) throw new ArgumentNullException("userRepository");
            this.userRepository = userRepository;
        }

        // GET api/Users
        public List<User> GetUsers()
        {
            return userRepository.GetAll();
        }

        // GET api/Users/5
        public User GetUser(int id)
        {
            var user = userRepository.Get(id);
            if (user == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return user;
        }

        // PUT api/Users/5
        public HttpResponseMessage PutUser(int id, User user)
        {
            if (ModelState.IsValid && id == user.Id)
            {
                try
                {
                    userRepository.Update(user);
                }
                catch (DbUpdateConcurrencyException)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

                return Request.CreateResponse(HttpStatusCode.OK);
            }
         
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        // POST api/Users
        public HttpResponseMessage PostUser(User user)
        {
            if (ModelState.IsValid)
            {
                userRepository.Create(user);

                var response = Request.CreateResponse(HttpStatusCode.Created, user);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = user.Id }));
                return response;
            }
         
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        // DELETE api/Users/5
        public HttpResponseMessage DeleteUser(int id)
        {
            var user = GetUser(id);

            try
            {
                userRepository.Delete(user);
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, user);
        }
    }
}