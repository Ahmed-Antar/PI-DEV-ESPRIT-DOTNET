using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class category
    {
        public category()
        {
            this.projects = new List<project>();
        }

        public int IdCategory { get; set; }
        public string Name { get; set; }
        public virtual ICollection<project> projects { get; set; }
    }
}
