﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BugTrackSystem.Models
{
    public class Admin : ApplicationUser
    {
        public virtual ICollection<Project> Projects { get; set; }
    }
}