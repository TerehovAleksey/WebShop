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
        [Range(typeof(DateTime), "1/1/1966", "1/1/2018", ErrorMessage = "Диаппазон дат 1966 - 2018")]
        [Display(Name = "Дата рождения")]
        public DateTime Birsday { get; set; }

        [DataType(DataType.Date)]
        [Range(typeof(DateTime), "1/1/2016", "1/1/2018", ErrorMessage = "Диаппазон дат 1966 - 2018")]
        [Display(Name = "Дата приёма на работу")]
        public DateTime HiredDate { get; set; }
    }

}
