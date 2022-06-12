using API.Entities.Common;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace API_Viceri.Models
{
    public class UserModelDto : IBaseUser
    {
        [Required(ErrorMessage = "Nome vazio")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Email vazio")]
        [EmailAddress(ErrorMessage = "Email Inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Senha vazia")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "CPF vazio")]
        [MinLength(11, ErrorMessage = "CPF Invalido, insira os 11 numeros"), MaxLength(11, ErrorMessage = "CPF Invalido, insira somente 11 numeros")]
        
        public string Cpf { get; set; }

        [Required(ErrorMessage = "Data de nascimento vazia")]
        public string DataNasc { get; set; }
    }
}
