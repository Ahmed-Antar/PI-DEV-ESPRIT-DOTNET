using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class task
    {
        public string Description { get; set; }
        public int idProject { get; set; }
        public Nullable<System.DateTime> DeadLine { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public string state { get; set; }
        public Nullable<int> id_user { get; set; }
        public virtual project project { get; set; }
        public virtual user user { get; set; }
    }
}
