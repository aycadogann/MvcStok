using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;

namespace MvcStok.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        MVCDbStokEntities db = new MVCDbStokEntities();

        public ActionResult UrunListele()
        {
            var urunler = db.Urunler.ToList();
            return View(urunler);
        }

        [HttpGet]
        public ActionResult YeniUrunEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniUrunEkle(Urunler urun)
        {
            db.Urunler.Add(urun);
            db.SaveChanges();
            return View();
        }
    }
}