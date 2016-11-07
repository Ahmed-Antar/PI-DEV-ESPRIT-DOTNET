using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class project
    {
        public project()
        {
            this.tasks = new List<task>();
        }

        public int IdProject { get; set; }
        public string Description { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public string Name { get; set; }
        public string Priority { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public string Type { get; set; }
        public Nullable<int> Category_IdCategory { get; set; }
        public Nullable<int> id_user { get; set; }
        public Nullable<int> id_team { get; set; }
        public Nullable<int> id_client { get; set; }
        public virtual category category { get; set; }
        public virtual client client { get; set; }
        public virtual ICollection<task> tasks { get; set; }
        public virtual user user { get; set; }
        public virtual team team { get; set; }
    }
}
