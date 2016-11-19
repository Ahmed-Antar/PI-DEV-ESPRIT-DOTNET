using Data.Models;
using Domain.Entities;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class categoryController : Controller, IDisposable
    {



        CategoryService Cservice = new CategoryService();



        // GET: category
        public ActionResult Index()
        {
            var categories = Cservice.GetMany();
            return View(categories);

        }

        // GET: category/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: category/Create
        [HttpPost]
        public ActionResult Create(category c)
        {

            Cservice.Add(c);
            Cservice.commit();
            Cservice.Dispose();

            return RedirectToAction("Index");

        }



        // GET: category/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            category p = Cservice.GetById(id);

            if (p == null)
            {
                return HttpNotFound();
            }
            return View(p);
        }

        // POST: category/Edit/5
        [HttpPost]
        public ActionResult Edit(category c)
        {


            if (ModelState.IsValid)
            {
                Cservice.Update(c);
                Cservice.commit();
                Cservice.Dispose();

                return RedirectToAction("Index");
            }
            return View(c);
        }

        // GET: category/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            category c = Cservice.GetById(id);

            if (c == null)
            {
                return HttpNotFound();
            }
            return View(c);
        }

        // POST: category/Delete/5
        [HttpPost]
        public ActionResult Delete(category c)
        {


            Cservice.Delete(c);
            Cservice.commit();
            Cservice.Dispose();

            return RedirectToAction("Index");

        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                Cservice.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
