using Domain.Entities;
using Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Rotativa;
using Data.Models;

namespace Web.Controllers
{
    public class projectController : Controller, IDisposable
    {

        ProjectService Pservice = null;
        CategoryService Cservice = null;
        ClientService CLservice = null;
        TeamService Tservice = null;


        public projectController()
        {
            Pservice = new ProjectService();
            Cservice = new CategoryService();
            CLservice = new ClientService();
            Tservice = new TeamService();

        }


        // GET: project
        public ActionResult Index()
        {
            var project = Pservice.GetMany();

            List<project> pr = new List<project>();
            foreach (var item in project)
            {
                pr.Add(
                    new project
                    {
                        IdProject = item.IdProject,
                        Description = item.Description,
                        Name = item.Name,
                        Priority = item.Priority,
                        Type = item.Type,
                        EndDate = item.EndDate,
                        StartDate = item.StartDate,
                        DocumentsUrl = item.DocumentsUrl

                    });

            }


            return View(pr);
        }


        [HttpPost]

        public ActionResult Index(String search)
        {
            var projects = Pservice.GetMany(p => p.Name == search);
            List<project> pr = new List<project>();
            List<category> cl = new List<category>();
            foreach (var item in projects)
            {
                pr.Add(
                    new project
                    {
                        IdProject = item.IdProject,
                        Description = item.Description,
                        Name = item.Name,
                        Priority = item.Priority,
                        Type = item.Type,
                        EndDate = item.EndDate,
                        StartDate = item.StartDate,
                        DocumentsUrl = item.DocumentsUrl

                    });


            }


            return View(pr);

        }



        // GET: project/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            project p = Pservice.GetById(id);




            if (p == null)
            {
                return HttpNotFound();
            }
            return View(p);

        }

        // GET: project/Create
        public ActionResult Create()
        {
            var categories = Cservice.GetMany(); ;
            var clients = CLservice.GetMany();
            var teams = Tservice.GetMany();
            ViewBag.category = new SelectList(categories, "IdCategory", "Name");
            ViewBag.client = new SelectList(clients, "IdClient", "Name");
            ViewBag.team = new SelectList(teams, "id_team", "nom_team");
            return View();
        }

        // POST: project/Create
        [HttpPost]
        public ActionResult Create(project p, HttpPostedFileBase doc)
        {

            if (!ModelState.IsValid || doc == null || doc.ContentLength == 0)
            {
                RedirectToAction("Create");
            }

            //if (doc != null  )
            //{
            //    //p.DocumentsUrl = doc.FileName;
            //    project pr = new project
            //    {
            //        IdProject = p.IdProject,
            //        Description = p.Description,
            //        Name = p.Name,
            //        Priority = p.Priority,
            //        Type = p.Type,
            //        EndDate = p.EndDate,
            //        StartDate = p.StartDate,
            //        DocumentsUrl = p.DocumentsUrl ,
            //        Category_IdCategory = p.Category_IdCategory ,
            //        id_client = p.id_client ,
            //        id_team = p.id_team

            //    };
            //    Pservice.Add(pr);
            //    Pservice.commit();
            //    Pservice.Dispose();
            //    // Sauvgarde de l'image

            //    var path = Path.Combine(Server.MapPath("~/Content/Upload/"), doc.FileName);
            //    doc.SaveAs(path);
            //    return RedirectToAction("Index");

            //}
            //return View();

            if (!ModelState.IsValid)
            {
                return Create();
            }


            p.DocumentsUrl = doc.FileName;
            project pr = new project
            {
                IdProject = p.IdProject,
                Description = p.Description,
                Name = p.Name,
                Priority = p.Priority,
                Type = p.Type,
                EndDate = p.EndDate,
                StartDate = p.StartDate,
                DocumentsUrl = p.DocumentsUrl,
                Category_IdCategory = p.Category_IdCategory,
                id_client = p.id_client,
                id_team = p.id_team

            };
            Pservice.Add(pr);
            Pservice.commit();
            Pservice.Dispose();
            var path = Path.Combine(Server.MapPath("~/Content/Upload/"), doc.FileName);
            doc.SaveAs(path);

            return RedirectToAction("Index");

        }

        // GET: project/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            project p = Pservice.GetById(id);

            if (p == null)
            {
                return HttpNotFound();
            }
            return View(p);
        }

        // POST: project/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, project p)
        {
            if (!ModelState.IsValid)
            {
                return EditDetails();
            }

            if (ModelState.IsValid)
            {

                Pservice.Update(p);
                Pservice.commit();
                Pservice.Dispose();

                return RedirectToAction("Index");
            }
            return View(p);
        }

        // GET: project/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            project p = Pservice.GetById(id);

            if (p == null)
            {
                return HttpNotFound();
            }
            return View(p);
        }

        // POST: project/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, project p)
        {
            Pservice.Delete(p);
            Pservice.commit();
            Pservice.Dispose();

            return RedirectToAction("Index");

        }
        public ActionResult EditDetails()
        {
            var categories = Cservice.GetMany(); ;
            var clients = CLservice.GetMany();
            var teams = Tservice.GetMany();
            ViewBag.category = new SelectList(categories, "IdCategory", "Name");
            ViewBag.client = new SelectList(clients, "IdClient", "Name");
            ViewBag.team = new SelectList(teams, "id_team", "nom_team");
            return View();

        }


        public ActionResult UploadFile(HttpPostedFileBase file)
        {

            if (ModelState.IsValid)
            {
                string path = Server.MapPath("~/Files/" + file.FileName); // location
                file.SaveAs(path);
                @ViewBag.Path = path;




            }
            return View();



        }

        public ActionResult ExportPDF()


        {


            return new ActionAsPdf("index")
            {

                FileName = Server.MapPath("~/Content/Files/products.pdf")
            };
        }
        public ActionResult Chat()
        {
            return View();
        }



        public ActionResult ActiveList()
        {
            var project = Pservice.ActiveProject();

            List<project> pr = new List<project>();
            foreach (var item in project)
            {
                pr.Add(
                    new project
                    {
                        IdProject = item.IdProject,
                        Description = item.Description,
                        Name = item.Name,
                        Priority = item.Priority,
                        Type = item.Type,
                        EndDate = item.EndDate,
                        StartDate = item.StartDate,
                        DocumentsUrl = item.DocumentsUrl

                    });

            }


            return View(pr);
        }

        public ActionResult PassedList()
        {
            var project = Pservice.PassedProject();

            List<project> pr = new List<project>();
            foreach (var item in project)
            {
                pr.Add(
                    new project
                    {
                        IdProject = item.IdProject,
                        Description = item.Description,
                        Name = item.Name,
                        Priority = item.Priority,
                        Type = item.Type,
                        EndDate = item.EndDate,
                        StartDate = item.StartDate,
                        DocumentsUrl = item.DocumentsUrl

                    });

            }


            return View(pr);
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                Pservice.Dispose();
            }
            base.Dispose(disposing);
        }


    }
}
