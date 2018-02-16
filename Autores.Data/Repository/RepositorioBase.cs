using Autors.Data.Context;
using Autores.Data.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoCrm.Infra.Data.Repository
{
    public class RepositorioBase<TEntity> :IDisposable, IRepositorioBase<TEntity> where TEntity:class
    {


        public RepositorioBase()
        {

        }

        protected AutoresContext _db = new AutoresContext();

           public void Add(TEntity obj)
        {
            _db.Set<TEntity>().Add(obj);
           _db.SaveChanges();
        }

        public void Dispose()
        {
                   }

        public TEntity FindByid(int id)
        {
           return _db.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _db.Set<TEntity>().ToList();
        }

        public TEntity procuraId(int id)
        {
            return _db.Set<TEntity>().Find(id);
        }

       

        public void Remove(TEntity obj)
        {
            _db.Set<TEntity>().Remove(obj);
            
        }

        public void Update(TEntity obj)
        {
            _db.Entry<TEntity>(obj).State=EntityState.Modified;
            _db.SaveChanges();
        }

    
    }
}
