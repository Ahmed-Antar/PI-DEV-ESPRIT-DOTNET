using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class teammember
    {
        public int idTeamMember { get; set; }
        public string email { get; set; }
        public int idTeam { get; set; }
        public string name { get; set; }
        public string review { get; set; }
    }
}
