using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataConsulting.Multimedia.Entidades;
using DataConsulting.Multimedia.Negocio.Main.BusinessRules;

namespace WebMultimediaMvc.Controllers
{
    public class SeccionController : Controller
    {
        //private SalesERPDBEntities db = new SalesERPDBEntities();

        // GET: Seccions
        public ActionResult Index(string Mensaje = "", int TipoMensaje = 0, int Estado)
        {
            try
            {
                Session["seccion"] = null;
                List<SeccionBE> moLista = SeccionBR.GetSeccion(0, Estado);

                ViewBag.Message = Mensaje;
                ViewBag.TipoMensaje = TipoMensaje;

                return View(moLista);
            }
            catch
            {
                return RedirectToAction("Index", new
                {
                    Mensaje = "Se produjo un error al inicializar el formulario de empresa.",
                    TipoMensaje = 2
                });
            }

            //var seccion = db.Seccion.Include(s => s.TipoSeccion);
            //return View(seccion.ToList());
        }

        // GET: Seccions/Details/5
        public ActionResult Details(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
                SeccionBE seccion = SeccionBR.GetSeccionById(id);
            if (seccion == null)
            {
                return HttpNotFound();
            }
            return View(seccion);
        }

        // GET: Seccions/Create
        //public ActionResult Create()
        //{
        //    ViewBag.IdTipoSeccion = new SelectList(db.TipoSeccion, "IdTipoSeccion", "Nombre");
        //    return View();
        //}

        // POST: Seccions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "IdSeccion,Titulo,Descripcion,Estado,IdUsuarioCreador,FechaCreacion,IdUsuarioModificador,FechaModificacion,IdTipoSeccion")] Seccion seccion)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Seccion.Add(seccion);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.IdTipoSeccion = new SelectList(db.TipoSeccion, "IdTipoSeccion", "Nombre", seccion.IdTipoSeccion);
        //    return View(seccion);
        //}

        // GET: Seccions/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Seccion seccion = db.Seccion.Find(id);
        //    if (seccion == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.IdTipoSeccion = new SelectList(db.TipoSeccion, "IdTipoSeccion", "Nombre", seccion.IdTipoSeccion);
        //    return View(seccion);
        //}

        // POST: Seccions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "IdSeccion,Titulo,Descripcion,Estado,IdUsuarioCreador,FechaCreacion,IdUsuarioModificador,FechaModificacion,IdTipoSeccion")] Seccion seccion)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(seccion).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.IdTipoSeccion = new SelectList(db.TipoSeccion, "IdTipoSeccion", "Nombre", seccion.IdTipoSeccion);
        //    return View(seccion);
        //}

        // GET: Seccions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Seccion seccion = db.Seccion.Find(id);
            if (seccion == null)
            {
                return HttpNotFound();
            }
            return View(seccion);
        }

        // POST: Seccions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Seccion seccion = db.Seccion.Find(id);
            db.Seccion.Remove(seccion);
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
