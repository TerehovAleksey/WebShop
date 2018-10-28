using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebShop.ViewComponents
{
    public class BreadCrumbsViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
