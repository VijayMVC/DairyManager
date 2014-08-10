using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diary.Entity
{
    public class LocationEntity
    {
        public int LocationId { get; set; }
        public string LocationName { get; set; } 
        public string Description { get; set; } 
        public Guid CreatedBy { get; set; } 
        public DateTime CreatedDate { get; set; } 
        public Guid UpdatedBy { get; set; } 
        public DateTime UpdatedDate { get; set; } 
        public bool IsDeleted { get; set; }
    }
}
