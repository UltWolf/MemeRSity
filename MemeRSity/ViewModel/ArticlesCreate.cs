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
        public bool isPublish { get; set; }

        public static  implicit operator Article(ArticlesCreate articlesCreate)
        {
            Article article = new Article();
            article.Title = articlesCreate.Title;
            article.Category = articlesCreate.Category;
           
            return article;
        }
    }
}
