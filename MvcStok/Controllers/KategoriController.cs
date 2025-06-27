using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;
using PagedList;
using PagedList.Mvc;

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

        public ActionResult KategoriListele(int sayfa=1)
        {
            //var kategoriler = db.Kategoriler.ToList();
            var degerler = db.Kategoriler.ToList().ToPagedList(sayfa, 4);
            return View(degerler);
        }

        [HttpGet]
        public ActionResult YeniKategoriEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniKategoriEkle(Kategoriler kategori)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniKategoriEkle");
            }
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