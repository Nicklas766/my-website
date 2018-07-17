using System;
using System.Collections.Generic;
using System.Text;
using my_website.Data;
using my_website.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace XUnitTestProject1
{
    public class BlogTestBase : IDisposable
    {

        protected readonly BlogContext _context;

        public BlogTestBase()
        {

            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .AddDistributedMemoryCache()
        

                .BuildServiceProvider();
      


            var options = new DbContextOptionsBuilder<BlogContext>()
                .UseInMemoryDatabase()
                .UseInternalServiceProvider(serviceProvider)
                .Options;

     

            _context = new BlogContext(options);

            _context.Database.EnsureCreated();

            _context.Add(new Post { Text = "Text1", Slug = "my-slug-1" });
            _context.Add(new Admin { Username = "username123", Password = "password123" });
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }
    }
}
