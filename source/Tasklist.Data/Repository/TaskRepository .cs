using Tasklist.Data.Infrastructure;
using Tasklist.Model.Models;

namespace Tasklist.Data.Repository
{
    public class TaskRepository : RepositoryBase<Task>, ITaskRepository
    {
        public TaskRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }
    }
    public interface ITaskRepository : IRepository<Task>
    {

    }
}