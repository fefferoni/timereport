using System;
using System.Collections.Generic;
using System.Text;

namespace TimeReport.Data.Entities
{
    public class Project : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Task> Tasks { get; set; }
    }
}
