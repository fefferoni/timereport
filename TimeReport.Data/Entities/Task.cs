using System;
using System.Collections.Generic;
using System.Text;

namespace TimeReport.Data.Entities
{
    public class Task : BaseEntity
    {
        public string Name { get; set; }
        public Project Project { get; set; }
    }
}
