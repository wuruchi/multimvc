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
    public class RolSistemasController : Controller
    {
        private SalesERPDBEntities db = new SalesERPDBEntities();

        // GET: RolSistemas
        public ActionResult Index()
        {
            return View(db.RolSistema.ToList());
        }

        // GET: RolSistemas/Details/5
        public ActionResult Details(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RolSistema rolSistema = db.RolSistema.Find(id);
            if (rolSistema == null)
            {
                return HttpNotFound();
            }
            return View(rolSistema);
        }

        // GET: RolSistemas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RolSistemas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdRolSistema,Nombre,Descripcion,EsBase,Estado,FechaCreacion,FechaModificacion,IdUsuarioCreador,IdUsuarioModificador")] RolSistema rolSistema)
        {
            if (ModelState.IsValid)
            {
                db.RolSistema.Add(rolSistema);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rolSistema);
        }

        // GET: RolSistemas/Edit/5
        public ActionResult Edit(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RolSistema rolSistema = db.RolSistema.Find(id);
            if (rolSistema == null)
            {
                return HttpNotFound();
            }
            return View(rolSistema);
        }

        // POST: RolSistemas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdRolSistema,Nombre,Descripcion,EsBase,Estado,FechaCreacion,FechaModificacion,IdUsuarioCreador,IdUsuarioModificador")] RolSistema rolSistema)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rolSistema).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rolSistema);
        }

        // GET: RolSistemas/Delete/5
        public ActionResult Delete(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RolSistema rolSistema = db.RolSistema.Find(id);
            if (rolSistema == null)
            {
                return HttpNotFound();
            }
            return View(rolSistema);
        }

        // POST: RolSistemas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(short id)
        {
            RolSistema rolSistema = db.RolSistema.Find(id);
            db.RolSistema.Remove(rolSistema);
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
