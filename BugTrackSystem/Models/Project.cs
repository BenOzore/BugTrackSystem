﻿using System.Collections.Generic;

namespace BugTrackSystem.Models
{
    public class Project : SystemItem
    {
        public virtual ICollection<Ticket> Tickets { get; set; }
        public virtual ICollection<ApplicationUser> AssignedUsers { get; set; }

        public Project()
        {
            Tickets = new HashSet<Ticket>();
            AssignedUsers = new HashSet<ApplicationUser>();
        }
    }
}