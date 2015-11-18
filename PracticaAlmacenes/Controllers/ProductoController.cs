using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PracticaAlmacenes.Models;

namespace PracticaAlmacenes.Controllers
{
    public class ProductoController : Controller
    {
        mitienda02Entities1 db=new mitienda02Entities1();


        //implementacion nueva 


        public ActionResult Index()
        {
            //codigo añadido ejemplo de ViewBag 16/11
           // var info = db.Etiqueta;
            //ViewBag.etiquetas = info.ToList();
            
            //codigo añadido ejemplo de ViewData  16/11
            //ViewData["Titulo"] = "Listado de Almacenes";
            //ViewData["Titulo"] = info.ToList();

            var data = db.Producto;
            return View(data);
        }

        //Tras haber cambiado el campo en RouteConfig.cs añadiremos esta parte de codigo 17/11
        public ActionResult Detalle(String nombre)
        {
            var nom = nombre.Replace("_", " ");

            var data = db.Producto.FirstOrDefault(o => o.nombre == nom);
            if (data == null)
                return RedirectToAction("Index");
            return View(data);
        }


        //public ActionResult Detalle(int id)
        //{
        //    var data = db.Producto.Find(id);
        //    return View(data);
        //}

        public ActionResult Alta()
        {
            return View(new Producto());
        }

        
        [HttpPost]
        public ActionResult Alta(Producto model)
        {
            if (ModelState.IsValid)
            {
                db.Producto.Add(model);
                db.SaveChanges();
                return View(new Producto());
            }
            return View(model);

        }
       

    }
}