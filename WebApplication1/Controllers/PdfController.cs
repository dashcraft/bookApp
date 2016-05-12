using Microsoft.ApplicationInsights.Extensibility.Implementation;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Authorize]
    public class PdfController : Controller
    {
        private pdfentryDBEntities db = new pdfentryDBEntities();

        // GET: Pdf
        public ActionResult Index()
        {
            return View(db.pdf_tbl.Where(d=>d.userName== System.Web.HttpContext.Current.User.Identity.Name).ToList());
            
        }

        // GET: Pdf/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pdf_tbl pdf_tbl = db.pdf_tbl.Find(id);
            if (pdf_tbl == null)
            {
                return HttpNotFound();
            }
            return View(pdf_tbl);
        }

        // GET: Pdf/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pdf/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "bookId,authFirstName,authLastName,bookTitle,bookPrologue,userName")] pdf_tbl pdf_tbl)
        {
            
            if (ModelState.IsValid)
            {
                pdf_tbl.userName = System.Web.HttpContext.Current.User.Identity.Name;
                db.pdf_tbl.Add(pdf_tbl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pdf_tbl);
        }

        // GET: Pdf/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pdf_tbl pdf_tbl = db.pdf_tbl.Find(id);
            if (pdf_tbl == null)
            {
                return HttpNotFound();
            }
            return View(pdf_tbl);
        }

        // POST: Pdf/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "bookId,authFirstName,authLastName,bookTitle,bookPrologue")] pdf_tbl pdf_tbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pdf_tbl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pdf_tbl);
        }

        // GET: Pdf/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pdf_tbl pdf_tbl = db.pdf_tbl.Find(id);
            if (pdf_tbl == null)
            {
                return HttpNotFound();
            }
            return View(pdf_tbl);
        }

        // POST: Pdf/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            pdf_tbl pdf_tbl = db.pdf_tbl.Find(id);
            db.pdf_tbl.Remove(pdf_tbl);
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
