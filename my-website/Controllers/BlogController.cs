using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
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

        // GET api/blog/all
        [HttpGet("all")]
        public IActionResult GetAll()
        {
            if (_context.Posts.ToList().Count == 0)
            {
                Post post = new Post();
                post.Title = "title";
                post.Slug = "slug";
                post.Text = "text here";

                _context.Add(post);
                _context.SaveChanges();
            }
                
            return Ok(_context.Posts.ToList());
        }


        // GET api/blog/article/:slug
        [HttpGet("article/{slug}")]
        public IActionResult GetBySlug(string slug)
        {
            Post post = _context.Posts.FirstOrDefault(curPost => curPost.Slug == slug);

            if (post == null)
            {
                return StatusCode(404);
            }
                
            return Ok(post);
        }


        // POST api/blog/create
        [HttpPost("create")]
        public IActionResult Create([FromBody]CreateAndUpdateBody body)
        {
            if (body.Slug == null || !ModelState.IsValid)
            {
                return StatusCode(404);
            }

            Post post  = new Post();

            post.SetAttributes(body);
 
            _context.Add(post);
            _context.SaveChanges();
            return GetAll();
        }

        // PUT api/blog/update
        [HttpPut("update")]
        public IActionResult Update([FromBody]CreateAndUpdateBody body)
        {
            Post post = _context.Posts.FirstOrDefault(curPost => curPost.ID == body.Id);

            if (post == null || !ModelState.IsValid)
            {
                return StatusCode(404);
            }

            post.SetAttributes(body);

            _context.SaveChanges();

            return Ok(post);
        }

        // DELETE api/blog/delete
        [HttpPut("delete")]
        public StatusCodeResult Delete(int id)
        {
            Post post = _context.Posts.FirstOrDefault(curPost => curPost.ID == id);

            if (post == null)
            {
                return StatusCode(404);
            }
              
            post.IsDeleted = true;
            _context.SaveChanges();

            return StatusCode(200);
        }
    }

    public class CreateAndUpdateBody
    {
        public int? Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Slug { get; set; }

        [Required]
        public string Text { get; set; }
    }
}
