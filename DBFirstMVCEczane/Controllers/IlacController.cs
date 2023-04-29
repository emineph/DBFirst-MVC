using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DBFirstMVCEczane.Models;

namespace DBFirstMVCEczane.Controllers
{
    public class IlacController : Controller
    {
        // GET: Ilac
        EczaneEntities2 db = new EczaneEntities2();

        public ActionResult Index()
        {
            return View(db.İlac.ToList());
        }

        public ActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Ekle(İlac save)
        {
            try
            {
                using (EczaneEntities2 db = new EczaneEntities2())
                {
                    db.İlac.Add(save);
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
            using (EczaneEntities2 db = new EczaneEntities2())
                return View(db.İlac.Where(z => z.ID == id).FirstOrDefault());
        }

        [HttpPost]
        public ActionResult Delete(int id, İlac sil)
        {
            using (EczaneEntities2 db = new EczaneEntities2())
            {
                sil = db.İlac.Where(z => z.ID == id).FirstOrDefault();
                db.İlac.Remove(sil);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(int id)
        {
            using (EczaneEntities2 db = new EczaneEntities2())
                return View(db.İlac.Where(z => z.ID == id).FirstOrDefault());
        }

        [HttpPost]
        public ActionResult Edit(int id, İlac yenile)
        {
            using(EczaneEntities2 db= new EczaneEntities2())
            {
                db.Entry(yenile).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

    }
}