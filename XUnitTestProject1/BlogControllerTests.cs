using mywebsite.Controllers;
using Xunit;
using my_website.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace XUnitTestProject1
{
    public class BlogControllerTests : BlogTestBase
    {

        [Fact]
        public void Test1_GetAll()
        {
            // Arrange
            var controller = new BlogController(_context);

            // Act
            IActionResult actionResult = controller.GetAll();
            var objectResult           = Assert.IsType<OkObjectResult>(actionResult);
            List<Post> result          = objectResult.Value as List<Post>;

            // Assert
            Assert.Equal("Text1", result[0].Text);
        }

        [Fact]
        public void Test2_GetBySlug_ShouldPass()
        {
            // Arrange
            var controller = new BlogController(_context);

            // Act
            IActionResult actionResult = controller.GetBySlug("my-slug-1");
            var okObjectResult         = Assert.IsType<OkObjectResult>(actionResult);
            Post post                  = okObjectResult.Value as Post;

            // Assert
            Assert.Equal(1, post.ID);
            Assert.Equal("Text1", post.Text);
        }

        [Fact]
        public void Test3_GetBySlug_ShouldFail()
        {
            // Arrange
            var controller = new BlogController(_context);

            // Act
            IActionResult actionResult = controller.GetBySlug("this-slug-is-not-in-db");
            StatusCodeResult result    = Assert.IsType<StatusCodeResult>(actionResult);
          
            // Assert
            Assert.Equal(404, result.StatusCode);

        }
    }
}
