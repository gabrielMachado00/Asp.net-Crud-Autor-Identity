using System.Data.Entity;
using Autores.Domain.Entities;

using System.Data.Entity.ModelConfiguration.Conventions;

using Autores.Data.EntityConfig;

namespace Autors.Data.Context
{
    public class AutoresContext : DbContext
    {
        public AutoresContext()
            : base("DefaultConnection")
        {

        }




        static AutoresContext()
        {
            Database.SetInitializer<AutoresContext>(null);
        }



        public DbSet<Livro> Livros { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Properties().Where(p => p.Name == p.ReflectedType.Name + "Id").Configure(p => p.IsKey());

            modelBuilder.Configurations.Add(new UsuarioConfig());


            base.OnModelCreating(modelBuilder);

        }
    }
}