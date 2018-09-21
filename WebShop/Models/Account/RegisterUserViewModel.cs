using System.ComponentModel.DataAnnotations;

namespace WebShop.Models.Account
{
    public class RegisterUserViewModel
    {
        [Display(Name = "Имя пользователя")]
        [Required, MaxLength(256)]
        public string UserName { get; set; }

        [Display(Name = "Пароль")]
        [Required, DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Подтверждение пароля")]
        //[DataType(DataType.Password), Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Запомнить?")]
        public bool RememberMe { get; set; }

        public string ReturnUrl { get; set; }
    }
}
