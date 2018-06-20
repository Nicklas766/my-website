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
        public void Test2_Create()
        {
            // Arrange
            var controller = new BlogController(_context);

            // Act
            var result = getListResult(controller.Create(
                new PostBody {
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

        //[Fact]
        //// Should change Post.IsDeleted to true
        //public void Test4_Update()
        //{
        //    // Arrange
        //    var controller = new BlogController(_context);

        //    // Act
        //    var invalidStatusCode = controller.Delete(100000000);
        //    var validStatusCode = controller.Delete(1);

        //    // Assert
        //    Assert.Equal(404, invalidStatusCode.StatusCode);
        //    Assert.Equal(200, validStatusCode.StatusCode);
        //}
    }
}
