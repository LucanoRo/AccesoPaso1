using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AccesoPaso1.Models;

namespace AccesoPaso1.Controllers
{
    [Authorize]
    public class CatalogoController : Controller
    {
        private contextTienda db = new contextTienda();
        // GET: Catalogo
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult BuscarProd(String nomBuscar)
        {
            ViewBag.SearchKey = nomBuscar;
            using (db)
            {
                var query = from st in db.producto
                            where st.nombre.Contains(nomBuscar)
                            select st;

                var listProd = query.ToList();
                ViewBag.Listado = listProd;
            }
            return View();
        }

       public ActionResult prodCategoria(int idCat)
        {
            List<producto> mercancia = null;
            var query = from p in db.producto
                        where p.id_categoria == idCat
                        select p;

            if (idCat == 1)
            {
                List<producto> toallas = query.ToList();
                mercancia = toallas;
                ViewBag.Catego = "Toallas";
                
            }
            if (idCat == 2)
            {
                List<producto> piel = query.ToList();
                mercancia = piel;
                ViewBag.Catego = "Piel";
            }
            ViewBag.productos = mercancia;
            return View();
        }
    }
}