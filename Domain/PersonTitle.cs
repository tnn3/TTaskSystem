using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class PersonTitle
    {
        public int PersonTitleId { get; set; }
        public string TitleName { get; set; }
        public List<Person> PersonsWithTitle { get; set; }
    }
}
