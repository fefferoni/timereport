using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TimeReport.Data.Entities;

namespace TimeReport.Web.Api.Models
{
    public class TaskModel : BaseModel
    {

        [Required]
        [StringLength(500, MinimumLength = 3)]
        public string Name { get; set; }
        public string ProjectName { get; set; }
        public int ProjectId { get; set; }
        public string CustomerName { get; set; }
        public int CustomerId { get; set; }
        public string Goal { get; set; }
        public string Background { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public TimeType TimeType { get; set; }
        public ICollection<TimeReportModel> TimeReports { get; set; }
    }
}
