using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;

namespace MvcStok.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        MVCDbStokEntities db = new MVCDbStokEntities();

        //public ActionResult Index()
        //{
        //    return View();
        //}

        public ActionResult KategoriListele()
        {
            var kategoriler = db.Kategoriler.ToList();
            return View(kategoriler);
        }


    }
}