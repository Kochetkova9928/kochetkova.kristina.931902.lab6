using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace WebApplication4.Models
{
    public class Topic
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedTime { get; set; }
        public IdentityUser Author { get; set; }
        public ICollection<Post> Posts { get; set; }
    }
}
