
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autores.Data.Interface;
using Autores.Domain.Entities;


namespace Autores.Data.Interface
{
   public interface IAutorRepositorio:IRepositorioBase<Autor>,IDisposable
    {
    }
}
