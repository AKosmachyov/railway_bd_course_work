using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models.AccountViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Поле e-mail обязательно для заполнения")]
        [EmailAddress(ErrorMessage = "Неверный e-mail")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Поле пароль обязательно для заполнения")]
        [StringLength(100, ErrorMessage = "Пароль должен быть больше {2} символом и меньше {1} символов.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают.")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Поле имя обязательно для заполнения")]
        [DataType(DataType.Text)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Поле Фамилия обязательно для заполнения")]
        [DataType(DataType.Text)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Поле отчество обязательно для заполнения")]
        [DataType(DataType.Text)]
        public string MiddleName { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Поле серия паспорта обязательно для заполнения")]
        [StringLength(10, ErrorMessage = "Серия папорта не должена быть больше {2} символом и меньше {1} символов.", MinimumLength = 5)]
        public string PassportSerial { get; set; }
    }
}
