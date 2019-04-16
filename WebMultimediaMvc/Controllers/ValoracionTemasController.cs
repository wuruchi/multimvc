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
    public class ValoracionTemasController : Controller
    {
        private SalesERPDBEntities db = new SalesERPDBEntities();

        // GET: ValoracionTemas
        public ActionResult Index()
        {
            var valoracionTema = db.ValoracionTema.Include(v => v.Tema);
            return View(valoracionTema.ToList());
        }

        // GET: ValoracionTemas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ValoracionTema valoracionTema = db.ValoracionTema.Find(id);
            if (valoracionTema == null)
            {
                return HttpNotFound();
            }
            return View(valoracionTema);
        }

        // GET: ValoracionTemas/Create
        public ActionResult Create()
        {
            ViewBag.IdTema = new SelectList(db.Tema, "IdTema", "Titulo");
            return View();
        }

        // POST: ValoracionTemas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdValoracionTema,Cantidad,TipoMarca,IdUsuarioCreador,FechaCreacion,IdTema")] ValoracionTema valoracionTema)
        {
            if (ModelState.IsValid)
            {
                db.ValoracionTema.Add(valoracionTema);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdTema = new SelectList(db.Tema, "IdTema", "Titulo", valoracionTema.IdTema);
            return View(valoracionTema);
        }

        // GET: ValoracionTemas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ValoracionTema valoracionTema = db.ValoracionTema.Find(id);
            if (valoracionTema == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdTema = new SelectList(db.Tema, "IdTema", "Titulo", valoracionTema.IdTema);
            return View(valoracionTema);
        }

        // POST: ValoracionTemas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdValoracionTema,Cantidad,TipoMarca,IdUsuarioCreador,FechaCreacion,IdTema")] ValoracionTema valoracionTema)
        {
            if (ModelState.IsValid)
            {
                db.Entry(valoracionTema).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdTema = new SelectList(db.Tema, "IdTema", "Titulo", valoracionTema.IdTema);
            return View(valoracionTema);
        }

        // GET: ValoracionTemas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ValoracionTema valoracionTema = db.ValoracionTema.Find(id);
            if (valoracionTema == null)
            {
                return HttpNotFound();
            }
            return View(valoracionTema);
        }

        // POST: ValoracionTemas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ValoracionTema valoracionTema = db.ValoracionTema.Find(id);
            db.ValoracionTema.Remove(valoracionTema);
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
