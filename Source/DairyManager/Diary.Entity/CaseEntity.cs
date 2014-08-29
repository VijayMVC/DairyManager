using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diary.Entity
{
    public class CaseEntity
    {
        public Guid CaseId { get; set; }
        public string Code { get; set; }
        public string Case { get; set; }
        public Guid ClientId { get; set; }
        public Guid CaseTypeId { get; set; }
        public Guid OffenceTypeId { get; set; }
        public Guid CourtId { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsDeleted { get; set; }
        public DataSet Clients { get; set; }
        

    }
}
