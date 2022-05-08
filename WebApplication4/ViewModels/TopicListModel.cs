using System;
using System.Collections.Generic;
using WebApplication4.Models;
using WebApplication4.Data;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace WebApplication4.ViewModels
{
    public class TopicListModel
    {
        public ICollection<TopicDto> Topics { get; set; }
        public bool CanEdit { get; set; }

        public TopicListModel(ApplicationDbContext context, ClaimsPrincipal user)
        {
            Topics = context.Topics
                .Include(x => x.Posts)
                .ThenInclude(x => x.Replies)
                .ThenInclude(x => x.Author)
                .Select(x => new TopicDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    CreatedTime = x.CreatedTime,
                    LastReply = x.Posts.SelectMany(x => x.Replies).OrderByDescending(x => x.EditTime).FirstOrDefault(),
                    Author = x.Author,
                    PostCount = x.Posts.Count,
                    ReplyCount = x.Posts.SelectMany(x => x.Replies).Count()
                }).ToList();

            CanEdit = user.IsInRole("admin");
        }
    }

    public class TopicDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedTime { get; set; }
        public Reply LastReply { get; set; }
        public IdentityUser Author { get; set; }
        public int PostCount { get; set; }
        public int ReplyCount { get; set; }
    }
}
