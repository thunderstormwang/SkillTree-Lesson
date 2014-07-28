using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Workshop.Models;

namespace Workshop.Areas.Backend.Controllers
{
    public class SystemUserController : Controller
    {
        private WorkshopEntities db = new WorkshopEntities();

        // GET: Backend/SystemUser
        public ActionResult Index()
        {
            return View(db.SystemUsers.ToList());
        }

        // GET: Backend/SystemUser/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SystemUser systemUser = db.SystemUsers.Find(id);
            if (systemUser == null)
            {
                return HttpNotFound();
            }
            return View(systemUser);
        }

        // GET: Backend/SystemUser/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Backend/SystemUser/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SystemUser systemUser)
        {
            if (ModelState.IsValid)
            {
                systemUser.ID = Guid.NewGuid();

                systemUser.CreateDate = DateTime.Now;
                systemUser.UpdateDate = DateTime.Now;

                db.SystemUsers.Add(systemUser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(systemUser);
        }

        // GET: Backend/SystemUser/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SystemUser systemUser = db.SystemUsers.Find(id);
            if (systemUser == null)
            {
                return HttpNotFound();
            }
            return View(systemUser);
        }

        // POST: Backend/SystemUser/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SystemUser systemUser)
        {
            if (db.SystemUsers.Any(x => x.ID != systemUser.ID && x.Account == systemUser.Account))
            {
                ModelState.AddModelError("Account", "登入帳號不可重複");
                return View(systemUser);
            }

            if (ModelState.IsValid)
            {
                var user = db.SystemUsers.FirstOrDefault(x => x.ID == systemUser.ID);

                if (user == null)
                {
                    return View(systemUser);
                }

                user.Name = systemUser.Name;
                user.Account = systemUser.Account;
                user.Password = systemUser.Password;
                user.Email = systemUser.Email;
                user.UpdateDate = DateTime.Now;

                db.Entry(systemUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(systemUser);
        }

        // GET: Backend/SystemUser/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SystemUser systemUser = db.SystemUsers.Find(id);
            if (systemUser == null)
            {
                return HttpNotFound();
            }
            return View(systemUser);
        }

        // POST: Backend/SystemUser/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            SystemUser systemUser = db.SystemUsers.Find(id);
            db.SystemUsers.Remove(systemUser);
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
