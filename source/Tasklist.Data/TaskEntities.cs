using Tasklist.Data.Configuration;
using Tasklist.Model.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Tasklist.Data.Models
{
    public class TasklistEntities : DbContext
    {

        public TasklistEntities()
            : base("TasklistEntities")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<TasklistEntities>());
        }
        public DbSet<Task> Task { get; set; }

        public virtual void Commit()
        {
            base.SaveChanges();
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<IncludeMetadataConvention>();

            modelBuilder.Configurations.Add(new TaskConfiguration());
        }
    }
}