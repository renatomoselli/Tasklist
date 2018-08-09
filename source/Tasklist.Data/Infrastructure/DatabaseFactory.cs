using Tasklist.Data.Models;

namespace Tasklist.Data.Infrastructure
{
public class DatabaseFactory : Disposable, IDatabaseFactory
{
    private TasklistEntities dataContext;
    public TasklistEntities Get()
    {
        return dataContext ?? (dataContext = new TasklistEntities());
    }
    protected override void DisposeCore()
    {
        if (dataContext != null)
            dataContext.Dispose();
    }
}
}
