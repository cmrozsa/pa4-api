using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using api.database;
using api.model;
using api.interfaces;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        // GET: api/Posts
        [EnableCors("OpenPolicy")]
        [HttpGet]
        public List<Post> Get()
        {
            IPostDataHandler dataHandler = new PostDataHandler();
            return dataHandler.Select();
        }

        // GET: api/Posts/5
        [EnableCors("OpenPolicy")]
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Posts
        [EnableCors("OpenPolicy")]
        [HttpPost]
        public void Post([FromBody] Post value)
        {
            Console.WriteLine("made it to the post" + value.PostText);
            value.dataHandler.Insert(value);
        }

        // PUT: api/Posts/5
        [EnableCors("OpenPolicy")]
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Post value)
        {
            value.PostID = id;
            value.Date = DateTime.Now.ToString();
            Console.WriteLine("made it to the put" + value.PostText);
            value.dataHandler.Update(value);
        }

        // DELETE: api/Posts/5
        [EnableCors("OpenPolicy")]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Post value = new Post() { PostID = id };

            value.dataHandler.Delete(value);
        }
    }
}
