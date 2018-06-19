using System;
using System.Collections.Generic;

namespace my_website.Models
{
    public class Post
    {
        public int ID { get; set; }
        public string Text { get; set; }
        public DateTime PublishDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}