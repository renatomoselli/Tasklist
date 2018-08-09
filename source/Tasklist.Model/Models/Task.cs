using System;

namespace Tasklist.Model.Models
{
    public class Task
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public bool Completed { get; set; }

        public DateTime LastUpdated { get; set; }
    }
}
