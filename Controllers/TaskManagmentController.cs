using DataAccess.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult Index()
        {
            var records = _taskService.GetAllTaskRecords();
            return View(records);
        }
        [Authorize]
        public ActionResult AddTask()
        {
            _taskService.Add(new DataAccess.Data.Models.TaskRecord()
            {
                Status=DataAccess.Data.Status.Uncompleted,
                CompletedAt=DateTime.Now,
                CreatedAt=DateTime.Now,
                Description="SADASD",
                ModifiedAt=DateTime.Now,
                Title="S"
            });
            return View();
        }


    }
}
