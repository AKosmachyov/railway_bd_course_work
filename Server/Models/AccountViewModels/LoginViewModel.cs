using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models.AccountViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Поле e-mail обязательно для заполнения")]
        [EmailAddress(ErrorMessage = "Неверный e-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Поле пароль обязательно для заполнения")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Запомнить меня?")]
        public bool RememberMe { get; set; }
    }
}
