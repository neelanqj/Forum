using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Models
{
    public class Post
    {
        [Key]
        public int PostId { get; set; }
        public string Details { get; set; }
        public int TopicId { get; set; }
        public Topic Topic { get; set; }

        public List<Comment> Comments { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public DateTime ReviseDate { get; set; } = DateTime.Now;
        
        public User User { get; set; }
    }
}
