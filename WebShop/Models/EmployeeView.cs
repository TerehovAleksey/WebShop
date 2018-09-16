using System;
using System.ComponentModel.DataAnnotations;

namespace WebShop.Models
{
    public class EmployeeView
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Фамилия ​ является​ ​ обязательной")]
        [StringLength(maximumLength:50, MinimumLength =2, ErrorMessage = "В фамилии может быть от 2 до 50 символов")]
        [Display(Name = "Фамилия")]
        public string LastName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Имя ​ является​ ​ обязательным")]
        [StringLength(maximumLength: 50, MinimumLength = 2, ErrorMessage = "В имени может быть от 2 до 50 символов")]
        [Display(Name = "Имя")]
        public string FirstName { get; set; }

        [Display(Name = "Отчество")]
        public string Patronymic { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Дата рождения")]
        public DateTime Birsday { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Дата приёма на работу")]
        public DateTime HiredDate { get; set; }
    }

}
