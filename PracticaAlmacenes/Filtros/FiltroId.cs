using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PracticaAlmacenes.Filtros
{
    public class FiltroId : ActionFilterAttribute
    {
        public override void OnActionExecuting
                  (ActionExecutingContext filterContext)
        {
            String id = null;
            try
            {
                id = filterContext.ActionParameters["id"].ToString();
            }
            catch (Exception)
            {

            }
            var pet = filterContext.ActionDescriptor.ActionName;
            if (id == null && pet != "Index")
            {
                filterContext.Result =
                    new HttpStatusCodeResult(500);// RedirectResult("http://www.google.com");


            }

            base.OnActionExecuting(filterContext);
        }

    }
}
