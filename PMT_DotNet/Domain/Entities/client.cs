using Domain.Entities;
using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class client
    {
        public client()
        {
            this.projects = new List<project>();
        }

        public int IdClient { get; set; }
        public string City { get; set; }
        public string Contact { get; set; }
        public string Country { get; set; }
        public Nullable<System.DateTime> CreationDate { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public Nullable<int> Number { get; set; }
        public string website { get; set; }
        public virtual ICollection<project> projects { get; set; }
    }
}
