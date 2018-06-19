using System;
using System.Collections.Generic;
using System.Text;
using my_website.Data;
using my_website.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace XUnitTestProject
{
    public class BlogTestBase : IDisposable
    {

        protected readonly BlogContext _context;

        public BlogTestBase()
        {
            var options = new DbContextOptionsBuilder<BlogContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            _context = new BlogContext(options);

            _context.Database.EnsureCreated();

            _context.Posts.Add(new Post { Text = "yes" });
            _context.SaveChanges();
        }


        public void Dispose()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }
    }
}
