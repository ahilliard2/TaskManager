using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TaskManager.DAL;
using TaskManager.Models;

namespace TaskManager.Controllers
{
    public class TaskController : Controller
    {
        private TaskManagerContext db = new TaskManagerContext();

        // GET: Task
        public ActionResult Index(int? id)
        {
            return View(db.Task.Where(t => t.UserId == id).OrderBy(d=> d.LastUpdated).ToList());
        }

        // GET: Task/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Task task = db.Task.Find(id);
            if (task == null)
            {
                return HttpNotFound();
            }
            return View(task);
        }

        // GET: Task/Create
        public ActionResult Create(int? userId)
        {
            return View(userId);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TaskDescription")] Task task)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    task.UserId = Convert.ToInt32(System.Web.HttpContext.Current.Session["userId"]);
                    task.LastUpdated = DateTime.Now;
                    db.Task.Add(task);
                    db.SaveChanges();
                    return RedirectToAction("Index", new { @id = task.UserId });
                }
            }
            catch (DataException d)
            {                
                ModelState.AddModelError(d.InnerException + "", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }    

            return View(task);
        }

        // GET: Task/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Task task = db.Task.Find(id);
            if (task == null)
            {
                return HttpNotFound();
            }
            return View(task);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TaskId,UserId,TaskDescription,LastUpdated,Complete")] Task task)
        {
            if (ModelState.IsValid)
            {
                db.Entry(task).State = EntityState.Modified;
                task.LastUpdated = DateTime.Now;
                db.SaveChanges();
                ViewBag.successMessage = "Success";
                return RedirectToAction("Edit", "Task", new { @id = task.TaskId });            
            }

            return View(task);
        }

        // GET: Task/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Task task = db.Task.Find(id);
            if (task == null)
            {
                return HttpNotFound();
            }
            return View(task);
        }

        // POST: Task/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Task task = db.Task.Find(id);
            db.Task.Remove(task);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
