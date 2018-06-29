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
        public class SessionCheck : ActionFilterAttribute
        {
            public override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                var session = filterContext.HttpContext.Session;
                bool isLoggedAsAdmin = !string.IsNullOrEmpty(session.GetString("isAdmin"));
               
                if (!isLoggedAsAdmin)
                    filterContext.Result = new BadRequestObjectResult("Access denied!");
            }
        }


        // POST api/admin/login
        [HttpGet("login")]
        public StatusCodeResult postLogin(string username, string password)
        {
            Admin admin = _context.Admins.FirstOrDefault(curAdmin => curAdmin.Username == username);

            if (admin != null && admin.Password == password)
            {
                HttpContext.Session.SetString("isAdmin", "yes");
                return StatusCode(200);
            }

            return StatusCode(404);
        }

        // GET api/admin/logout
        [SessionCheck]
        [HttpGet("logout")]
        public StatusCodeResult getLogout()
        {
            HttpContext.Session.SetString("isAdmin", "");
            return StatusCode(200);
        }

        // POST api/admin/create
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
    }


