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
    public class ComentarioRespuestasController : Controller
    {
        private SalesERPDBEntities db = new SalesERPDBEntities();

        // GET: ComentarioRespuestas
        public ActionResult Index()
        {
            var comentarioRespuesta = db.ComentarioRespuesta.Include(c => c.Respuesta);
            return View(comentarioRespuesta.ToList());
        }

        // GET: ComentarioRespuestas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ComentarioRespuesta comentarioRespuesta = db.ComentarioRespuesta.Find(id);
            if (comentarioRespuesta == null)
            {
                return HttpNotFound();
            }
            return View(comentarioRespuesta);
        }

        // GET: ComentarioRespuestas/Create
        public ActionResult Create()
        {
            ViewBag.IdRespuesta = new SelectList(db.Respuesta, "IdRespuesta", "Titulo");
            return View();
        }

        // POST: ComentarioRespuestas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdComentarioRespuesta,IdRespuesta,Estado,ScoreObtenido,ComentarioTexto,ComentarioTextoHtml,CantidadEdicion,IdUsuarioCreador,FechaCreacion,NombreUsuarioCreador,IdUsuarioModificador,FechaModificacion,NombreUsuarioModificador")] ComentarioRespuesta comentarioRespuesta)
        {
            if (ModelState.IsValid)
            {
                db.ComentarioRespuesta.Add(comentarioRespuesta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdRespuesta = new SelectList(db.Respuesta, "IdRespuesta", "Titulo", comentarioRespuesta.IdRespuesta);
            return View(comentarioRespuesta);
        }

        // GET: ComentarioRespuestas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ComentarioRespuesta comentarioRespuesta = db.ComentarioRespuesta.Find(id);
            if (comentarioRespuesta == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdRespuesta = new SelectList(db.Respuesta, "IdRespuesta", "Titulo", comentarioRespuesta.IdRespuesta);
            return View(comentarioRespuesta);
        }

        // POST: ComentarioRespuestas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdComentarioRespuesta,IdRespuesta,Estado,ScoreObtenido,ComentarioTexto,ComentarioTextoHtml,CantidadEdicion,IdUsuarioCreador,FechaCreacion,NombreUsuarioCreador,IdUsuarioModificador,FechaModificacion,NombreUsuarioModificador")] ComentarioRespuesta comentarioRespuesta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(comentarioRespuesta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdRespuesta = new SelectList(db.Respuesta, "IdRespuesta", "Titulo", comentarioRespuesta.IdRespuesta);
            return View(comentarioRespuesta);
        }

        // GET: ComentarioRespuestas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ComentarioRespuesta comentarioRespuesta = db.ComentarioRespuesta.Find(id);
            if (comentarioRespuesta == null)
            {
                return HttpNotFound();
            }
            return View(comentarioRespuesta);
        }

        // POST: ComentarioRespuestas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ComentarioRespuesta comentarioRespuesta = db.ComentarioRespuesta.Find(id);
            db.ComentarioRespuesta.Remove(comentarioRespuesta);
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
