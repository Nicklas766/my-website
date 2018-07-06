using mywebsite.Controllers;
using Xunit;
using my_website.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace XUnitTestProject1
{
    public class AdminControllerTests : BlogTestBase
    {
        [Fact]
        public void Test1_Login_ShouldPass()
        {
            // Arrange
            var controller = new AdminController(_context);

            // Act
            StatusCodeResult StatusCode = controller.postLogin(new LoginBody
            {
                Username = "username123",
                Password = "password123"
            });

            // Assert
            Assert.Equal(200, StatusCode.StatusCode);
        }

        [Fact]
        public void Test2_Login_ShouldFail()
        {
            // Arrange
            var controller = new AdminController(_context);

            // Act
            StatusCodeResult StatusCode = controller.postLogin(new LoginBody {
                Username = "username1223", 
                Password = "wrong" 
                });

            // Assert
            Assert.Equal(404, StatusCode.StatusCode);
        }


        [Fact]
        public void Test3_Logout_ShouldPass()
        {
            // Arrange
            var controller = new AdminController(_context);

            // Act
            StatusCodeResult StatusCode = controller.getLogout();

            // Assert
            Assert.Equal(200, StatusCode.StatusCode);
        }

        [Fact]
        public void Test4_Create_ShouldPass()
        {
            // Arrange
            var controller = new AdminController(_context);

            // Act
            IActionResult actionResult = controller.Create(new CreateAndUpdateBody
            {
                Title = "my title",
                Slug = "my slug",
                Text = "my text"
            });

            var okObjectResult = Assert.IsType<OkObjectResult>(actionResult);
            Post createdPost = okObjectResult.Value as Post;

            // Assert
            Assert.Equal("my title", createdPost.Title);
            Assert.Equal("my-slug", createdPost.Slug);
            Assert.Equal("my text", createdPost.Text);
            Assert.False(createdPost.IsDeleted);
        }

        [Fact]
        // Should fail due to lack of slug param
        public void Test5_Create_ShouldFail()
        {
            // Arrange
            var controller = new AdminController(_context);

            // Act
            IActionResult actionResult = controller.Create(new CreateAndUpdateBody
            {
                Title = "my title",
                Text = "Text here!"
            });

            // Assert
            var statusCodeResult = Assert.IsType<StatusCodeResult>(actionResult);

            // Assert
            Assert.Equal(404, statusCodeResult.StatusCode);
        }


        [Fact]
        public void Test6_Delete()
        {
            // Arrange
            var controller = new AdminController(_context);

            // Act
            var invalidStatusCode = controller.Delete(100000000);
            var validStatusCode = controller.Delete(1);

            // Assert
            Assert.Equal(404, invalidStatusCode.StatusCode);
            Assert.Equal(200, validStatusCode.StatusCode);
        }

        [Fact]
        // Should change post.text to "im changed", regarding post with id 1
        public void Test7_Update_ShouldPass()
        {
            // Arrange
            var controller = new AdminController(_context);

            // Act
            IActionResult actionResult = controller.Update(new CreateAndUpdateBody
            {
                Id = 1,
                Title = "my title",
                Slug = "my slug",
                Text = "im changed"
            });

            var okObjectResult = Assert.IsType<OkObjectResult>(actionResult);
            Post updatedPost = okObjectResult.Value as Post;

            // Assert
            Assert.Equal("im changed", updatedPost.Text);
            Assert.Equal("my-slug", updatedPost.Slug);
        }

        [Fact]
        // Should fail since no post with id 1234 exists
        public void Test8_Update_ShouldFail()
        {
            // Arrange
            var controller = new AdminController(_context);

            // Act
            IActionResult actionResult = controller.Update(new CreateAndUpdateBody
            {
                Id = 1234,
                Title = "my title",
                Slug = "my slug",
                Text = "im changed"
            });

            var statusCodeResult = Assert.IsType<StatusCodeResult>(actionResult);

            // Assert
            Assert.Equal(404, statusCodeResult.StatusCode);
        }

    }
}
