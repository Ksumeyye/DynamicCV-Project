using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class DeneyimController : Controller
    {
        // GET: Deneyim
        DeneyimRepository repo=new DeneyimRepository(); //generic repositorydeki değerleri burada kalıtım yaparak aldım.
        public ActionResult Index()
        {
            var deneyimler=repo.List();
            return View(deneyimler);
        }
        [HttpGet]
        public ActionResult DeneyimEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DeneyimEkle(TblDeneyimlerim p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index"); //Ekleme işleminip yapıp beni İndexe yönlendirir
        }
    }
}