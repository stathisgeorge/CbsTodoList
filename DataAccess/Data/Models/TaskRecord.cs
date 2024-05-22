using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data.Models
{
    [Table("TaskRecord")]
    public class TaskRecord
    {
        [Key]
        public int Id { get; set; }
        [Column("Title")]
        public string? Title { get; set; }
        [Column("Description")]
        public string? Description { get; set; }
        [Column("CreatedAt")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime CreatedAt { get; set; }= DateTime.Now;
        [Column("CompletedAt")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? CompletedAt { get; set;} 
        [Column("ModifiedAt")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? ModifiedAt { get; set;}
        [Column("Status")]
        public Status Status { get; set; }
        //[Column("Username")]
        //public string Username { get; set; }

        [NotMapped]
        public bool IsCompleted
        {
            get
            {
                return Status == Status.Completed;
            }
        }

        public int DaysFromCreatedDate
        {
            get
            {
                if (CompletedAt != null)
                    return (CompletedAt - CreatedAt).GetValueOrDefault().Days;
                else
                    return (CompletedAt - DateTime.Now).GetValueOrDefault().Days;
            }
        }
    }
}
