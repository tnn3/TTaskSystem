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
                /*if (!context.People.Any())
                {
                    context.People.Add(new Person() {FirstName = "Tõnn", LastName = "Vaher"});
                    context.People.Add(new Person() {FirstName = "Keegi", LastName = "Teine"});
                    context.SaveChanges();
                }*/
            }
        }
    }
}
