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
        public void Test1_Slugify()
        {
            // Arrange
            Post post = new Post { Text = "Hello" };

            // Act
            var result = Post.Slugify("my äwesömë title!!!!");

            // Assert
            Assert.Equal("my-awesome-title", result);
        }

        [Fact]
        public void Test2_SetAttributes()
        {
            // Arrange
            Post post = new Post();

            CreateAndUpdateBody attributes = new CreateAndUpdateBody
            {
                Slug = "slug",
                Title = "my title",
                Text = "my text"
            };
            // Act
            post.SetAttributes(attributes);

            // Assert
            Assert.Equal(DateTime.Now.ToString("yyyy-MM-dd"), post.PublishDate.ToString("yyyy-MM-dd"));
        }

        [Fact]
        public void Test3_SetAttributes_ShouldHaveUpdateDate()
        {
            // Arrange
            Post post = new Post();

            CreateAndUpdateBody attributes = new CreateAndUpdateBody
            {
                Slug = "slug",
                Title = "my title",
                Text = "my text"
            };
            // Act
            post.SetAttributes(attributes);
            post.SetAttributes(attributes);

            // Assert
            Assert.Equal(DateTime.Now.ToString("yyyy-MM-dd"), post.UpdatedDate.ToString("yyyy-MM-dd"));
        }

        [Fact]
        public void Test4_SetAttributes_ShouldNotHaveUpdateDate()
        {
            // Arrange
            Post post = new Post();

            CreateAndUpdateBody attributes = new CreateAndUpdateBody
            {
                Slug = "slug",
                Title = "my title",
                Text = "my text"
            };
            // Act
            post.SetAttributes(attributes);

            // Assert
            Assert.NotEqual(DateTime.Now.ToString("yyyy-MM-dd"), post.UpdatedDate.ToString("yyyy-MM-dd"));
        }




    }
}
