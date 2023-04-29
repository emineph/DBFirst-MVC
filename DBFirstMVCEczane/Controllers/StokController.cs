using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DBFirstMVCEczane.Models;

namespace DBFirstMVCEczane.Controllers
{
    public class StokController : Controller
    {
        // GET: Stok

        EczaneEntities db = new EczaneEntities();
        public ActionResult Index()
        {
            return View(db.Stoks.ToList());
        }

        public ActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Ekle(Stok save)
        {
            try
            {
                using(EczaneEntities db= new EczaneEntities())
                {
                    db.Stoks.Add(save);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch 
            {

                return View();
            }
        }
        
        public ActionResult Delete(int id)
        {
            using (EczaneEntities db = new EczaneEntities())
                return View(db.Stoks.Where(a => a.StokID == id).FirstOrDefault());
        }

        [HttpPost]
        public ActionResult Delete(int id, Stok sil)
        {
            using(EczaneEntities db= new EczaneEntities())
            {
                sil = db.Stoks.Where(a => a.StokID == id).FirstOrDefault();
                db.Stoks.Remove(sil);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
    }
}