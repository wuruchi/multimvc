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
    public class ComentarioTemasController : Controller
    {
        private SalesERPDBEntities db = new SalesERPDBEntities();

        // GET: ComentarioTemas
        public ActionResult Index()
        {
            var comentarioTema = db.ComentarioTema.Include(c => c.Tema);
            return View(comentarioTema.ToList());
        }

        // GET: ComentarioTemas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ComentarioTema comentarioTema = db.ComentarioTema.Find(id);
            if (comentarioTema == null)
            {
                return HttpNotFound();
            }
            return View(comentarioTema);
        }

        // GET: ComentarioTemas/Create
        public ActionResult Create()
        {
            ViewBag.IdTema = new SelectList(db.Tema, "IdTema", "Titulo");
            return View();
        }

        // POST: ComentarioTemas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdComentario,IdTema,ComentarioTexto,ComentarioTextoHtml,ScoreObtenido,Estado,IdUsuarioCreador,FechaCreacion,NombreUsuarioCreador,IdUsuarioModificador,FechaModificacion,NombreUsuarioModificador,CantidadEdicion")] ComentarioTema comentarioTema)
        {
            if (ModelState.IsValid)
            {
                db.ComentarioTema.Add(comentarioTema);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdTema = new SelectList(db.Tema, "IdTema", "Titulo", comentarioTema.IdTema);
            return View(comentarioTema);
        }

        // GET: ComentarioTemas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ComentarioTema comentarioTema = db.ComentarioTema.Find(id);
            if (comentarioTema == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdTema = new SelectList(db.Tema, "IdTema", "Titulo", comentarioTema.IdTema);
            return View(comentarioTema);
        }

        // POST: ComentarioTemas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdComentario,IdTema,ComentarioTexto,ComentarioTextoHtml,ScoreObtenido,Estado,IdUsuarioCreador,FechaCreacion,NombreUsuarioCreador,IdUsuarioModificador,FechaModificacion,NombreUsuarioModificador,CantidadEdicion")] ComentarioTema comentarioTema)
        {
            if (ModelState.IsValid)
            {
                db.Entry(comentarioTema).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdTema = new SelectList(db.Tema, "IdTema", "Titulo", comentarioTema.IdTema);
            return View(comentarioTema);
        }

        // GET: ComentarioTemas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ComentarioTema comentarioTema = db.ComentarioTema.Find(id);
            if (comentarioTema == null)
            {
                return HttpNotFound();
            }
            return View(comentarioTema);
        }

        // POST: ComentarioTemas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ComentarioTema comentarioTema = db.ComentarioTema.Find(id);
            db.ComentarioTema.Remove(comentarioTema);
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
