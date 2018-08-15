using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using my_website.Data;
using my_website.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace mywebsite.Controllers
{

    [Route("api/[controller]")]
    public class AdminController : Controller
    {

 
        private readonly BlogContext _context;

        public AdminController(BlogContext context)
        {
            _context = context;
        }

        // GET api/admin/secret
        [HttpGet("secret")]
        public StatusCodeResult secret()
        {
            Admin admin = new Admin();
            admin.Username = "nicklas";
            admin.Password = "password";

            _context.Add(admin);
            _context.SaveChanges();
            return StatusCode(200);
        }

        // GET api/admin/session
        [HttpGet("isLoggedAsAdmin")]
        public StatusCodeResult isLogged()
        {
            var session = HttpContext.Session;
            bool isLoggedAsAdmin = !string.IsNullOrEmpty(session.GetString("isAdmin"));

            if (isLoggedAsAdmin)
            {
                return StatusCode(200);
            };

            return StatusCode(404);
        }

        // POST api/admin/login
        [HttpPost("login")]
        public StatusCodeResult postLogin([FromBody]LoginBody body)
        {
            Admin admin = _context.Admins.FirstOrDefault(curAdmin => curAdmin.Username == body.Username);

            if (admin != null && admin.Password == body.Password)
            {
                HttpContext.Session.SetString("isAdmin", "yes");
                return StatusCode(200);
            }

            return StatusCode(404);
        }

        // GET api/admin/logout
        [Filters.AuthorizeAdmin]
        [HttpGet("logout")]
        public StatusCodeResult getLogout()
        {
            HttpContext.Session.SetString("isAdmin", "");
            return StatusCode(200);
        }



        // POST api/admin/create
        [Filters.AuthorizeAdmin]
        [HttpPost("create")]
        public IActionResult Create([FromBody]CreateAndUpdateBody body)
        {
            if (body.Slug == null || !ModelState.IsValid)
            {
                return StatusCode(404);
            }

            Post post = new Post();

            post.SetAttributes(body);

            _context.Add(post);
            _context.SaveChanges();
            return Ok(post);
        }

        // PUT api/admin/update
        [Filters.AuthorizeAdmin]
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

        // DELETE api/admin/delete
        [Filters.AuthorizeAdmin]
        [HttpDelete("delete")]
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

   public string ImageUrl { get; set; }
}

public class LoginBody
{
    [Required]
    public string Username { get; set; }

    [Required]
    public string Password { get; set; }
}

