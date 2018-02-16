using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoCrm.Infra.Data.Repository;
using Autores.Domain.Entities;
using Autores.Data.Interface;
using Autors.Data.Context;
using System.Collections;

namespace Autores.Data.Repository
{
    public class LivroRepositorio : RepositorioBase<Livro>, ILivroRepositorio
    {

 

        protected AutoresContext _db = new AutoresContext();

        public List<AutorLivro> LivrosPorAutor()
        {
            var query = (from a in _db.Livros join u in _db.Usuarios on

                        a.Id equals u.Id group a by new { a.Quantidade, u.Nome } into grp



                         select new AutorLivro
                         {

                             nome = grp.Key.Nome,
                             contaAutor = grp.Sum(a=>a.Quantidade),
                         });

            return query.ToList();
        
        }

        public List<Total> TotalCadastro()
        {

            var query = (from u in _db.Usuarios
                         join a in _db.Livros on

              u.Id equals a.Id
                         group a by new { a.Quantidade} into grp



               



                         select new Total
                         {

                             TotalAutores=grp.Select(x=>x.Id).Count(),
                             TotalLivros= grp.Sum(a => a.Quantidade),
                         });

            return query.ToList();

        
        }
    }
}
