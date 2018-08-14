using mywebsite.Controllers;
using System;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace my_website.Models
{
    public class Post
    {
        public int ID { get; set; }

        public string Slug { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string ImageUrl { get; set; }

        public bool IsDeleted { get; set; } = false;
        public DateTime PublishDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        private bool isPublishDateSet()
        {
            return this.PublishDate != DateTime.MinValue;
        }
        public void SetAttributes(CreateAndUpdateBody body)
        {
            Slug = Slugify(body.Slug);
            Title = body.Title;
            Text = body.Text;
            ImageUrl = body.ImageUrl;

            if (isPublishDateSet())
                UpdatedDate = DateTime.Now;
            else
                PublishDate = DateTime.Now;
        }

        public static string Slugify(string phrase)
        {
            string str = RemoveDiacritics(phrase).ToLower();
            // invalid chars           
            str = Regex.Replace(str, @"[^a-z0-9\s-]", "");
            // convert multiple spaces into one space   
            str = Regex.Replace(str, @"\s+", " ").Trim();
            // cut and trim 
            str = str.Substring(0, str.Length <= 45 ? str.Length : 45).Trim();
            str = Regex.Replace(str, @"\s", "-"); // hyphens   
            return str;
        }

        public static string RemoveDiacritics(string text)
        {
            var normalizedString = text.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder();

            foreach (var c in normalizedString)
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
        }
    }


    

}