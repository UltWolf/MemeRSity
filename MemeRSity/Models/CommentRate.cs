namespace MemeRSity.Models
{
    public class CommentRate
    {
        public int Id { get; set; }
        public Comment Comment { get; set; }
        public int Likes { get; set; }
        public int DisLikes { get; set; }
    }
}