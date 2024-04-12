using Microsoft.AspNetCore.Mvc;
using _2_4AurorasBricks2.Models;

namespace _2_4AurorasBricks2.Components
{
    public class CartSummaryViewComponent : ViewComponent
    {
        private Cart cart;
        public CartSummaryViewComponent(Cart cartService)
        {
            cart = cartService;
        }

        public IViewComponentResult Invoke()
        {
            return View(cart);
        }
    }
}