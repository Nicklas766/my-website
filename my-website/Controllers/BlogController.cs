using System.ComponentModel.DataAnnotations;
using System.Linq;
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

        // GET api/blog/all
        [HttpGet("all")]
        public IActionResult GetAll()
        {
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
    }
}