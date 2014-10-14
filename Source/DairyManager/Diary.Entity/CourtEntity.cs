using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Diary.Entity
{
    public class CourtEntity
    {
        public Guid CourtId { get; set; }
        public string Court { get; set; }
        public Guid CourtTypeId { get; set; }
        public string PoliceStation { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
