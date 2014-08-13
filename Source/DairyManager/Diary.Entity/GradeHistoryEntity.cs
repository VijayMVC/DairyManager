using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diary.Entity
{
    public class GradeHistoryEntity
    {
        public int GradeHistoryId { get; set; } 
        public Guid UserId { get; set; } 
        public int? OldGradeId { get; set; } 
        public int NewGradeId { get; set; } 
        public DateTime ChangedDate { get; set; } 
        public Guid CreatedBy { get; set; } 
        public DateTime CreatedDate { get; set; }
    }
}
