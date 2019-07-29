using MemeRSity.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MemeRSity.ViewModel
{
    public class ArticlesCreate
    {
        public int Id { get; set; }
        public string Title { get; set; } 
        public Category Category { get; set; } 
        public List<Tag> Tags { get; set; } 
        public IFormFile Image { get; set; }

        public static  implicit operator Article(ArticlesCreate articlesCreate)
        {
            Article article = new Article();
            article.Title = articlesCreate.Title;
            article.Tags = article.Tags;
            using (var memoryStream = new MemoryStream())
            {
                articlesCreate.Image.CopyTo(memoryStream);
                article.Img = memoryStream.ToArray();
            }
            return article;
        }
    }
}
