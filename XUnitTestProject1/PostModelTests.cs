using System;
using mywebsite.Controllers;
using Xunit;

using my_website.Data;
using my_website.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;


namespace XUnitTestProject1
{
    public class PostModelTests : BlogTestBase
    {

        [Fact]
        // Should create a slug based on the title
        public void TestSlugify()
        {
            // Arrange
            Post post = new Post { Text = "Hello" };

            // Act
            var result = Post.Slugify("my äwesömë title!!!!");

            // Assert
            Assert.Equal("my-awesome-title", result);
        }
    }
}
