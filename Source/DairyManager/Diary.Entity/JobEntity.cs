﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diary.Entity
{
    public class JobEntity
    {
        public int JobId { get; set; } 
        public string JobName { get; set; } 
        public string JobDescription { get; set; } 
        public Guid CreatedBy { get; set; } 
        public DateTime CreatedDate { get; set; } 
        public Guid UpdatedBy { get; set; } 
        public DateTime UpdatedDate { get; set; } 
        public bool IsDeleted { get; set; }
    }
}
