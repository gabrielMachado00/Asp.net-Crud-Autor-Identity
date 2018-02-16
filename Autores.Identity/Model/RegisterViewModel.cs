using System.ComponentModel.DataAnnotations;

namespace Autores.Identity.Model { 
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }


        [Required]
        [StringLength(15, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
       
        [Display(Name = "CPF")]
        public string CPF{ get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letras neste campo")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letras neste campo")]
        [Display(Name = "Sobrenome")]
        public string Sobrenome { get; set; }


        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "A confirmação do Password não confere.")]
        public string ConfirmPassword { get; set; }
    }
}