using System;
using System.Collections.Generic;
using System.Linq;
using Autores.Domain;
using Autores.Data.Interface;
using Autors.Data.Context;
using Autores.Domain.Entities;

namespace Autores.Data.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly AutoresContext _db;

        public UsuarioRepository()
        {
            _db = new AutoresContext();
        }

        public Usuario ObterPorId(string id)
        {
            return _db.Usuarios.Find(id);
        }

        public IEnumerable<Usuario> ObterTodos()
        {
            return _db.Usuarios.ToList();
        }
        public void DesativarLock(string id)
        {
            _db.Usuarios.Find(id).LockoutEnabled = false;
            _db.SaveChanges();
        }

        public void Dispose()
        {
            _db.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}