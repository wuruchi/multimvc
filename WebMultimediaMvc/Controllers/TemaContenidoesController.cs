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
    public class TemaContenidoesController : Controller
    {
        private SalesERPDBEntities db = new SalesERPDBEntities();

        // GET: TemaContenidoes
        public ActionResult Index()
        {
            var temaContenido = db.TemaContenido.Include(t => t.Tema);
            return View(temaContenido.ToList());
        }

        // GET: TemaContenidoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TemaContenido temaContenido = db.TemaContenido.Find(id);
            if (temaContenido == null)
            {
                return HttpNotFound();
            }
            return View(temaContenido);
        }

        // GET: TemaContenidoes/Create
        public ActionResult Create()
        {
            ViewBag.IdTema = new SelectList(db.Tema, "IdTema", "Titulo");
            return View();
        }

        // POST: TemaContenidoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdTemaContenido,IdTema,Contenido,ContenidoHtml")] TemaContenido temaContenido)
        {
            if (ModelState.IsValid)
            {
                db.TemaContenido.Add(temaContenido);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdTema = new SelectList(db.Tema, "IdTema", "Titulo", temaContenido.IdTema);
            return View(temaContenido);
        }

        // GET: TemaContenidoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TemaContenido temaContenido = db.TemaContenido.Find(id);
            if (temaContenido == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdTema = new SelectList(db.Tema, "IdTema", "Titulo", temaContenido.IdTema);
            return View(temaContenido);
        }

        // POST: TemaContenidoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdTemaContenido,IdTema,Contenido,ContenidoHtml")] TemaContenido temaContenido)
        {
            if (ModelState.IsValid)
            {
                db.Entry(temaContenido).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdTema = new SelectList(db.Tema, "IdTema", "Titulo", temaContenido.IdTema);
            return View(temaContenido);
        }

        // GET: TemaContenidoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TemaContenido temaContenido = db.TemaContenido.Find(id);
            if (temaContenido == null)
            {
                return HttpNotFound();
            }
            return View(temaContenido);
        }

        // POST: TemaContenidoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TemaContenido temaContenido = db.TemaContenido.Find(id);
            db.TemaContenido.Remove(temaContenido);
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
