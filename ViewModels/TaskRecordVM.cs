using DataAccess.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace CbsTodoList.ViewModels
{
    public class TaskRecordVM
    {
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        public string? Description { get; set; }

        public static TaskRecord CreateTaskFromAddForm(TaskRecordVM vm)
        {
            var task = new TaskRecord()
            {
                Title = vm.Title,
                Description = vm.Description,
                Status = DataAccess.Data.Status.Pending,
                CreatedAt = DateTime.Now,
            };
            return task;
        }
    }

    
}
