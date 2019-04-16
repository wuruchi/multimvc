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
    public class TemaEdicionsController : Controller
    {
        private SalesERPDBEntities db = new SalesERPDBEntities();

        // GET: TemaEdicions
        public ActionResult Index()
        {
            var temaEdicion = db.TemaEdicion.Include(t => t.Tema);
            return View(temaEdicion.ToList());
        }

        // GET: TemaEdicions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TemaEdicion temaEdicion = db.TemaEdicion.Find(id);
            if (temaEdicion == null)
            {
                return HttpNotFound();
            }
            return View(temaEdicion);
        }

        // GET: TemaEdicions/Create
        public ActionResult Create()
        {
            ViewBag.IdTema = new SelectList(db.Tema, "IdTema", "Titulo");
            return View();
        }

        // POST: TemaEdicions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdTemaEdicion,IdTema,Estado,Titulo,Contenido,ContenidoHTML,IdUsuarioModificador,FechaModificacion,Tag1,Tag2,Tag3,Tag4,Tag5,Tags,ResumenEdicion")] TemaEdicion temaEdicion)
        {
            if (ModelState.IsValid)
            {
                db.TemaEdicion.Add(temaEdicion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdTema = new SelectList(db.Tema, "IdTema", "Titulo", temaEdicion.IdTema);
            return View(temaEdicion);
        }

        // GET: TemaEdicions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TemaEdicion temaEdicion = db.TemaEdicion.Find(id);
            if (temaEdicion == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdTema = new SelectList(db.Tema, "IdTema", "Titulo", temaEdicion.IdTema);
            return View(temaEdicion);
        }

        // POST: TemaEdicions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdTemaEdicion,IdTema,Estado,Titulo,Contenido,ContenidoHTML,IdUsuarioModificador,FechaModificacion,Tag1,Tag2,Tag3,Tag4,Tag5,Tags,ResumenEdicion")] TemaEdicion temaEdicion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(temaEdicion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdTema = new SelectList(db.Tema, "IdTema", "Titulo", temaEdicion.IdTema);
            return View(temaEdicion);
        }

        // GET: TemaEdicions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TemaEdicion temaEdicion = db.TemaEdicion.Find(id);
            if (temaEdicion == null)
            {
                return HttpNotFound();
            }
            return View(temaEdicion);
        }

        // POST: TemaEdicions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TemaEdicion temaEdicion = db.TemaEdicion.Find(id);
            db.TemaEdicion.Remove(temaEdicion);
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
