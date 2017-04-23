using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain;

namespace DAL.Extensions
{
    public static class ApplicationDbContextExtensions
    {
        public static void EnsureSeedData(this ApplicationDbContext context)
        {
            //check database migration status, is it latest? is it ok to seed?
            if (context.AllMigrationsApplied())
            {
                if (!context.Priorities.Any())
                {
                    context.Priorities.Add(new Priority() {PriorityName = "Urgent"});
                    context.Priorities.Add(new Priority() {PriorityName = "Normal"});
                    context.Priorities.Add(new Priority() {PriorityName = "Low"});
                    context.Priorities.Add(new Priority() {PriorityName = "Immediate"});
                    context.SaveChanges();
                }

                if (!context.Statuses.Any())
                {
                    context.Statuses.Add(new Status { StatusName = "Open" });
                    context.Statuses.Add(new Status { StatusName = "Closed" });
                    context.Statuses.Add(new Status { StatusName = "In progress" });
                    context.SaveChanges();
                }

                if (!context.Projects.Any())
                {
                    context.Projects.Add(new Project
                    {
                        CreatedOn = DateTime.Now,
                        ProjectDescription = "Väga huvitav esimene projekt",
                        ProjectName = "Esimene projekt"
                    });
                    context.SaveChanges();
                }

                if (!context.UserTitles.Any())
                {
                    context.UserTitles.Add(new UserTitle { TitleName = "Ülemus" });
                    context.UserTitles.Add(new UserTitle { TitleName = "Noorliige" });
                    context.UserTitles.Add(new UserTitle { TitleName = "Vanemliige" });
                }
            }
        }
    }
}
