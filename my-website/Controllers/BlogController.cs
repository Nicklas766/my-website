using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using my_website.Data;
using my_website.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace mywebsite.Controllers
{
    [Route("api/[controller]")]
    public class BlogController : Controller
    {
        private readonly BlogContext _context;

        public BlogController(BlogContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_context.Posts.ToList());
        }


        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult GetBySlug(string slug)
        {
            Post post = _context.Posts.FirstOrDefault(curPost => curPost.Slug == slug);

            if (post == null)
                return StatusCode(404);

            return Ok(post);
        }

        public class CreateAndUpdateBody
        {
            public int? id;
            public string title;
            public string slug;
            public string text;
        }

        // POST api/values
        [HttpPost]
        public IActionResult Create([FromBody]CreateAndUpdateBody body)
        {
            Post post  = new Post();

            post.Title = body.title;
            post.Slug  = Post.Slugify(body.slug);
            post.Text  = body.text;

            _context.Add(post);
            _context.SaveChanges();
            return GetAll();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Update([FromBody]CreateAndUpdateBody body)
        {
            Post post = _context.Posts.FirstOrDefault(curPost => curPost.ID == body.id);

            if (post == null)
                return StatusCode(404);

            post.Title = body.title;
            post.Slug = Post.Slugify(body.slug);
            post.Text = body.text;

            _context.SaveChanges();

            return Ok(post);
        }

        // DELETE api/values/5
        [HttpPut("{id}")]
        public StatusCodeResult Delete(int id)
        {
            Post post = _context.Posts.FirstOrDefault(curPost => curPost.ID == id);

            if (post == null)
              return StatusCode(404);

            post.IsDeleted = true;
            _context.SaveChanges();

            return StatusCode(200);
        }
    }
}
