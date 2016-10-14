using Newsfeed.API.Models;
using Newsfeed.API.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.OData;
using Newsfeed.API.Repository.Contracts;
using System.Web.Http.Description;

namespace Newsfeed.API.Controllers
{
    [EnableCorsAttribute("http://localhost:14838", "*", "*")]
    public class NewsController : ApiController
    {
        private INewsRepository _repository;

        public NewsController(INewsRepository repository)  
        {
            _repository = repository;
        }
        
        // GET: api/News
        [EnableQuery()]
        public IHttpActionResult Get()
        {
          return Ok(_repository.Retrieve().AsEnumerable());
        }

      [ResponseType(typeof(News))]
      public IHttpActionResult Get(int id)
        {
            try
            {
                News news;
                news = _repository.Create();
                return Ok(news);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        
        // POST: api/News
        public IHttpActionResult Post([FromBody]News news)
        {
            if (news == null)
            {
                return BadRequest("news entry is empty");
            }
            var newItem = _repository.Save(news);
            if (newItem == null)
            {
                return Conflict();
            }
            return Created<News>("", newItem);
        }

      
    }
}
