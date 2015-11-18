using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PracticaAlmacenes.Filtros;
using PracticaAlmacenes.Models;

namespace PracticaAlmacenes.Controllers
{
    public class AlmacenController : Controller
    {
        mitienda02Entities1 db=  new mitienda02Entities1();

        public ActionResult Borrar(int id)
        {
            var data = db.Almacen.Find(id);
            //si tienes un producto ALmacen pues eliminamelos. Esto es un borrado en casacada. 
            //No se suele utilizar este metodo.
            if (data.ProductosAlmacen.Any()) db.ProductosAlmacen.RemoveRange(data.ProductosAlmacen);
            {
                db.Almacen.Remove(data);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        //listado de almacenes accedemos y la pasamos a la vista
        public ActionResult Index()
        {
            var data = db.Almacen;
            return View(data);
        }

        [FiltroId]
        public ActionResult Modificacion(int id)
        {
            var data = db.Almacen.Find(id);
            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Modificacion(Almacen model)
        {
            if (ModelState.IsValid)
            {
                //este modelo modificado en model esta el id
                db.Entry(model).State=EntityState.Modified;
                db.SaveChanges();
                //cuando llegue aqui, vuelve a index
                return RedirectToAction("Index");
            }

            return View(model);
        }

        //public ActionResult Detalle(int id)
        //{
        //    var data = db.Almacen.Find(id);
        //    return View(data);
        //}
        
        public ActionResult Alta()
        {
            return View(new Almacen());
        }
        
        [HttpPost]

        public ActionResult Alta(Almacen model)
        {
            if (ModelState.IsValid)
            {
                db.Almacen.Add(model);
                db.SaveChanges();
                return View(new Almacen());
                
            }
            return View(model);



        }

    }
}