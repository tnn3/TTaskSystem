using System;
using DAL;
using Domain;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            /*using (var ctx = new AppDbContext())
            {
                ctx.Persons.Add(new Person
                {
                    FirstName = "Keegi",
                    LastName = "Esimene",
                    Email = "asd@asd.asd",
                    IsAdmin = true,
                    CreatedOn = DateTime.Now,
                });
                ctx.SaveChanges();

                foreach (var person in ctx.Persons)
                {
                    Console.WriteLine($"Person: {person.FirstName} - {person.LastName}");
                }
            }*/
        }
    }
}