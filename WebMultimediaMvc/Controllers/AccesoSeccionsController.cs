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
    public class AccesoSeccionsController : Controller
    {
        private SalesERPDBEntities db = new SalesERPDBEntities();

        // GET: AccesoSeccions
        public ActionResult Index()
        {
            var accesoSeccion = db.AccesoSeccion.Include(a => a.Seccion).Include(a => a.RolSistema);
            return View(accesoSeccion.ToList());
        }

        // GET: AccesoSeccions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccesoSeccion accesoSeccion = db.AccesoSeccion.Find(id);
            if (accesoSeccion == null)
            {
                return HttpNotFound();
            }
            return View(accesoSeccion);
        }

        // GET: AccesoSeccions/Create
        public ActionResult Create()
        {
            ViewBag.IdSeccion = new SelectList(db.Seccion, "IdSeccion", "Titulo");
            ViewBag.IdRolSistema = new SelectList(db.RolSistema, "IdRolSistema", "Nombre");
            return View();
        }

        // POST: AccesoSeccions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdAccesoSeccion,IdSeccion,Estado,FechaCreacion,IdUsuarioCreador,FechaModificacion,UsuarioModificador,Acceso,Crear,Marcado,Edicion,Desactivado,IdRolSistema")] AccesoSeccion accesoSeccion)
        {
            if (ModelState.IsValid)
            {
                db.AccesoSeccion.Add(accesoSeccion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdSeccion = new SelectList(db.Seccion, "IdSeccion", "Titulo", accesoSeccion.IdSeccion);
            ViewBag.IdRolSistema = new SelectList(db.RolSistema, "IdRolSistema", "Nombre", accesoSeccion.IdRolSistema);
            return View(accesoSeccion);
        }

        // GET: AccesoSeccions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccesoSeccion accesoSeccion = db.AccesoSeccion.Find(id);
            if (accesoSeccion == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdSeccion = new SelectList(db.Seccion, "IdSeccion", "Titulo", accesoSeccion.IdSeccion);
            ViewBag.IdRolSistema = new SelectList(db.RolSistema, "IdRolSistema", "Nombre", accesoSeccion.IdRolSistema);
            return View(accesoSeccion);
        }

        // POST: AccesoSeccions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdAccesoSeccion,IdSeccion,Estado,FechaCreacion,IdUsuarioCreador,FechaModificacion,UsuarioModificador,Acceso,Crear,Marcado,Edicion,Desactivado,IdRolSistema")] AccesoSeccion accesoSeccion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(accesoSeccion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdSeccion = new SelectList(db.Seccion, "IdSeccion", "Titulo", accesoSeccion.IdSeccion);
            ViewBag.IdRolSistema = new SelectList(db.RolSistema, "IdRolSistema", "Nombre", accesoSeccion.IdRolSistema);
            return View(accesoSeccion);
        }

        // GET: AccesoSeccions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccesoSeccion accesoSeccion = db.AccesoSeccion.Find(id);
            if (accesoSeccion == null)
            {
                return HttpNotFound();
            }
            return View(accesoSeccion);
        }

        // POST: AccesoSeccions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AccesoSeccion accesoSeccion = db.AccesoSeccion.Find(id);
            db.AccesoSeccion.Remove(accesoSeccion);
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
