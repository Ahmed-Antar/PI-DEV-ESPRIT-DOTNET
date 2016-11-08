using Data.Models;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console
{
    class Program
    {
        static void Main(string[] args)
        {
            CategoryService Cservice = new CategoryService();
            List<category> categories = new List<category>();

            category cat1 = new category { IdCategory=1, Name="ASP.NET" };
            categories.Add(cat1);
            Cservice.Add(cat1);
            Cservice.commit();
            Cservice.Dispose();
        }
    }
}
