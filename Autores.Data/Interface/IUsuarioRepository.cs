using System;
using System.Collections.Generic;
using Autores.Domain.Entities;

namespace Autores.Data.Interface
{
    public interface IUsuarioRepository : IDisposable
    {
        Usuario ObterPorId(string id);
        IEnumerable<Usuario> ObterTodos();
        void DesativarLock(string id);
    }
}