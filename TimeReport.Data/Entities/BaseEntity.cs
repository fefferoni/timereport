﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TimeReport.Data.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}
