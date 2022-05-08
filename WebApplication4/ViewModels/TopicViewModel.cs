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
    public class TopicViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreateTime { get; set; }
        public IdentityUser Author { get; set; }

        public ICollection<PostDto> Posts { get; set; }
        public bool CanEdit { get; set; }

        public TopicViewModel(Topic topic, ClaimsPrincipal user)
        {
            Id = topic.Id;
            Name = topic.Name;
            CreateTime = topic.CreatedTime;
            Author = topic.Author;
            Posts = topic.Posts.Select(x => new PostDto
            {
                Id = x.Id,
                Title = x.Title,
                CreatedTime = x.CreatedTime,
                Author = x.Author,
                LastReply = x.Replies.OrderByDescending(x => x.EditTime).First(),
                ReplyCount = x.Replies.Count
            }).ToList();

            CanEdit = user.IsInRole("admin");
        }
    }

    public class PostDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime CreatedTime { get; set; }
        public Reply LastReply { get; set; }
        public IdentityUser Author { get; set; }
        public int ReplyCount { get; set; }
    }
}
