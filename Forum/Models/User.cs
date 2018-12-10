using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Models
{
    public class User : IdentityUser
    {
        // public string FirstName { get; set; }
        // public string LastName { get; set; }
        [Required]
        public string WebName { get; set; } = "Anonymous";

        public DateTime CreateDate { get; set; } = DateTime.Now;
        public DateTime ReviseDate { get; set; } = DateTime.Now;
    }
}
