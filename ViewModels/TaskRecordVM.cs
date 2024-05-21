using System.ComponentModel.DataAnnotations;

namespace CbsTodoList.ViewModels
{
    public class TaskRecordVM
    {
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        public string Description { get; set; }
    }
}
