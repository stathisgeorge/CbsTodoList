using CbsTodoList.ViewModels;
using DataAccess.Data.Models;
using DataAccess.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;

namespace CbsTodoList.Controllers
{
    public class TaskManagmentController : Controller
    {
        private ITodoTaskService _taskService;
        public TaskManagmentController(ITodoTaskService taskService)
        {
            _taskService = taskService;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var tasks = new List<TaskRecord>();
            if (ExistsTasksInSession())
            {
                tasks = GetTasksFromSession();
            }
            else
            {
                var username = HttpContext.User.Identity.Name;
                tasks = await _taskService.GetAllTaskRecords(username);
                RefreshTasksToSession(tasks);
            }
            return View(tasks);
        }

        [Authorize]
        public async Task<IActionResult> TasksList()
        {
            var username = HttpContext.User.Identity.Name;
            var records = await _taskService.GetAllTaskRecords(username);
            return PartialView("_TaskListPartial", records);
        }

        [HttpGet]
        [Authorize]
        public ActionResult AddTask()
        {
            return PartialView("_AddTaskPartial");
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddTask(TaskRecordVM task)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var newTask = TaskRecordVM.CreateTaskFromAddForm(task); 
                    newTask.Username = HttpContext.User.Identity.Name;
                    await _taskService.Add(newTask);
                    if (ExistsTasksInSession())
                    {
                        AddTaskToSession(newTask);
                    }
                    TempData["SuccessMessage"] = "Task saved successfully!";
                }
                catch (Exception ex)
                {
                    TempData["ErrorMessage"] = "An error has occured!";
                }
            }
            return RedirectToAction("Index");
        }
        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> DeleteTask(int id)
        {
            try
            {
                var result = await _taskService.Delete(id);
                if (result > 0)
                    DeleteFromSessionAsync(id);
                TempData["SuccessMessage"] = "Task deleted successfully!";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "An error has occured!";
            }
            return Json(new { redirectToUrl = Url.Action("Index", "TaskManagment") });
        }



        [HttpPut]
        [Authorize]
        public async Task<IActionResult> ChangeTaskStatus(int id)
        {
            try
            {
                var resullt = await _taskService.ChangeStatus(id);
                if (resullt)
                    UpdateTaskStatusInSession(id);
            }catch(Exception ex)
            {
                TempData["ErrorMessage"] = "An error has occured!";
            }

            return Json(new { redirectToUrl = Url.Action("Index", "TaskManagment") });
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            var task = await _taskService.GetTaskById(Id);
            return View(task);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Edit(TaskRecord task)
        {
            try
            {
                await _taskService.Edit(task);
                EditTaskInSession(task);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "An error has occured!";
            }
            return RedirectToAction("Index");
        }

        [Authorize]
        public ActionResult Search()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Search(SearchViewModel model)
        {
            var tasks = await _taskService.Search(new SearchCriteria
            {
                CompletedAtFrom = model.CompletedAt,
                Title = model.Title,
                Description = model.Description,
                CompletedAtTo = model.CompletedAt
            });
            return PartialView("_TasksPartial", tasks);
        }


        #region SessionImplementation
        private bool ExistsTasksInSession()
        {
            var sessionTasks = HttpContext.Session.GetString("TasksList");
            return !string.IsNullOrEmpty(sessionTasks);
        }

        private void AddTaskToSession(TaskRecord newTask)
        {
            var tasks = new List<TaskRecord>();

            if (ExistsTasksInSession())
            {
                tasks = GetTasksFromSession();
            }
            tasks.Add(newTask);
            tasks = tasks.OrderByDescending(t => t.CreatedAt).ToList();
            HttpContext.Session.SetString("TasksList", JsonConvert.SerializeObject(tasks.OrderByDescending(t => t.CreatedAt)));
        }
        private void RefreshTasksToSession(List<TaskRecord> tasks)
        {
            if (tasks != null)
                tasks = tasks.OrderByDescending(t => t.CreatedAt).ToList();
            HttpContext.Session.SetString("TasksList", JsonConvert.SerializeObject(tasks));
        }
        private List<TaskRecord> GetTasksFromSession()
        {
            var taskSessionString = HttpContext.Session.GetString("TasksList");
            var tasksList = JsonConvert.DeserializeObject<List<TaskRecord>>(taskSessionString);
            return tasksList;
        }

        private void EditTaskInSession(TaskRecord editedTask)
        {
            if (ExistsTasksInSession())
            {

                var tasksList = GetTasksFromSession();
                if (tasksList != null)
                {
                    foreach (var task in tasksList.Where(t => t.Id == editedTask.Id))
                    {
                        task.Status = editedTask.Status;
                        task.Title = editedTask.Title;
                        task.Description = editedTask.Description;
                    }
                    RefreshTasksToSession(tasksList);
                }
            } 
        }

        private void DeleteFromSessionAsync(int id)
        {
            if (ExistsTasksInSession())
            {
                var tasks = GetTasksFromSession();
                var taskToDelete = tasks.Where(task => task.Id == id).FirstOrDefault();
                if (taskToDelete != null)
                    tasks.Remove(taskToDelete);
                RefreshTasksToSession(tasks);
            }
        }

        private void UpdateTaskStatusInSession(int Id)
        {
            if (ExistsTasksInSession())
            {
                var tasksList = GetTasksFromSession();
                if (tasksList != null)
                {
                    foreach (var task in tasksList.Where(t => t.Id == Id))
                    {
                        task.Status = (task.Status == DataAccess.Data.Status.Completed)
                            ? DataAccess.Data.Status.Pending
                            : DataAccess.Data.Status.Completed;
                    }
                    RefreshTasksToSession(tasksList);
                } 
            }
        }
        #endregion
    }
}
