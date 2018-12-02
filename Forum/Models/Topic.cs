using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Models
{
    public class Topic
    { 
        [Key]
        public int TopicId { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
        
        public User User { get; set; }
    }
}
