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
    public class ValoracionRespuestasController : Controller
    {
        private SalesERPDBEntities db = new SalesERPDBEntities();

        // GET: ValoracionRespuestas
        public ActionResult Index()
        {
            var valoracionRespuesta = db.ValoracionRespuesta.Include(v => v.Respuesta);
            return View(valoracionRespuesta.ToList());
        }

        // GET: ValoracionRespuestas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ValoracionRespuesta valoracionRespuesta = db.ValoracionRespuesta.Find(id);
            if (valoracionRespuesta == null)
            {
                return HttpNotFound();
            }
            return View(valoracionRespuesta);
        }

        // GET: ValoracionRespuestas/Create
        public ActionResult Create()
        {
            ViewBag.IdRespuesta = new SelectList(db.Respuesta, "IdRespuesta", "Titulo");
            return View();
        }

        // POST: ValoracionRespuestas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdValoracionRespuesta,Cantidad,TipoMarca,IdUsuarioCreador,FechaCreacion,IdRespuesta")] ValoracionRespuesta valoracionRespuesta)
        {
            if (ModelState.IsValid)
            {
                db.ValoracionRespuesta.Add(valoracionRespuesta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdRespuesta = new SelectList(db.Respuesta, "IdRespuesta", "Titulo", valoracionRespuesta.IdRespuesta);
            return View(valoracionRespuesta);
        }

        // GET: ValoracionRespuestas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ValoracionRespuesta valoracionRespuesta = db.ValoracionRespuesta.Find(id);
            if (valoracionRespuesta == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdRespuesta = new SelectList(db.Respuesta, "IdRespuesta", "Titulo", valoracionRespuesta.IdRespuesta);
            return View(valoracionRespuesta);
        }

        // POST: ValoracionRespuestas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdValoracionRespuesta,Cantidad,TipoMarca,IdUsuarioCreador,FechaCreacion,IdRespuesta")] ValoracionRespuesta valoracionRespuesta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(valoracionRespuesta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdRespuesta = new SelectList(db.Respuesta, "IdRespuesta", "Titulo", valoracionRespuesta.IdRespuesta);
            return View(valoracionRespuesta);
        }

        // GET: ValoracionRespuestas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ValoracionRespuesta valoracionRespuesta = db.ValoracionRespuesta.Find(id);
            if (valoracionRespuesta == null)
            {
                return HttpNotFound();
            }
            return View(valoracionRespuesta);
        }

        // POST: ValoracionRespuestas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ValoracionRespuesta valoracionRespuesta = db.ValoracionRespuesta.Find(id);
            db.ValoracionRespuesta.Remove(valoracionRespuesta);
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
