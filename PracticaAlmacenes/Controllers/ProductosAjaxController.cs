using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PracticaAlmacenes.Models;

namespace PracticaAlmacenes.Controllers
{
    public class ProductosAjaxController : Controller
    {
        mitienda02Entities1 db = new mitienda02Entities1();

        // GET: ProductosAjax
        public ActionResult Index()
        {

            return View(db.Producto);
        }

        //Para deshabilitar el cache 17/11
        [OutputCache(Duration=0 , VaryByParam="*")]


        //El nombre de este string debera ser igual que el index
        public ActionResult Buscar(string nombre)
        {
            var data = db.Producto.Where(o => o.nombre.Contains(nombre));
            return PartialView("_listadoProducto", data);
            
        }

        //codigo añadido 17/11
        public ActionResult Alta(Producto model)
        {
            db.Producto.Add(model);
            db.SaveChanges();
            return Json(model);
            

        }
        
    }
}