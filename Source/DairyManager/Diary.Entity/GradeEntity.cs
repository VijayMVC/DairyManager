using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diary.Entity
{
    public class GradeEntity
    {
        public int GradeId { get; set; } 
        public string GradeName { get; set; } 
        public string Description { get; set; } 
        public Guid CreatedBy { get; set; } 
        public DateTime CreatedDate { get; set; } 
        public Guid UpdatedBy { get; set; } 
        public DateTime UpdatedDate { get; set; }
    }
}
