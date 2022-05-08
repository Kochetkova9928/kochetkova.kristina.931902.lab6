using System;

namespace WebApplication4.Models
{
    public class Folder
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Folder Parent { get; set; }
        public int? ParentId { get; set; }
    }
}
