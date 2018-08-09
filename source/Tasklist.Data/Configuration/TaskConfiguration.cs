using Tasklist.Model.Models;
using System.Data.Entity.ModelConfiguration;

namespace Tasklist.Data.Configuration
{
    public class TaskConfiguration : EntityTypeConfiguration<Task>
    {
        public TaskConfiguration()
        {
            Property(c => c.Title).IsRequired().HasMaxLength(100);
            Property(c => c.Description).IsRequired().HasMaxLength(1000);
            Property(c => c.Completed).IsRequired();
            Property(c => c.LastUpdated).IsRequired();
        }
    }
}
