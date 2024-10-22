using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;
using MvcCv.Repositories;

namespace MvcCv.Controllers
{
    public class ProjeController : Controller
    {
        GenericRepository<TblProjelerim> repo=new GenericRepository<TblProjelerim>();
        // GET: Proje
        public ActionResult Index()
        {
            var projeler = repo.List();
            return View(projeler);
        }
        [HttpGet]
        public ActionResult YeniProje()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniProje(TblProjelerim p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult ProjeSil(int id)
        {
            var proje = repo.Find(x => x.ID == id);
            repo.TDelete(proje);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult ProjeDuzenle(int id)
        {
            var proje = repo.Find(x => x.ID == id);
            return View(proje);
        }
        [HttpPost]
        public ActionResult ProjeDuzenle(TblProjelerim t)
        {
            var y = repo.Find(x => x.ID == t.ID);
            y.Baslik = t.Baslik;
            y.Aciklama1 = t.Aciklama1;
            y.Aciklama2 = t.Aciklama2; //t parametreden gelen değerdir.
            repo.TUpdate(y);
            return RedirectToAction("Index");
        }
    }
}