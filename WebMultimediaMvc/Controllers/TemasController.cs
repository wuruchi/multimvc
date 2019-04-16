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
    public class TemasController : Controller
    {
        private SalesERPDBEntities db = new SalesERPDBEntities();

        // GET: Temas
        public ActionResult Index()
        {
            var tema = db.Tema.Include(t => t.Seccion).Include(t => t.TipoTema);
            return View(tema.ToList());
        }

        // GET: Temas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tema tema = db.Tema.Find(id);
            if (tema == null)
            {
                return HttpNotFound();
            }
            return View(tema);
        }

        // GET: Temas/Create
        public ActionResult Create()
        {
            ViewBag.IdSeccion = new SelectList(db.Seccion, "IdSeccion", "Titulo");
            ViewBag.IdTipoTema = new SelectList(db.TipoTema, "IdTipoTema", "Descripcion");
            return View();
        }

        // POST: Temas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdTema,IdTipoTema,IdSeccion,Estado,Titulo,CantidadComentario,CantidadRespuesta,ScoreObtenido,CantidadVista,ResumenEdicion,IdUsuarioEstadoPor,FechaEstadoPor,NombreEstadoPor,FlagTema,IdUsuarioFlagPor,FechaFlagPor,NombreFlagPor,IdUsuarioCreador,NombreUsuarioCreador,FechaCreacion,IdUsuarioModificador,NombreUsuarioModificador,FechaModificacion,Tag1,Tag2,Tag3,Tag4,Tag5,Tags,VisitanteIP,CantidadEdicion")] Tema tema)
        {
            if (ModelState.IsValid)
            {
                db.Tema.Add(tema);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdSeccion = new SelectList(db.Seccion, "IdSeccion", "Titulo", tema.IdSeccion);
            ViewBag.IdTipoTema = new SelectList(db.TipoTema, "IdTipoTema", "Descripcion", tema.IdTipoTema);
            return View(tema);
        }

        // GET: Temas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tema tema = db.Tema.Find(id);
            if (tema == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdSeccion = new SelectList(db.Seccion, "IdSeccion", "Titulo", tema.IdSeccion);
            ViewBag.IdTipoTema = new SelectList(db.TipoTema, "IdTipoTema", "Descripcion", tema.IdTipoTema);
            return View(tema);
        }

        // POST: Temas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdTema,IdTipoTema,IdSeccion,Estado,Titulo,CantidadComentario,CantidadRespuesta,ScoreObtenido,CantidadVista,ResumenEdicion,IdUsuarioEstadoPor,FechaEstadoPor,NombreEstadoPor,FlagTema,IdUsuarioFlagPor,FechaFlagPor,NombreFlagPor,IdUsuarioCreador,NombreUsuarioCreador,FechaCreacion,IdUsuarioModificador,NombreUsuarioModificador,FechaModificacion,Tag1,Tag2,Tag3,Tag4,Tag5,Tags,VisitanteIP,CantidadEdicion")] Tema tema)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tema).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdSeccion = new SelectList(db.Seccion, "IdSeccion", "Titulo", tema.IdSeccion);
            ViewBag.IdTipoTema = new SelectList(db.TipoTema, "IdTipoTema", "Descripcion", tema.IdTipoTema);
            return View(tema);
        }

        // GET: Temas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tema tema = db.Tema.Find(id);
            if (tema == null)
            {
                return HttpNotFound();
            }
            return View(tema);
        }

        // POST: Temas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tema tema = db.Tema.Find(id);
            db.Tema.Remove(tema);
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
