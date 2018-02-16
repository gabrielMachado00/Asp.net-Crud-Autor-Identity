
using Autores.Domain.Entities;
using Autors.Data.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autores.Data
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    sealed public class CPFAttribute : ValidationAttribute
    {
        private AutoresContext context = new AutoresContext();

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null) return null;

            int soma = 0, resto = 0;
            string digito;
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            string CPF = value.ToString().Replace(".", "").Replace("-", "");

            if (CPF.Length != 11)
                return new ValidationResult("CPF Inválido.");

            if (Convert.ToUInt64(CPF) % 11111111111 == 0)
                return new ValidationResult("CPF Inválido.");

            if (validationContext.ObjectInstance.GetType() == typeof(Usuario))
            {
                var model = (Usuario)validationContext.ObjectInstance;

                if (context.Usuarios
                  .Any(p => (p.CPF == CPF) && (p.Id != model.Id)))
                {
                    var message = FormatErrorMessage("CPF já está cadastrado.");
                    return new ValidationResult(message);
                }
            }

            string tempCpf = CPF.Substring(0, 9);

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;

            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

            resto = soma % 11;

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = digito + resto.ToString();

            if (CPF.EndsWith(digito))
                return null;
            else
                return new ValidationResult("CPF Inválido.");
        }

        public override string FormatErrorMessage(string name)
        {
            return name;
        }
    }
}