using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace WebShop.Areas.Admin.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Section { get; set; }

        [Required]
        public string Brand { get; set; }

        [Required, DataType(DataType.Currency)]
        public decimal Price { get; set; }

        public string ImagePath { get; set; }
        public IFormFile Image { get; set; }
    }
}
