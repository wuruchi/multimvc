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
    public class RespuestaContenidoesController : Controller
    {
        private SalesERPDBEntities db = new SalesERPDBEntities();

        // GET: RespuestaContenidoes
        public ActionResult Index()
        {
            var respuestaContenido = db.RespuestaContenido.Include(r => r.Respuesta);
            return View(respuestaContenido.ToList());
        }

        // GET: RespuestaContenidoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RespuestaContenido respuestaContenido = db.RespuestaContenido.Find(id);
            if (respuestaContenido == null)
            {
                return HttpNotFound();
            }
            return View(respuestaContenido);
        }

        // GET: RespuestaContenidoes/Create
        public ActionResult Create()
        {
            ViewBag.IdRespuesta = new SelectList(db.Respuesta, "IdRespuesta", "Titulo");
            return View();
        }

        // POST: RespuestaContenidoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdRespuestaContenido,IdRespuesta,Contenido,ContenidHtml")] RespuestaContenido respuestaContenido)
        {
            if (ModelState.IsValid)
            {
                db.RespuestaContenido.Add(respuestaContenido);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdRespuesta = new SelectList(db.Respuesta, "IdRespuesta", "Titulo", respuestaContenido.IdRespuesta);
            return View(respuestaContenido);
        }

        // GET: RespuestaContenidoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RespuestaContenido respuestaContenido = db.RespuestaContenido.Find(id);
            if (respuestaContenido == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdRespuesta = new SelectList(db.Respuesta, "IdRespuesta", "Titulo", respuestaContenido.IdRespuesta);
            return View(respuestaContenido);
        }

        // POST: RespuestaContenidoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdRespuestaContenido,IdRespuesta,Contenido,ContenidHtml")] RespuestaContenido respuestaContenido)
        {
            if (ModelState.IsValid)
            {
                db.Entry(respuestaContenido).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdRespuesta = new SelectList(db.Respuesta, "IdRespuesta", "Titulo", respuestaContenido.IdRespuesta);
            return View(respuestaContenido);
        }

        // GET: RespuestaContenidoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RespuestaContenido respuestaContenido = db.RespuestaContenido.Find(id);
            if (respuestaContenido == null)
            {
                return HttpNotFound();
            }
            return View(respuestaContenido);
        }

        // POST: RespuestaContenidoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RespuestaContenido respuestaContenido = db.RespuestaContenido.Find(id);
            db.RespuestaContenido.Remove(respuestaContenido);
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
