using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class topic
    {
        public topic()
        {
            this.posts = new List<post>();
        }

        public int IdTopic { get; set; }
        public Nullable<System.DateTime> CreationDate { get; set; }
        public int LastUser { get; set; }
        public Nullable<System.DateTime> ReplyDate { get; set; }
        public int Solved { get; set; }
        public string Title { get; set; }
        public int Views { get; set; }
        public Nullable<int> Creator_id { get; set; }
        public virtual ICollection<post> posts { get; set; }
        public virtual user user { get; set; }
    }
}
