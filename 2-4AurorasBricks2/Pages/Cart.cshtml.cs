using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Cryptography.X509Certificates;
using _2_4AurorasBricks2.Infrastructure;
using _2_4AurorasBricks2.Models;
using Microsoft.AspNetCore.Http;

namespace _2_4AurorasBricks2.Pages
{
    public class CartModel : PageModel
    {
        private ILegoRepository _repo;
        public Cart Cart { get; set; }
        public CartModel(ILegoRepository temp, Cart cartService)
        {
            _repo = temp;
            Cart = cartService;
        }

        public string ReturnUrl { get; set; } = "/";
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
            //Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
        }

        public IActionResult OnPost(int productId, string returnUrl)
        {
            Product proj = _repo.Products
                .FirstOrDefault(x => x.ProductId == productId);

            if (proj != null)
            {
                Cart.AddItem(proj, 1);
            }

            return RedirectToPage(new { returnUrl = returnUrl });
        }

        public IActionResult OnPostRemove(int productId, string returnUrl)
        {
            Cart.RemoveLine(Cart.Lines.First(x => x.Product.ProductId == productId).Product);

            return RedirectToPage(new { returnUrl = returnUrl });
        }
    }
}