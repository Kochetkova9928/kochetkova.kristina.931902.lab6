using System;
using System.Collections.Generic;
using WebApplication4.Models;
using WebApplication4.Data;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using System.Linq;

namespace WebApplication4.ViewModels
{
    public class PostCreateModel
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public int TopicId { get; set; }
        public string TopicName { get; set; }
    }
}
