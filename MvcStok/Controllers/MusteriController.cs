using System;
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
        public ActionResult MusteriListele()
        {
            var musteri=db.Musteriler.ToList();
            return View(musteri);
        }

        [HttpGet]
        public ActionResult YeniMusteriEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniMusteriEkle(Musteriler musteri)
        {
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
    }
}