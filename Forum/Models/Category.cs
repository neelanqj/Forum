using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string Name { get; set; }

        public virtual IEnumerable<Topic> Topics { get; set; }

        public DateTime CreateDate { get; set; } = DateTime.Now;
        public DateTime ReviseDate { get; set; } = DateTime.Now;

        public User User { get; set; }
    }
}
