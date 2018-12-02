using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        public int PostId { get; set; }
        public Post Post { get; set; }
        public string Details { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public DateTime ReviseDate { get; set; } = DateTime.Now;
        
        public User User { get; set; }
    }
}
