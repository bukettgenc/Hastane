using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Windows.Forms;
using Hastane.Models;
using FormCollection = System.Web.Mvc.FormCollection;

namespace Hastane.Controllers
{
    public class CalisanController : Controller
    {
        // GET: Calisan
        HastaneEntities db = new HastaneEntities();
        public ActionResult CalisanAnasayfa()
        {
            var doktorListesi = db.Doktorlar.ToList();
            ViewBag.aranmisDoktorListesi = doktorListesi;
            return View();
        }
        [HttpPost]
        public ActionResult CalisanAnasayfa(FormCollection form)
        {
            string aranan = form["aranan"];
            var doktorListesi = db.Doktorlar.ToList();
            var aranmisDoktorListesi = doktorListesi.Where(i=> i.DoktorAdi.ToLower().Contains(aranan.ToLower())).ToList();
            ViewBag.aranmisDoktorListesi = aranmisDoktorListesi;
            return View();
        }
        public ActionResult CalisanGirisSayfasi()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CalisanGirisSayfasi(FormCollection form)
        {
            HastaneEntities db = new HastaneEntities();
            string tcNo = Request.Form["tcNo"];
            string sifre = Request.Form["sifre"];
            var calisanListe = db.Calisanlar.Select(x => new { x.CalisanSifre, x.CalisanTc }).ToList();
            String degisken = "";
            int i = 0;
            foreach (var item in calisanListe)
            {
                if (i == 0)
                {
                    if (tcNo == item.CalisanTc && sifre == item.CalisanSifre)
                    {
                        degisken = "CalisanAnasayfa";
                        i = 1;
                    }
                    else
                    {
                        degisken = "CalisanGirisSayfasi";

                    }
                }
            }
            if (degisken == "CalisanGirisSayfasi")
            {

                MessageBox.Show("Tc veya Şifre yanlış");
            }
            CalisanTc calisan = new CalisanTc();
            calisan.tcNoCalisan = tcNo;
            db.CalisanTc.Add(calisan);
            db.SaveChanges();
            return RedirectToAction(degisken, "Calisan");
        }

        public ActionResult YeniDoktorEkle()
        {

            return View();

        }
        [HttpPost]
        public ActionResult YeniDoktorEkle(FormCollection form)
        {
            string kayitDoktorAdi = form["kayitDoktorAdi"];
            string kayitDoktorBolum = form["kayitDoktorBolum"];
            string kayitDoktortc = form["kayitDoktortc"];
            string kayitDoktorSifre = form["kayitDoktorSifre"];
            Doktorlar yeniDoktor=new Doktorlar();
            yeniDoktor.DoktorAdi = kayitDoktorAdi;
            yeniDoktor.Bolum = kayitDoktorBolum;
            yeniDoktor.DoktorTc = kayitDoktortc;
            yeniDoktor.DoktorSifre = kayitDoktorSifre;
            db.Doktorlar.Add(yeniDoktor);
            db.SaveChanges();
            return View();

        }
        public ActionResult DoktorSifreDegistir()
        {

            return View();

        }
        [HttpPost]
        public ActionResult DoktorSifreDegistir(FormCollection form)
        {
            string sifreDegistirTc = form["sifreDegistirTc"];
            string yeniSifre = form["yeniSifre"];

            var sonuc = db.Doktorlar.ToList();

            foreach (var yeniDoktor in sonuc)
            {
                if (yeniDoktor.DoktorTc==sifreDegistirTc)
                {
                    yeniDoktor.DoktorSifre = yeniSifre;
                }
                
            }
            db.SaveChanges();
            return View();

        }

    }
}