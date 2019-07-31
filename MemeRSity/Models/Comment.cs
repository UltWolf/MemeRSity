using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MemeRSity.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public UserApp Author { get; set; }
        public DateTime Time { get; set; }
        public string Text { get; set; }
        public CommentRate Rate { get; set; }
    }
}
