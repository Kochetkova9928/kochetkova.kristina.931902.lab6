using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace WebApplication4.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime CreatedTime { get; set; }
        public IdentityUser Author { get; set; }
        public int TopicId { get; set; }
        public Topic Topic { get; set; }
        public ICollection<Reply> Replies { get; set; }
    }
}
