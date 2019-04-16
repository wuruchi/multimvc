﻿using System;
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
    public class RespuestasController : Controller
    {
        private SalesERPDBEntities db = new SalesERPDBEntities();

        // GET: Respuestas
        public ActionResult Index()
        {
            var respuesta = db.Respuesta.Include(r => r.Tema);
            return View(respuesta.ToList());
        }

        // GET: Respuestas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Respuesta respuesta = db.Respuesta.Find(id);
            if (respuesta == null)
            {
                return HttpNotFound();
            }
            return View(respuesta);
        }

        // GET: Respuestas/Create
        public ActionResult Create()
        {
            ViewBag.IdTema = new SelectList(db.Tema, "IdTema", "Titulo");
            return View();
        }

        // POST: Respuestas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdRespuesta,IdTema,Titulo,IdUsuarioCreador,FechaCreacion,NombreUsuarioCreador,IdUsuarioModificador,FechaModificacion,NombreUsuarioModificador,FlagRespuesta,UsuarioFlagPor,FechaFlagPor,NombreFlagPor,Estado,UsuarioEstadoPor,FechaEstadoPor,NombreEstadoPor,CantidadVista,ScoreObtenido,CantidadComentario,ResumenEdicion,VisitanteIP,CantidadEdicion")] Respuesta respuesta)
        {
            if (ModelState.IsValid)
            {
                db.Respuesta.Add(respuesta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdTema = new SelectList(db.Tema, "IdTema", "Titulo", respuesta.IdTema);
            return View(respuesta);
        }

        // GET: Respuestas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Respuesta respuesta = db.Respuesta.Find(id);
            if (respuesta == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdTema = new SelectList(db.Tema, "IdTema", "Titulo", respuesta.IdTema);
            return View(respuesta);
        }

        // POST: Respuestas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdRespuesta,IdTema,Titulo,IdUsuarioCreador,FechaCreacion,NombreUsuarioCreador,IdUsuarioModificador,FechaModificacion,NombreUsuarioModificador,FlagRespuesta,UsuarioFlagPor,FechaFlagPor,NombreFlagPor,Estado,UsuarioEstadoPor,FechaEstadoPor,NombreEstadoPor,CantidadVista,ScoreObtenido,CantidadComentario,ResumenEdicion,VisitanteIP,CantidadEdicion")] Respuesta respuesta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(respuesta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdTema = new SelectList(db.Tema, "IdTema", "Titulo", respuesta.IdTema);
            return View(respuesta);
        }

        // GET: Respuestas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Respuesta respuesta = db.Respuesta.Find(id);
            if (respuesta == null)
            {
                return HttpNotFound();
            }
            return View(respuesta);
        }

        // POST: Respuestas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Respuesta respuesta = db.Respuesta.Find(id);
            db.Respuesta.Remove(respuesta);
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
