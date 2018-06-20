using System;
using mywebsite.Controllers;
using Xunit;

using my_website.Data;
using my_website.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using static mywebsite.Controllers.BlogController;

namespace XUnitTestProject1
{
    public class BlogControllerTests : BlogTestBase
    {
        public List<Post> getListResult(IActionResult result)
        {
            var objectResult = Assert.IsType<OkObjectResult>(result);
            return objectResult.Value as List<Post>;
        }

        [Fact]
        public void TestGetall()
        {
            // Arrange
            var controller = new BlogController(_context);

            // Act
            var result = getListResult(controller.GetAll());

            // Assert
            Assert.Equal("Text1", result[0].Text);
        }

        [Fact]
        public void TestPost()
        {
            // Arrange
            var controller = new BlogController(_context);

            // Act
            var result = getListResult(controller.Create(
                new PostBody {
                    title = "my title",
                    slug ="my slug",
                    text ="my text"
                }));

            // Assert
            Assert.Equal("my title", result[1].Title);
            Assert.Equal("my-slug", result[1].Slug);
            Assert.Equal("my text", result[1].Text);
        }
    }
}
