using Data.Models;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Helper
{
    public static class ExtensionProjectName
    {
        public static IEnumerable<SelectListItem> dropDownList(this IEnumerable<project> projectName)
        {
            return projectName.OrderBy(a => a.IdProject).Select(a => new SelectListItem
            {
                Text = a.Name,
                Value = a.IdProject.ToString()

            });
        }
    }
}