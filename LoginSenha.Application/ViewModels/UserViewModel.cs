using System;
using System.ComponentModel.DataAnnotations;

namespace LoginSenha.Application.ViewModels
{
    public class UserViewModel: EntityViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
