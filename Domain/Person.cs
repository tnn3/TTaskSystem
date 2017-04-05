using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Domain.Identity;

namespace Domain
{
    public class Person
    {
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<PersonTitleInProject> Titles { get; set; }
        public DateTime CreatedOn { get; set; }
        [InverseProperty(nameof(ProjectTask.AssignedTo))]
        public List<ProjectTask> ProjectTasks { get; set; }
    }
}
