﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;


namespace MvcStok.Controllers
{
    public class MusteriController : Controller
    {
        // GET: Musteri
        MVCDbStokEntities db = new MVCDbStokEntities();
        public ActionResult MusteriListele(string p)
        {
            //var musteri=db.Musteriler.ToList();
            //return View(musteri);
            var degerler= from d in db.Musteriler select d;
            if (!string.IsNullOrEmpty(p))
            {
                degerler = degerler.Where(m => m.MusteriAd.Contains(p));
            }
            return View(degerler.ToList());
        }

        [HttpGet]
        public ActionResult YeniMusteriEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniMusteriEkle(Musteriler musteri)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniMusteriEkle");
            }
            db.Musteriler.Add(musteri);
            db.SaveChanges();
            return View();
        }
        public ActionResult Sil(int id)
        {
            var musteri = db.Musteriler.Find(id);
            db.Musteriler.Remove(musteri);
            db.SaveChanges();
            return RedirectToAction("MusteriListele");
        }
        public ActionResult MusteriGetir(int id)
        {
            var musteri = db.Musteriler.Find(id);
            return View("MusteriGetir", musteri);
        }
        public ActionResult Guncelle(Musteriler p1)
        {
            var musteri = db.Musteriler.Find(p1.MusteriId);
            musteri.MusteriAd = p1.MusteriAd;
            musteri.MusteriSoyad = p1.MusteriSoyad;
            db.SaveChanges();
            return RedirectToAction("MusteriListele");
        }
    }
}