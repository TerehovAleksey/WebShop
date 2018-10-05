using System.ComponentModel.DataAnnotations;

namespace WebShop.Domain.Models.Account
{
    public class RegisterUserViewModel
    {       
        [Required, MaxLength(256)]
        [Display(Name = "Имя пользователя")]
        public string UserName { get; set; }
        
        [Required, DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }
       
        [DataType(DataType.Password), Compare(nameof(Password))]
        [Display(Name = "Подтверждение пароля")]
        public string ConfirmPassword { get; set; }
    }
}
