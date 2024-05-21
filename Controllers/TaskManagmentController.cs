using CbsTodoList.ViewModels;
using DataAccess.Data.Models;
using DataAccess.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

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
            var records = await _taskService.GetAllTaskRecords();
             return View(records);
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
                await _taskService.Add(new DataAccess.Data.Models.TaskRecord()
                {
                    Title = task.Title,
                    Description = task.Description,
                    Status = DataAccess.Data.Status.Pending,
                    CreatedAt = DateTime.Now,
                });
                return RedirectToAction("Index");
            }
            return PartialView("_AddTaskPartial", task);  
        }

        [Authorize]
        [HttpDelete]
        public async Task<IActionResult> DeleteTask(int id)
        {
            await _taskService.Delete(id);
            return RedirectToAction("Index");
        }

        [Authorize]
        [HttpPut]
        public async Task<IActionResult> ChangeTaskStatus(int id)
        {
            await _taskService.ChangeStatus(id);
            return RedirectToAction("Index","TaskManagment");

        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            var task= await _taskService.GetTaskById(Id);
            return View(task);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Edit(TaskRecord task)
        {
            await _taskService.Edit(task);
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
    }
}
