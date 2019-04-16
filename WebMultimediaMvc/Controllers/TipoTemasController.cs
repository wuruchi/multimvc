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
    public class TipoTemasController : Controller
    {
        private SalesERPDBEntities db = new SalesERPDBEntities();

        // GET: TipoTemas
        public ActionResult Index()
        {
            return View(db.TipoTema.ToList());
        }

        // GET: TipoTemas/Details/5
        public ActionResult Details(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoTema tipoTema = db.TipoTema.Find(id);
            if (tipoTema == null)
            {
                return HttpNotFound();
            }
            return View(tipoTema);
        }

        // GET: TipoTemas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoTemas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdTipoTema,Descripcion,Estado,IdUsuarioCreador,FechaCreacion")] TipoTema tipoTema)
        {
            if (ModelState.IsValid)
            {
                db.TipoTema.Add(tipoTema);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoTema);
        }

        // GET: TipoTemas/Edit/5
        public ActionResult Edit(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoTema tipoTema = db.TipoTema.Find(id);
            if (tipoTema == null)
            {
                return HttpNotFound();
            }
            return View(tipoTema);
        }

        // POST: TipoTemas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdTipoTema,Descripcion,Estado,IdUsuarioCreador,FechaCreacion")] TipoTema tipoTema)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoTema).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoTema);
        }

        // GET: TipoTemas/Delete/5
        public ActionResult Delete(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoTema tipoTema = db.TipoTema.Find(id);
            if (tipoTema == null)
            {
                return HttpNotFound();
            }
            return View(tipoTema);
        }

        // POST: TipoTemas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(short id)
        {
            TipoTema tipoTema = db.TipoTema.Find(id);
            db.TipoTema.Remove(tipoTema);
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
