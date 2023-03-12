using GeekShopping.Web.Services.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.Web.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICartService _cartService;

        public CartController(IProductService productService, ICartService cartService)
        {
            _productService = productService;
            _cartService = cartService;
        }

        public async Task<IActionResult> CartIndex()
        {
            var token = await HttpContext.GetTokenAsync("bearer_token");

            var userId = User.FindFirst("sub")?.Value;

            var response = await _cartService.FindCartByUserId(userId, token);

            if (response?.CartHeader != null)
            {
                foreach (var detail in response.CartDetails)
                {
                    response.CartHeader.PurchaseAmount += detail.Product.Price * detail.Count;
                }
            }

            return View(response);
        }

        public async Task<IActionResult> Remove(long id)
        {
            var token = await HttpContext.GetTokenAsync("bearer_token");

            var success = await _cartService.RemoveFromCart(id, token);

            if (success)
            {
                return RedirectToAction(nameof(CartIndex));
            }

            return View();
        }
    }
}
