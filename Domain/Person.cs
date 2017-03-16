using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Person
    {
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<PersonTitleInProject> Titles { get; set; }
        public string Email { get; set; }
        public bool IsAdmin { get; set; }
        public DateTime CreatedOn { get; set; }
        public List<Task> PersonTasks { get; set; }
    }
}
