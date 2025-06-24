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
            List<SelectListItem> degerler = (from i in db.Kategoriler.ToList()
                                               select new SelectListItem
                                               {
                                                   Text = i.KategoriAd,
                                                   Value = i.KategoriId.ToString()
                                               }).ToList();
            ViewBag.dgr = degerler;
            return View();
        }

        [HttpPost]
        public ActionResult YeniUrunEkle(Urunler urun)
        {
            var ktgr = db.Kategoriler.Where(k => k.KategoriId == urun.Kategoriler.KategoriId).FirstOrDefault();
            urun.Kategoriler = ktgr;
            db.Urunler.Add(urun);
            db.SaveChanges();
            return RedirectToAction("UrunListele");
        }
        public ActionResult Sil(int id)
        {
            var urun = db.Urunler.Find(id);
            db.Urunler.Remove(urun);
            db.SaveChanges();
            return RedirectToAction("UrunListele");
        }
        

    }
}