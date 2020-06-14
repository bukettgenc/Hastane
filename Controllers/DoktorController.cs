using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using System.Windows.Forms;
using Hastane.Models;
using FormCollection = System.Web.Mvc.FormCollection;

namespace Hastane.Controllers
{
    public class DoktorController : Controller
    {

        HastaneEntities db = new HastaneEntities();
        // GET: Doktor
        public ActionResult Receteler()
        {
            HastaneEntities db = new HastaneEntities();
            var sonuc = db.Reçeteler.ToList();
            ViewBag.receteList = sonuc;
            return View();
        }
        [HttpPost]
        public ActionResult Receteler(FormCollection form)
        {
            HastaneEntities db = new HastaneEntities();
            var sonuc = db.Reçeteler.ToList();
            string ilaclar = form["ilac"];
            string tutar = form["tutar"];
            string Id = form["Id"];

            foreach (var item in sonuc)
            {
                if (item.Id.ToString() == Id)
                {
                    item.Ilaclar = ilaclar;
                    item.Tutar = tutar;
                }
                else
                {
                    MessageBox.Show("Lütfen hastayı seçiniz");
                }
            }

            db.SaveChanges();
            ViewBag.receteList = sonuc;
            return View();
        }
        public ActionResult ReceteYazmaSayfasi()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ReceteYazmaSayfasi(FormCollection form)
        {
            return View();
        }


        public ActionResult DoktorGirisSayfasi()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DoktorGirisSayfasi(FormCollection form)
        {
            HastaneEntities db = new HastaneEntities();
            string tcNo = Request.Form["tcNo"];
            string sifre = Request.Form["sifre"];
            var doktorListe = db.Doktorlar.Select(x => new { x.DoktorSifre, x.DoktorTc }).ToList();
            String degisken = "";
            int i = 0;
            foreach (var item in doktorListe)
            {
                if (i == 0)
                {
                    if (tcNo == item.DoktorTc && sifre == item.DoktorSifre)
                    {
                        degisken = "DoktorAnasayfa";
                        i = 1;
                    }
                    else
                    {
                        degisken = "DoktorGirisSayfasi";

                    }
                }
            }
            if (degisken == "DoktorGirisSayfasi")
            {

                MessageBox.Show("Tc veya Şifre yanlış");
            }
            DoktorTc d = new DoktorTc();
            d.tcNoDoktor = tcNo;
            db.DoktorTc.Add(d);
            db.SaveChanges();
            return RedirectToAction(degisken, "Doktor");
        }

        public ActionResult DoktorAnasayfa()
        {
            var doktorTcList = db.DoktorTc.Select(x => x.tcNoDoktor).ToList();

            string tc = "";
            foreach (var tcNo in doktorTcList)
            {
                tc = tcNo;
            }
            ViewBag.doktorTc = tc;
            return View();

        }
        [HttpPost]
        public ActionResult DoktorAnasayfa(FormCollection form)
        {
            Reçeteler recete = new Reçeteler();

            DateTime simdikiTarih = DateTime.Now.Date;
            string HastaAdi = form["hasta"];
            string ilacAdi = form["ilacAdi"];
            string tutar = form["tutar"];
            if (HastaAdi == null)
            {
                MessageBox.Show("Hastayı Seçiniz");
            }
            else
            {
                recete.HastaAdi = HastaAdi;
                recete.Ilaclar = ilacAdi;
                recete.Tutar = tutar;
                recete.Tarih = simdikiTarih;
                db.Reçeteler.Add(recete);
                db.SaveChanges();
            }

            var doktorTcList = db.DoktorTc.Select(x => x.tcNoDoktor).ToList();

            string tc = "";
            foreach (var tcNo in doktorTcList)
            {
                tc = tcNo;
            }
            ViewBag.doktorTc = tc;
            return View();
        }

        public ActionResult RaporYaz()
        {
            var doktorTcList = db.DoktorTc.Select(x => x.tcNoDoktor).ToList();

            string tc = "";
            foreach (var tcNo in doktorTcList)
            {
                tc = tcNo;
            }
            ViewBag.doktorTc = tc;
            return View();
        }
        [HttpPost]
        public ActionResult RaporYaz(FormCollection form)
        {

            Reçeteler recete = new Reçeteler();
            Raporlar rapor=new Raporlar();

            DateTime simdikiTarih = DateTime.Now.Date;
            string HastaAdi = form["hasta"];
            string raporSebebi = form["raporSebebi"];
            string baslangicTarihi = form["baslangicTarihi"];
            string bitisTarihi = form["bitisTarihi"];

            if (HastaAdi == null)
            {
                MessageBox.Show("Hastayı Seçiniz");
            }
            else
            {
                rapor.HastaAdi = HastaAdi;
                rapor.RaporBaslangic = Convert.ToDateTime(baslangicTarihi);
                rapor.RaporBitis = Convert.ToDateTime(bitisTarihi);
                rapor.RaporSebebi = raporSebebi;
                rapor.Tarih = simdikiTarih;
                rapor.RaporuVerenDoktor = "x";
                db.Raporlar.Add(rapor);
                db.SaveChanges();
            }

            var doktorTcList = db.DoktorTc.Select(x => x.tcNoDoktor).ToList();

            string tc = "";
            foreach (var tcNo in doktorTcList)
            {
                tc = tcNo;
            }
            ViewBag.doktorTc = tc;
            return View();
        }
    }
}