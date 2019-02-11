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
        public string Name { get; set; }
        [Required]
        public UserModel CreatedBy { get; set; }
        public string CustomerName { get; set; }
        public string Goal { get; set; }
        public string Background { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public TimeType TimeType { get; set; }
        public ICollection<TimeReportModel> TimeReports { get; set; }
        // TODO! Lägg till automapper och bygg klart några api metoder för taskcontroller. Kör med param includeTimeReports
    }
}
