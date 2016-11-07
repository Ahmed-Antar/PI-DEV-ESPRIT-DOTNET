using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class user
    {
        public user()
        {
            this.posts = new List<post>();
            this.projects = new List<project>();
            this.tasks = new List<task>();
            this.topics = new List<topic>();
        }

        public int id { get; set; }
        public string email { get; set; }
        public string login { get; set; }
        public string name { get; set; }
        public string password { get; set; }
        public string role { get; set; }
        public int state { get; set; }
        public Nullable<System.DateTime> birthDay { get; set; }
        public string country { get; set; }
        public virtual ICollection<post> posts { get; set; }
        public virtual ICollection<project> projects { get; set; }
        public virtual ICollection<task> tasks { get; set; }
        public virtual ICollection<topic> topics { get; set; }
    }
}
