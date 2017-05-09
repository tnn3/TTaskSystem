using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.EntityFrameworkCore;
using Domain;

namespace DAL.EntityFrameworkCore.Extensions
{

    // extension methods for DataContext
    public static class DataContextExtensions
    {
        public static void EnsureSeedData(this ApplicationDbContext context)
        {
            // AllMigrationsApplied is custom extension method - look into DbContextExtensions
            if (context.AllMigrationsApplied())
            {
                if (!context.Priorities.Any())
                {
                    context.Priorities.Add(new Priority { Name = "Urgent" });
                    context.Priorities.Add(new Priority { Name = "Normal" });
                    context.Priorities.Add(new Priority { Name = "Low" });
                    context.Priorities.Add(new Priority { Name = "Immediate" });
                    context.SaveChanges();
                }

                if (!context.Statuses.Any())
                {
                    context.Statuses.Add(new Status { Name = "Open" });
                    context.Statuses.Add(new Status { Name = "Closed" });
                    context.Statuses.Add(new Status { Name = "In progress" });
                    context.SaveChanges();
                }

                if (!context.Projects.Any())
                {
                    context.Projects.Add(new Project
                    {
                        CreatedOn = DateTime.Now,
                        Description = "Väga huvitav esimene projekt",
                        Name = "Esimene projekt"
                    });
                    context.SaveChanges();
                }

                if (!context.UserTitles.Any())
                {
                    context.UserTitles.Add(new UserTitle { Title = "Ülemus" });
                    context.UserTitles.Add(new UserTitle { Title = "Noorliige" });
                    context.UserTitles.Add(new UserTitle { Title = "Vanemliige" });
                    context.SaveChanges();
                }

                if (!context.StatusInProjects.Any())
                {
                    context.StatusInProjects.Add(new StatusInProject
                    {
                        Project = context.Projects.First(),
                        Status = context.Statuses.First()
                    });
                    context.SaveChanges();
                }

                if (!context.ProjectTasks.Any())
                {
                    context.ProjectTasks.Add(new ProjectTask
                    {
                        Created = DateTime.Now,
                        Description = "Mingisugune suits ja imelik lõhn on üleval",
                        Name = "Midagi on katki",
                        Priority = context.Priorities.First(p => p.Name == "Urgent"),
                        Project = context.Projects.First(),
                        Status = context.StatusInProjects.First(),
                        Author = context.ApplicationUsers.First()
                    });
                    context.SaveChanges();
                }
            }
        }
    }
}
