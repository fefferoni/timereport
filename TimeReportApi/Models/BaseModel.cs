using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeReport.Web.Api.Models
{
    public class BaseModel
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}
