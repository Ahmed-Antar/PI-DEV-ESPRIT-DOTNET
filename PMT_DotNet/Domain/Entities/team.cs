using Domain.Entities;
using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class team
    {
        public team()
        {
            this.projects = new List<project>();
        }

        public int id_team { get; set; }
        public string nom_team { get; set; }
        public int score { get; set; }
        public string teamStatus { get; set; }
        public virtual ICollection<project> projects { get; set; }
    }
}
