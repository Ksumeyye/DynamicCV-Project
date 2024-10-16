using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;

namespace MvcCv.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        DbCvEntities db=new DbCvEntities(); //db isimli nesne türettim.
        public ActionResult Index()
        {
            var degerler= db.TblHakkimda.ToList(); //degerler adında degisken tanımladım, db.nesnesi içindeki tblhakkimda içinde olan propertyleri bana listelesin diye.
            return View(degerler); //geriye bana degerleri döndur.
        }
        public PartialViewResult Deneyim()
        {
            var deneyimler=db.TblDeneyimlerim.ToList();
            return PartialView(deneyimler);
        }
        public PartialViewResult Egitim()
        {
            var egitimler=db.TblEgitimlerim.ToList();
            return PartialView(egitimler);
        }
        public PartialViewResult Yetenek()
        {
            var yetenekler=db.TblYeteneklerim.ToList();
            return PartialView(yetenekler);
        }
    }
}