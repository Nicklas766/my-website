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
        public void Test1_GetAll()
        {
            // Arrange
            var controller = new BlogController(_context);

            // Act
            var result = getListResult(controller.GetAll());

            // Assert
            Assert.Equal("Text1", result[0].Text);
        }

        [Fact]
        public void Test2_GetBySlugSuccess()
        {
            // Arrange
            var controller = new BlogController(_context);

            // Act
            IActionResult actionResult = controller.GetBySlug("my-slug-1");

            var okObjectResult = Assert.IsType<OkObjectResult>(actionResult);
            Post post = okObjectResult.Value as Post;

            // Assert
            Assert.Equal(1, post.ID);
            Assert.Equal("Text1", post.Text);
        }

        [Fact]
        public void Test2_GetBySlugFail()
        {
            // Arrange
            var controller = new BlogController(_context);

            // Act
            IActionResult actionResult = controller.GetBySlug("this-slug-is-not-in-db");

            var result = Assert.IsType<StatusCodeResult>(actionResult);
          
            // Assert
            Assert.Equal(404, result.StatusCode);

        }

        [Fact]
        public void Test3_Create()
        {
            // Arrange
            var controller = new BlogController(_context);

            // Act
            var result = getListResult(controller.Create(
                new CreateAndUpdateBody {
                    title = "my title",
                    slug  = "my slug",
                    text  = "my text"
                }));

            // Assert
            Assert.Equal("my title", result[1].Title);
            Assert.Equal("my-slug", result[1].Slug);
            Assert.Equal("my text", result[1].Text);
            Assert.False(result[1].IsDeleted);
        }

        [Fact]
        // Fails when run in test suite, success when run separately
        public void Test3_Delete()
        {
            // Arrange
            var controller = new BlogController(_context);

            // Act
            var invalidStatusCode = controller.Delete(100000000);
            var validStatusCode = controller.Delete(1);

            // Assert
            Assert.Equal(404, invalidStatusCode.StatusCode);
            Assert.Equal(200, validStatusCode.StatusCode);
        }

        [Fact]
        // Should change post.text to "im changed", regarding post with id 1
        public void Test4_UpdateSuccess()
        {
            // Arrange
            var controller = new BlogController(_context);

            // Act
            IActionResult actionResult = controller.Update(new CreateAndUpdateBody
            {
                id = 1,
                title = "my title",
                slug = "my slug",
                text = "im changed"
            });

            var okObjectResult = Assert.IsType<OkObjectResult>(actionResult);
            Post updatedPost = okObjectResult.Value as Post;

            // Assert
            Assert.Equal("im changed", updatedPost.Text);
            Assert.Equal("my-slug", updatedPost.Slug);
        }

        [Fact]
        // Should fail since no post with id 1234 exists
        public void Test5_UpdateFail()
        {
            // Arrange
            var controller = new BlogController(_context);

            // Act
            IActionResult actionResult = controller.Update(new CreateAndUpdateBody
            {
                id = 1234,
                title = "my title",
                slug = "my slug",
                text = "im changed"
            });

            var statusCodeResult = Assert.IsType<StatusCodeResult>(actionResult);
            int? statusCode = statusCodeResult.StatusCode as int?;

            // Assert
            Assert.Equal(404, statusCode);
        }
    }
}
