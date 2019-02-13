using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TimeReport.Web.Api.Models
{
    public class UserModel : BaseModel
    {
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string LastName { get; set; }
        [Range(0, 168)]
        public int WorkHoursPerWeek { get; set; }
        [EmailAddress]
        public string Email { get; set; }
    }
}
