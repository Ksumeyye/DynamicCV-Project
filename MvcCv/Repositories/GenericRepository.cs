using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using MvcCv.Models.Entity;
namespace MvcCv.Repositories
{
    public class GenericRepository<T> where T : class, new()//T değeri bizim göndereceğimiz sınıflardır.
    {
        DbCvEntities db = new DbCvEntities();

        public List<T> List() //İsmi List olan method tanımladım.
        {
            return db.Set<T>().ToList(); //Bana geriye T'den gelen değeri liste olarak döndürür.
        }
        public void TAdd(T p)
        {
            db.Set<T>().Add(p); //Parametreden gelen değeri ekler.
            db.SaveChanges(); //Değişiklikleri kaydedip bunu döndürür.
        }
        public void TDelete(T p)
        {
            db.Set<T>().Remove(p);// T parametresi p'den gelen değeri siler.
            db.SaveChanges();
        }
        public T TGet(int id) //id'ye göre getirir
        {
            return db.Set<T>().Find(id);
        }
        public void TUpdate(T p) //Direkt değişiklikleri kaydetmesi için
        {
            db.SaveChanges();
        }
        public T Find(Expression<Func<T,bool>>where)
        {
            return db.Set<T>().FirstOrDefault(where);
        }
    }
}