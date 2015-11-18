using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PracticaAlmacenes.Models;

namespace PracticaAlmacenes.Controllers
{
    public class EtiquetaController : Controller
    {
        mitienda02Entities1 db =new mitienda02Entities1();
        // GET: Etiqueta
        public ActionResult Index()
        {
            var data = db.Etiqueta;
            ViewBag.Almacenes = db.Almacen;
            return View(data);
        }
    }
}