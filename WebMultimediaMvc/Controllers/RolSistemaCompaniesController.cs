using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebMultimediaMvc.DAL;

namespace WebMultimediaMvc.Controllers
{
    public class RolSistemaCompaniesController : Controller
    {
        private SalesERPDBEntities db = new SalesERPDBEntities();

        // GET: RolSistemaCompanies
        public ActionResult Index()
        {
            var rolSistemaCompany = db.RolSistemaCompany.Include(r => r.RolSistema);
            return View(rolSistemaCompany.ToList());
        }

        // GET: RolSistemaCompanies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RolSistemaCompany rolSistemaCompany = db.RolSistemaCompany.Find(id);
            if (rolSistemaCompany == null)
            {
                return HttpNotFound();
            }
            return View(rolSistemaCompany);
        }

        // GET: RolSistemaCompanies/Create
        public ActionResult Create()
        {
            ViewBag.IdRolSistema = new SelectList(db.RolSistema, "IdRolSistema", "Nombre");
            return View();
        }

        // POST: RolSistemaCompanies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdRolSisCompany,IdRolSistema,IdCompany,Nombre,Descripcion,Simbolo,Email,Password,ScoreTotal,Estado,FechaCreacion,FechaModificacion,IdUsuarioCreador,IdUsuarioModificador")] RolSistemaCompany rolSistemaCompany)
        {
            if (ModelState.IsValid)
            {
                db.RolSistemaCompany.Add(rolSistemaCompany);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdRolSistema = new SelectList(db.RolSistema, "IdRolSistema", "Nombre", rolSistemaCompany.IdRolSistema);
            return View(rolSistemaCompany);
        }

        // GET: RolSistemaCompanies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RolSistemaCompany rolSistemaCompany = db.RolSistemaCompany.Find(id);
            if (rolSistemaCompany == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdRolSistema = new SelectList(db.RolSistema, "IdRolSistema", "Nombre", rolSistemaCompany.IdRolSistema);
            return View(rolSistemaCompany);
        }

        // POST: RolSistemaCompanies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdRolSisCompany,IdRolSistema,IdCompany,Nombre,Descripcion,Simbolo,Email,Password,ScoreTotal,Estado,FechaCreacion,FechaModificacion,IdUsuarioCreador,IdUsuarioModificador")] RolSistemaCompany rolSistemaCompany)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rolSistemaCompany).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdRolSistema = new SelectList(db.RolSistema, "IdRolSistema", "Nombre", rolSistemaCompany.IdRolSistema);
            return View(rolSistemaCompany);
        }

        // GET: RolSistemaCompanies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RolSistemaCompany rolSistemaCompany = db.RolSistemaCompany.Find(id);
            if (rolSistemaCompany == null)
            {
                return HttpNotFound();
            }
            return View(rolSistemaCompany);
        }

        // POST: RolSistemaCompanies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RolSistemaCompany rolSistemaCompany = db.RolSistemaCompany.Find(id);
            db.RolSistemaCompany.Remove(rolSistemaCompany);
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
