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
    public class ScorecardsController : ApiController
    {
        private readonly IRepository<Scorecard> scorecardRepository;

        public ScorecardsController(IRepository<Scorecard> scorecardRepository)
        {
            if (scorecardRepository == null) throw new ArgumentNullException("scorecardRepository");
            this.scorecardRepository = scorecardRepository;
        }

        // GET api/Scorecards
        public List<Scorecard> GetScorecards()
        {
            return scorecardRepository.GetAll();
        }

        // GET api/Scorecards/5
        public Scorecard GetScorecard(int id)
        {
            var scorecard = scorecardRepository.Get(id);
            if (scorecard == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return scorecard;
        }

        // GET api/Scorecards/5/Holes
        public List<Hole> GetHoles(int scorecardId)
        {
            var scorecard = GetScorecard(scorecardId);

            return scorecard.Holes;
        }

        // GET api/Scorecards/5/Holes/1
        public Hole GetHole(int scorecardId, int holeId)
        {
            var scorecard = GetScorecard(scorecardId);

            return scorecard.Holes.SingleOrDefault(x => x.Id == holeId);
        }

        // PUT api/Scorecards/5
        public HttpResponseMessage PutScorecard(int id, Scorecard scorecard)
        {
            if (ModelState.IsValid && id == scorecard.Id)
            {
                try
                {
                    scorecardRepository.Update(scorecard);
                }
                catch (DbUpdateConcurrencyException)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

                return Request.CreateResponse(HttpStatusCode.OK);
            }
         
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        // POST api/Scorecards
        public HttpResponseMessage PostScorecard(Scorecard scorecard)
        {
            if (ModelState.IsValid)
            {
                scorecardRepository.Create(scorecard);

                var response = Request.CreateResponse(HttpStatusCode.Created, scorecard);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = scorecard.Id }));
                return response;
            }
         
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        // DELETE api/Scorecards/5
        public HttpResponseMessage DeleteScorecard(int id)
        {
            var scorecard = GetScorecard(id);

            try
            {
                scorecardRepository.Delete(scorecard);
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, scorecard);
        }
    }
}