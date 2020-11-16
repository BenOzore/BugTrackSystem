﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BugTrackSystem.Models
{
    public static class ProjectHelper
    {
        static ApplicationDbContext db = new ApplicationDbContext();

        public static bool CreateProject(Project project)
        {
            if(db.Projects.Any(p => p.Title == project.Title))
            {
                return false;
            }
            db.Projects.Add(project);
            db.SaveChanges();
            return true;
        }

        public static bool DeleteProject(int id)
        {
            if (db.Projects.Any(p => p.Id == id))
            {
                var proj = db.Projects.Find(id);                             
                db.Projects.Remove(proj);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public static bool EditProject(int? id, string title)
        {
            if (db.Projects.Any(p => p.Id == id) && !db.Projects.Any(p => p.Title == title))
            {
                var project = db.Projects.Find(id);
                project.Title = title;                
                return true;
            }
            return false;
        }

        public static List<Project> GetAllProjectsForUser(string UserId)
        {
            return db.Users.Find(UserId).Projects.ToList();
        }

        public static List<Project> GetProjectDetailByProjectId(int? PId)
        {
            return db.Projects.Where(p => p.Id == PId).ToList();           
        }

        /*For archived projects, dont show the in view if !IsArchived*/

        public static bool AssignUserToProject(string UserId, int ProjId)
        {
            var prj = db.Projects.Find(ProjId);
            var user = db.Users.Find(UserId);
            if (!prj.ApplicationUsers.Contains(user))
            {
                prj.ApplicationUsers.Add(user);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public static bool RemoveUserFromProject(string UserId, int ProjId)
        {
            var prj = db.Projects.Find(ProjId);
            var user = db.Users.Find(UserId);
            if (prj.ApplicationUsers.Contains(user))
            {
                prj.ApplicationUsers.Remove(user);
                db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}