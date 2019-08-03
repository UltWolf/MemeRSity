using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MemeRSity.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Article> Articles { get; set; } = new List<Article>();
    }
}
