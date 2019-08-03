using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MemeRSity.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ArticleTag> Articles { get; set; } = new List<ArticleTag>();
    }
}
