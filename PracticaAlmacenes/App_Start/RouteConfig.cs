using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace PracticaAlmacenes
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            //axd son fichero o librerias compiladas y lo ignora
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");



            routes.MapRoute(
                name: "DetalleProducto",
                url:"item/{nombre}",
                defaults: new
                {
                    controller = "Producto",
                    action="Detalle",
                    nombre=UrlParameter.Optional
                }
                );

            routes.MapRoute(
                name: "Default",
                //Son parametro variables 1 controller 2 action y 3 id si id no esta en {} sera
                //
                url: "{controller}/{action}/{id}",

                //ejemplo de ruta predetermida 17/112015
                //defaults: new { controller = "Producto", action = "Index", id = UrlParameter.Optional }
                
                
                defaults: new { controller = "Producto", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
