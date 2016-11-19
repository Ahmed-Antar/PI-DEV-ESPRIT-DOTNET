using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class TaskModel
    {
        public string Description { get; set; }
        public int idProject { get; set; }
        public string projectname { get; set; }
        public Nullable<System.DateTime> DeadLine { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public string state { get; set; }
        public Nullable<int> id_user { get; set; }
        public string username { get; set; }
    }
}