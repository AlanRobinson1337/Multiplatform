using Events.Data;
using Events.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Events.Web.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class AdminController : BaseController
    {
        private ApplicationDbContext db = new ApplicationDbContext();


        // GET: Admin
        [Authorize(Roles = "Administrator")]
        public ActionResult Index()
        {
            return View();
        }

        // GET: Admin/Details/5
        public ActionResult Details(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // GET: Admin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Delete/5
        public ActionResult Delete(int? id)
        {
            Comment comment = db.Comments.Find(id);
            return View(comment);
        }

        // POST: Admin/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
