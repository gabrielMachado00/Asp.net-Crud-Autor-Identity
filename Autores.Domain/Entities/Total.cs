using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autores.Domain.Entities
{
    public class Total
    {

        [Display(Name = "Total De Livros")]
        public int TotalLivros { get; set; }
        [Display(Name = "Total De Autores")]
        public int TotalAutores { get; set; }
    }
}
