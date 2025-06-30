using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;

namespace MvcStok.Controllers
{
    public class SatisController : Controller
    {
        MVCDbStokEntities db = new MVCDbStokEntities();

        // GET: Satis
        //public ActionResult Index()
        //{
        //    return View();
        //}
        public ActionResult SatisListele()
        {
            return View();
        }
        [HttpGet]
        public ActionResult YeniSatis()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniSatis(Satislar s)
        {
            db.Satislar.Add(s);
            db.SaveChanges();
            return View("SatisListele");
        }
    }
}