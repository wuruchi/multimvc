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
    public class TipoSeccionsController : Controller
    {
        private SalesERPDBEntities db = new SalesERPDBEntities();

        // GET: TipoSeccions
        public ActionResult Index()
        {
            return View(db.TipoSeccion.ToList());
        }

        // GET: TipoSeccions/Details/5
        public ActionResult Details(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoSeccion tipoSeccion = db.TipoSeccion.Find(id);
            if (tipoSeccion == null)
            {
                return HttpNotFound();
            }
            return View(tipoSeccion);
        }

        // GET: TipoSeccions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoSeccions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdTipoSeccion,Nombre,Descripcion,Estado,IdUsuarioCreador,IdUsuarioModificador,FechaCreacion,FechaModificacion")] TipoSeccion tipoSeccion)
        {
            if (ModelState.IsValid)
            {
                db.TipoSeccion.Add(tipoSeccion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoSeccion);
        }

        // GET: TipoSeccions/Edit/5
        public ActionResult Edit(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoSeccion tipoSeccion = db.TipoSeccion.Find(id);
            if (tipoSeccion == null)
            {
                return HttpNotFound();
            }
            return View(tipoSeccion);
        }

        // POST: TipoSeccions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdTipoSeccion,Nombre,Descripcion,Estado,IdUsuarioCreador,IdUsuarioModificador,FechaCreacion,FechaModificacion")] TipoSeccion tipoSeccion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoSeccion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoSeccion);
        }

        // GET: TipoSeccions/Delete/5
        public ActionResult Delete(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoSeccion tipoSeccion = db.TipoSeccion.Find(id);
            if (tipoSeccion == null)
            {
                return HttpNotFound();
            }
            return View(tipoSeccion);
        }

        // POST: TipoSeccions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(short id)
        {
            TipoSeccion tipoSeccion = db.TipoSeccion.Find(id);
            db.TipoSeccion.Remove(tipoSeccion);
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
