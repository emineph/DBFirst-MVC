using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DBFirstMVCEczane.Models;

namespace DBFirstMVCEczane.Controllers
{
    public class SiparisController : Controller
    {
        // GET: Siparis

        EczaneEntities db = new EczaneEntities();
        public ActionResult Index()
        {
            return View(db.Siparis1.ToList());
        }

        public ActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Ekle(Siparis save)
        {
            try
            {
                using (EczaneEntities db=new EczaneEntities())
                {
                    db.Siparis1.Add(save);
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
                return View(db.Siparis1.Where(a => a.SiparişID == id).FirstOrDefault());
        }

        [HttpPost]
        public ActionResult Delete(int id, Siparis sil)
        {
            using(EczaneEntities db= new EczaneEntities())
            {
                sil = db.Siparis1.Where(z => z.SiparişID == id).FirstOrDefault();
                db.Siparis1.Remove(sil);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
    }
}