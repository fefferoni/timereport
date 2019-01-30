using System;
using System.Collections.Generic;
using System.Text;

namespace TimeReport.Data.Entities
{
    public class Task : BaseEntity
    {
        public string Name { get; set; }
        public Project Project { get; set; }
        public User CreatedBy { get; set; }
        public Customer Customer { get; set; }
        public string Goal { get; set; }
        public string Background { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public TimeType TimeType { get; set; }
        public ICollection<TimeReport> TimeReports { get; set; }
    }

    public enum TimeType
    {
        ByTheHour = 0,
        FixedPrice = 1
    }
}
