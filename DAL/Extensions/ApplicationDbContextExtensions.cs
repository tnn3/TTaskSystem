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
                    context.Priorities.Add(new Priority {Name = "Urgent"});
                    context.Priorities.Add(new Priority {Name = "Normal"});
                    context.Priorities.Add(new Priority {Name = "Low"});
                    context.Priorities.Add(new Priority {Name = "Immediate"});
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
                }
            }
        }
    }
}
