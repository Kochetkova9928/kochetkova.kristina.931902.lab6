using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace WebApplication4.Models
{
    public class Reply
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime EditTime { get; set; }
        public IdentityUser Author { get; set; }
        public int PostId { get; set; }
        public Post Post { get; set; }
    }
}
