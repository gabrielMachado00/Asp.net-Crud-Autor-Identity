using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autores.Domain.Entities
{
    public class Livro
    {


        public Livro(int idLivro, string Id, string titulo, string genero, int quantidade)
        {
            IdLivro = idLivro;
            this.Id = Id;
            Titulo = titulo;
            Genero = genero;
            Quantidade = quantidade;
        }

        public Livro()
        {
                
        }

      

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdLivro { get; set; }
              // Foreign key 
        [Display(Name = "AspNetUsers")]
        public string Id{ get; set; }

        [ForeignKey("Id")]
        public virtual Usuario usuarios { get; set; }
        public string Titulo { get; set; }

        public string Genero{ get; set; }

        [Display(Name = "Quantidade de Livros")]
        public int Quantidade { get; set; }
    }
}
