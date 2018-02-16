using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autores.Domain.Entities
{
    public class Autor
    {
        public Autor()
        {

        }

        public Autor(int idAutor, string Id, string nome, string sobrenome, string cPF)
        {
            IdAutor = idAutor;
            this.Id= Id;
            Nome = nome;
            Sobrenome = sobrenome;
            CPF = cPF;
        }

        [Key]
        public int IdAutor  { get; set; }
        public string Id{ get; set; }
                public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string CPF { get; set; }
    }
}
