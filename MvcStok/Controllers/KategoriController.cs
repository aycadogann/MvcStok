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

        [HttpGet]
        public ActionResult YeniKategoriEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniKategoriEkle(Kategoriler kategori)
        {
            db.Kategoriler.Add(kategori);
            db.SaveChanges();
            return View();
        }
        public ActionResult Sil(int id)
        {
            var kategori = db.Kategoriler.Find(id);
            db.Kategoriler.Remove(kategori);
            db.SaveChanges();
            return RedirectToAction("KategoriListele");
        }
        public ActionResult KategoriGetir(int id)
        {
            var kategori = db.Kategoriler.Find(id);
            return View("KategoriGetir", kategori);
        }

        public ActionResult Guncelle(Kategoriler k)
        {
            var kategori = db.Kategoriler.Find(k.KategoriId);
            kategori.KategoriAd = k.KategoriAd;
            db.SaveChanges();
            return RedirectToAction("KategoriListele");
        }
    }
}