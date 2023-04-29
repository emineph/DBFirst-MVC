using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DBFirstMVCEczane.Models;

namespace DBFirstMVCEczane.Controllers
{
    public class HomeController : Controller
    {
        EczaneEntities db = new EczaneEntities();
        //GET: HOme
        public ActionResult Index()
        {
            return View(db.Kullanicilar1.ToList());
        }

        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]

        public ActionResult SignUp(Kullanicilar1 kullanicilar)
        {
            if (db.Kullanicilar1.Any(x => x.KullaniciAdi == kullanicilar.KullaniciAdi))
            {
                ViewBag.Notification = "böyle kişi var";
            }
            else
            {
                db.Kullanicilar1.Add(kullanicilar);
                db.SaveChanges();
                Session["KullaniciNo"] = kullanicilar.KullaniciNo.ToString();
                Session["KullaniciAdi"] = kullanicilar.KullaniciAdi.ToString();
            }

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Login(Kullanicilar1 kullanicilar)
        {
            var loginkontrol = db.Kullanicilar1.Where(x => x.KullaniciAdi.Equals(kullanicilar.KullaniciAdi) && x.Sifre.Equals(kullanicilar.Sifre)).FirstOrDefault();
            if (loginkontrol != null)
            {
                Session["KullaniciNo"] = kullanicilar.KullaniciNo.ToString();
                Session["KullaniciAdi"] = kullanicilar.KullaniciAdi.ToString();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Notification = "Yanlış Kullanıcı Adı ve Şifre Tekrar deneyiniz";
            }
            return View();

        }

        //public ActionResult Login (Kullanicilar kullanicilar)
        //{

        //}

        //public ActionResult Contact()
        //{
        //    ViewBag.Message = "Your contact page.";

        //    return View();
        //}
        //public ActionResult About()
        //{
        //    ViewBag.Message = "Your application description page.";

        //    return View();
        //}
    }
}