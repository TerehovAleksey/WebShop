using System.ComponentModel.DataAnnotations;

namespace WebShop.Models.Users
{
    public class EditUserViewModel
    {
        public string Id { get; set; }

        [Display(Name ="Имя пользователя")]
        public string UserName { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Номер телефона")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
    }
}
