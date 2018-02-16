
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autores.Data.Interface
{
    public interface IRepositorioBase<TEntity> where TEntity:class
    {

        void Add(TEntity obj);
        TEntity FindByid(int id);
        void Update(TEntity obj);
        IEnumerable<TEntity> GetAll();
        void Remove(TEntity obj);
        void Dispose();
  


    }
}
