using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diary.Entity
{
    public class TaskEntity
    {
        public Guid TaskId { get; set; }
        public DateTime TaskDate { get; set; }
        public Guid CaseId { get; set; }
        public Guid TaskTypeId { get; set; }
        public string TaskDescription { get; set; }
        public decimal TotalRemainingHours { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public decimal TotalHours { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsDeleted { get; set; }


      
    }
}
