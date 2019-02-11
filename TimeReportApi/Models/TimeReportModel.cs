using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeReport.Web.Api.Models
{
    public class TimeReportModel : BaseModel
    {
        public DateTime Date { get; set; }
        public UserModel User { get; set; }
        public double TimeWorkedInHours { get; set; }
    }
}
