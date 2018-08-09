using AutoMapper;
using Tasklist.Model.Models;
using Tasklist.Service;
using Tasklist.Web.ViewModels;
using System;
using System.Web.Mvc;

namespace Tasklist.Web.Controllers
{
    //[Authorize]
    public class TaskController : Controller
    {
        private readonly ITaskService taskService;

        public TaskController(ITaskService taskService)
        {
            this.taskService = taskService;
        }

        public ActionResult Index()
        {
            var model = new TaskViewModel();

            return View();
        }

        public ActionResult Task(TaskViewModel model)
        {
            if (model.Id == 0)
                return PartialView();

            var task = taskService.GetTask(model.Id);
            if (task == null)
            {
                return HttpNotFound();
            }

            var taskViewModel = Mapper.Map<Task, TaskViewModel>(task);

            return PartialView(taskViewModel);
        }

        [HttpPost]
        public ActionResult Create(TaskViewModel taskViewModel)
        {
            if (ModelState.IsValid)
            {
                Task task = Mapper.Map<TaskViewModel, Task>(taskViewModel);
                task.LastUpdated = DateTime.Now;
                taskService.CreateTask(task);
                taskViewModel.Id = task.Id;
            }

            return View("Index", taskViewModel);
        }

        [HttpPost]
        public ActionResult Edit(TaskViewModel taskViewModel)
        {
            if (ModelState.IsValid)
            {
                var task = Mapper.Map<TaskViewModel, Task>(taskViewModel);

                task.LastUpdated = DateTime.Now;
                taskService.EditTask(task);
            }

            return View("Index", taskViewModel);
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            var task = taskService.GetTask(id);
            if (task == null)
            {
                return Json(false);
            }

            taskService.DeleteTask(id);

            return Json(true);
        }

        [HttpGet]
        public JsonResult ListOfTasks(string sort = null, string order = null, int offset = 0, int limit = 25)
        {
            var tasks = taskService.GetTasks();
            return Json(tasks, JsonRequestBehavior.AllowGet);
        }
    }
}