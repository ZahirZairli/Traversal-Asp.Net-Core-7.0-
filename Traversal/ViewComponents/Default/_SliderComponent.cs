using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.ViewComponents.Default
{
    public class _SliderComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
