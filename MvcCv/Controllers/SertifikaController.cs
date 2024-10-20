using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using MvcCv.Models.Entity;
using MvcCv.Repositories;

namespace MvcCv.Controllers
{
    public class SertifikaController : Controller
    {
        // GET: Sertifika
        GenericRepository<TblSertifikalarim> repo = new GenericRepository<TblSertifikalarim>();
        public ActionResult Index()
        {
            var sertifika = repo.List();
            return View(sertifika);
        }
        [HttpGet]
        public ActionResult SertifikaGetir(int id)
        {
            var sertifika = repo.Find(x => x.ID == id);
            return View(sertifika);
        }
        [HttpPost]
        public ActionResult SertifikaGetir(TblSertifikalarim t)
        {
            var sertifika = repo.Find(x => x.ID == t.ID);
            sertifika.Tarih = t.Tarih;
            sertifika.Aciklama1 = t.Aciklama1;
            sertifika.Aciklama2 = t.Aciklama2;
            sertifika.Aciklama3 = t.Aciklama3;
            repo.TUpdate(sertifika);
            return RedirectToAction("Index");
            return View();
        }
        [HttpGet]
        public ActionResult YeniSertifika()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniSertifika(TblSertifikalarim p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }

        public ActionResult SertifikaSil(int id)
        {
            TblSertifikalarim c = repo.Find(x => x.ID == id);
            repo.TDelete(c);
            return RedirectToAction("Index");
        }
    }
}