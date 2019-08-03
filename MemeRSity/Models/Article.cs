using MemeRSity.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MemeRSity.Models
{
    public class Article
    {
        public int  Id { get; set; }
        public string Title { get; set; }
        public UserApp Author { get; set; }
        public Category Category { get; set; }
        public List<Comment> Comments { get; set; } = new List<Comment>();
        public List<ArticleTag> Tags { get; set; } = new List<ArticleTag>();
        public byte[] Img { get; set; }  
        
    }
}
