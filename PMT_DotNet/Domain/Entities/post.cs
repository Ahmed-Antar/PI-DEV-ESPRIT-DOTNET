using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class post
    {
        public int IdPost { get; set; }
        public string Content { get; set; }
        public Nullable<System.DateTime> PostDate { get; set; }
        public Nullable<int> Creator_id { get; set; }
        public Nullable<int> topic_IdTopic { get; set; }
        public virtual user user { get; set; }
        public virtual topic topic { get; set; }
    }
}
