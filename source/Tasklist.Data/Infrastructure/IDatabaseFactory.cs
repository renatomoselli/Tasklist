using System;
using Tasklist.Data.Models;

namespace Tasklist.Data.Infrastructure
{
    public interface IDatabaseFactory : IDisposable
    {
        TasklistEntities Get();
    }
}
