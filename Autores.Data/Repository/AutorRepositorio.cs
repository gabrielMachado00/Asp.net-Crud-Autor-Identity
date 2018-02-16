using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoCrm.Infra.Data.Repository;
using Autores.Domain.Entities;
using Autores.Data.Interface;

namespace Autores.Data.Repository
{
    public class AutorRepositorio : RepositorioBase<Autor>,IAutorRepositorio
    {
    }


}
