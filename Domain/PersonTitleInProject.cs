using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class PersonTitleInProject
    {
        public int PersonTitleInProjectId { get; set; }

        public int ProjectId { get; set; }
        public Project Project { get; set; }

        public int TitleId { get; set; }
        public PersonTitle Title { get; set; }
    }
}
