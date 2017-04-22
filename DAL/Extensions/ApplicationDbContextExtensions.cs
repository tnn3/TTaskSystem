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
            }
        }
    }
}
