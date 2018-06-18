using my_website.Models;
using System;
using System.Linq;

namespace my_website.Data
{
    public static class DbInitializer
    {
        public static void Initialize(BlogContext context)
        {
            context.Database.EnsureCreated();

            // Look for any posts.
            if (context.Posts.Any())
            {
                return;   // DB has been seeded
            }

            var posts = new Post[]
            {
                new Post{Text="text1"},
                new Post{Text="text2"}
            };

            foreach (Post s in posts)
            {
                context.Posts.Add(s);
            }

            context.SaveChanges();
        }
    }
}