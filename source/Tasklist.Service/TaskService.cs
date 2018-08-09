using Tasklist.Data.Infrastructure;
using Tasklist.Data.Repository;
using Tasklist.Model.Models;
using System.Collections.Generic;

namespace Tasklist.Service
{
    public interface ITaskService
    {
        IEnumerable<Task> GetTasks();
        Task GetTask(int id);
        void CreateTask(Task task);
        void DeleteTask(int id);
        void EditTask(Task task);
        void SaveTask();
    }
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository taskRepository;
        private readonly IUnitOfWork unitOfWork;

        public TaskService(ITaskRepository taskRepository, IUnitOfWork unitOfWork)
        {
            this.taskRepository = taskRepository;
            this.unitOfWork = unitOfWork;
        }

        #region ISupportInvitationService Members

        public IEnumerable<Task> GetTasks()
        {
            var tasks = taskRepository.GetAll();
            return tasks;
        }

        public Task GetTask(int id)
        {
            var task = taskRepository.GetById(id);
            return task;
        }

        public void CreateTask(Task task)
        {
            taskRepository.Add(task);
            SaveTask();
        }

        public void DeleteTask(int id)
        {
            var task = taskRepository.GetById(id);
            taskRepository.Delete(task);
            SaveTask();
        }

        public void EditTask(Task task)
        {
            taskRepository.Update(task);
            SaveTask();
        }

        public void SaveTask()
        {
            unitOfWork.Commit();
        }

        #endregion
    }
}
