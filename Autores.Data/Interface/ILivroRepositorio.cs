using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autores.Data.Interface;
using Autores.Domain.Entities;
using System.Collections;

namespace Autores.Data.Interface
{   
    public interface ILivroRepositorio:IRepositorioBase<Livro>,IDisposable
    {


List<AutorLivro> LivrosPorAutor();
        List<Total> TotalCadastro();

    }
}
