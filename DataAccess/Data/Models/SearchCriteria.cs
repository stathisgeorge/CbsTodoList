using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data.Models
{
    public class SearchCriteria
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime? CreatedAtFrom { get; set; }  
        public DateTime? CreatedAtTo { get; set; }
        public DateTime? CompletedAtFrom { get; set; }
        public DateTime? CompletedAtTo { get; set; }
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
