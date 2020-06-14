using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Web;
using System.Web.Mvc;
using System.Windows.Forms;
using Hastane.Models;
using Microsoft.Ajax.Utilities;
using FormCollection = System.Web.Mvc.FormCollection;

namespace Hastane.Controllers
{
    public class GirisController : Controller
    {
        HastaneEntities db = new HastaneEntities();

        // GET: Giris

        public ActionResult CalisanGirisSayfasi()
        {
            string isim = Request.Form["isim"];
            string sifre = Request.Form["sifre"];
            var calisanListe = db.Calisanlar.Select(x => new { x.CalisanAdi, x.CalisanSifre }).ToList();
            var musteriListe = db.Musteriler.Select(x => new { x.MusteriAdi, x.MusteriSifre }).ToList();
            String degisken = "";
            foreach (var item in calisanListe)
            {
                if (isim == item.CalisanAdi && sifre == item.CalisanSifre)
                {
                    degisken = "CalisanAnasayfa";
                }
                else
                {
                    degisken = "CalisanGirisSayfasi";
                }
            }
            return View(degisken);
        }

        public ActionResult MusteriGirisSayfasi()
        {
            return View();
        }
        [HttpPost]
        public ActionResult MusteriGirisSayfasi(FormCollection form)
        {

            string tcNo = Request.Form["tcNo"];
            string sifre = Request.Form["sifre"];

            var musteriListe = db.Musteriler.Select(x => new { x.MusteriTc, x.MusteriAdi, x.MusteriSifre }).ToList();
            String degisken = "";
            string HastaAdi = "";
            int i = 0;
            foreach (var item in musteriListe)
            {
                if (i == 0)
                {

                    if (tcNo == item.MusteriTc && sifre == item.MusteriSifre)
                    {
                        degisken = "MusteriAnasayfa";

                        HastaAdi = item.MusteriAdi;
                        i = 1;

                    }
                    else
                    {
                        degisken = "MusteriGirisSayfasi";
                    }
                }
            }

            if (degisken== "MusteriGirisSayfasi")
            {

                MessageBox.Show("Tc veya Şifre yanlış");
            }
            HastaTc h = new HastaTc();
            h.tcNoHasta = tcNo;
            h.HastaAdi = HastaAdi;
            db.HastaTc.Add(h);
            db.SaveChanges();
            return RedirectToAction(degisken, "Giris");
        }
      
        public ActionResult RandevularimiGoruntule()
        {

            return View();
        }
        public ActionResult MusteriAnasayfa()
        {
            var hastaTcler = db.HastaTc.Select(x => x.tcNoHasta).ToList();

            string tc = "";
            foreach (var tcNo in hastaTcler)
            {
                tc = tcNo;
            }
            ViewBag.tcNo = tc;

            return View();
        }
        [HttpPost]
        public ActionResult MusteriAnasayfa(FormCollection form)
        {

            string dropdownValue = form["dropdown"];
            string doktorAdi = form["doktor"];

            var liste = db.Doktorlar.Where(x => x.DoktorAdi == doktorAdi).Select(x => new { x.Bolum, x.DoktorTc }).ToList();
            Randevular r = new Randevular();
            var hastaTcler = db.HastaTc.Select(x => new { x.tcNoHasta, x.HastaAdi }).ToList();

            string tc = "";
            string hastaAdi = "";
            foreach (var hasta in hastaTcler)
            {
                tc = hasta.tcNoHasta;
                hastaAdi = hasta.HastaAdi;
            }
            ViewBag.tcNo = tc;
            foreach (var item in liste)
            {
                r.DoktorTc = item.DoktorTc;
                r.Bolum = item.Bolum;
            }

            r.HastaTc = tc;
            r.HastaAdi = hastaAdi;
            r.DoktorAdi = doktorAdi;

            r.RandevuSaati = dropdownValue;

            db.Randevular.Add(r);
            db.SaveChanges();
            //doktorun adı,hastanın adı,randevu saati if seçilen randevu saati dbden çekilenlerin içinde varsa zaten dolu de
            return View();
        }

        public ActionResult Sil(int id)
        {
            var randevu = db.Randevular.Find(id);
            db.Randevular.Remove(randevu);
            db.SaveChanges();
            var hastaTcler = db.HastaTc.Select(x => x.tcNoHasta).ToList();

            string tc = "";
            foreach (var tcNo in hastaTcler)
            {
                tc = tcNo;
            }
            ViewBag.tcNo = tc;
            return RedirectToAction("MusteriAnasayfa", "Giris"); ;
        }
    }
}
