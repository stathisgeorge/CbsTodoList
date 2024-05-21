using DataAccess.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace CbsTodoList.ViewModels
{
    public class SearchViewModel
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? CompletedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public Status Status { get; set; }

        public bool IsCompleted
        {
            get
            {
                return Status == Status.Completed;
            }
        }
    }
}
