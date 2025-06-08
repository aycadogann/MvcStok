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
    }
}