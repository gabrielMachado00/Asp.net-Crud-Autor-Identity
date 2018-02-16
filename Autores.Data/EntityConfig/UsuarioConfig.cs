using System.Data.Entity.ModelConfiguration;
using Autores.Domain.Entities;

namespace Autores.Data.EntityConfig
{
    public class UsuarioConfig : EntityTypeConfiguration<Usuario>
    {
        public UsuarioConfig()
        {
            HasKey(u => u.Id);

       


            Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(256);



            Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(256);

            Property(u => u.UserName)
                .IsRequired()
                .HasMaxLength(256);

            ToTable("AspNetUsers");
        }
    }
}