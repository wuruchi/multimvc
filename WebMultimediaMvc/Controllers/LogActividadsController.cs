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
    public class LogActividadsController : Controller
    {
        private SalesERPDBEntities db = new SalesERPDBEntities();

        // GET: LogActividads
        public ActionResult Index()
        {
            var logActividad = db.LogActividad.Include(l => l.Seccion).Include(l => l.RolSistema).Include(l => l.RolSistemaCompany).Include(l => l.Tema);
            return View(logActividad.ToList());
        }

        // GET: LogActividads/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LogActividad logActividad = db.LogActividad.Find(id);
            if (logActividad == null)
            {
                return HttpNotFound();
            }
            return View(logActividad);
        }

        // GET: LogActividads/Create
        public ActionResult Create()
        {
            ViewBag.IdSeccion = new SelectList(db.Seccion, "IdSeccion", "Titulo");
            ViewBag.IdRolSistema = new SelectList(db.RolSistema, "IdRolSistema", "Nombre");
            ViewBag.IdRolSisCompany = new SelectList(db.RolSistemaCompany, "IdRolSisCompany", "Nombre");
            ViewBag.IdTema = new SelectList(db.Tema, "IdTema", "Titulo");
            return View();
        }

        // POST: LogActividads/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdLogActividad,IdRolSistema,IdRolSisCompany,NombreModulo,NombrePagina,Accion,FechaCreacion,IdUsuarioCreador,IdSeccion,IdTema")] LogActividad logActividad)
        {
            if (ModelState.IsValid)
            {
                db.LogActividad.Add(logActividad);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdSeccion = new SelectList(db.Seccion, "IdSeccion", "Titulo", logActividad.IdSeccion);
            ViewBag.IdRolSistema = new SelectList(db.RolSistema, "IdRolSistema", "Nombre", logActividad.IdRolSistema);
            ViewBag.IdRolSisCompany = new SelectList(db.RolSistemaCompany, "IdRolSisCompany", "Nombre", logActividad.IdRolSisCompany);
            ViewBag.IdTema = new SelectList(db.Tema, "IdTema", "Titulo", logActividad.IdTema);
            return View(logActividad);
        }

        // GET: LogActividads/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LogActividad logActividad = db.LogActividad.Find(id);
            if (logActividad == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdSeccion = new SelectList(db.Seccion, "IdSeccion", "Titulo", logActividad.IdSeccion);
            ViewBag.IdRolSistema = new SelectList(db.RolSistema, "IdRolSistema", "Nombre", logActividad.IdRolSistema);
            ViewBag.IdRolSisCompany = new SelectList(db.RolSistemaCompany, "IdRolSisCompany", "Nombre", logActividad.IdRolSisCompany);
            ViewBag.IdTema = new SelectList(db.Tema, "IdTema", "Titulo", logActividad.IdTema);
            return View(logActividad);
        }

        // POST: LogActividads/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdLogActividad,IdRolSistema,IdRolSisCompany,NombreModulo,NombrePagina,Accion,FechaCreacion,IdUsuarioCreador,IdSeccion,IdTema")] LogActividad logActividad)
        {
            if (ModelState.IsValid)
            {
                db.Entry(logActividad).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdSeccion = new SelectList(db.Seccion, "IdSeccion", "Titulo", logActividad.IdSeccion);
            ViewBag.IdRolSistema = new SelectList(db.RolSistema, "IdRolSistema", "Nombre", logActividad.IdRolSistema);
            ViewBag.IdRolSisCompany = new SelectList(db.RolSistemaCompany, "IdRolSisCompany", "Nombre", logActividad.IdRolSisCompany);
            ViewBag.IdTema = new SelectList(db.Tema, "IdTema", "Titulo", logActividad.IdTema);
            return View(logActividad);
        }

        // GET: LogActividads/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LogActividad logActividad = db.LogActividad.Find(id);
            if (logActividad == null)
            {
                return HttpNotFound();
            }
            return View(logActividad);
        }

        // POST: LogActividads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LogActividad logActividad = db.LogActividad.Find(id);
            db.LogActividad.Remove(logActividad);
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
