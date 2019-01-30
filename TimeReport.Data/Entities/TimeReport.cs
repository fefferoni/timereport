using System;
using System.Collections.Generic;
using System.Text;

namespace TimeReport.Data.Entities
{
    public class TimeReport : BaseEntity
    {
        public DateTime Date { get; set; }
        public User User { get; set; }
        public Task Task { get; set; }
        public double TimeWorked { get; set; }
    }
}
