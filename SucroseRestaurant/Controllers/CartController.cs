using Admin.Infrastruture;
using Admin.Models.Carts;
using Admin.Models.Foods;
using Admin.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Admin.Controllers
{
    public class CartController : Controller
    {
        private readonly IFoodRepository foodRepository;

        public CartController(IFoodRepository foodRepository)
        {
            this.foodRepository = foodRepository;
        }

        public IActionResult Cart(string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = GetCart(),
                ReturnUrl = returnUrl
            });
        }
        public RedirectToActionResult AddToCart(int id, string returnUrl)
        {
            Food product = foodRepository.GetAll().FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                Cart cart = GetCart();
                cart.AddItem(product, 1);
                SaveCart(cart);
            }

            return RedirectToAction("Cart", new { returnUrl });
        }

        public RedirectToActionResult RemoveFromCart(int id, string returnUrl)
        {
            Food product = foodRepository.GetAll().FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                Cart cart = GetCart();
                cart.RemoveItem(product);
                SaveCart(cart);
            }

            return RedirectToAction("Cart", new { returnUrl });
        }

        public RedirectToActionResult Clear(string returnUrl)
        {
            Cart cart = GetCart();
            cart.Clear();
            SaveCart(cart);
            return RedirectToAction("Cart", new { returnUrl });
        }

        private Cart GetCart()
        {
            Cart cart = HttpContext.Session.GetJson<Cart>("Cart");
            if (cart == null)
            {
                cart = new Cart();
                SaveCart(cart);
            }
            return cart;
        }

        private void SaveCart(Cart cart)
        {
            HttpContext.Session.SetJson("Cart", cart);
        }
        private void UpdateQuantity(int id, int quantity = 1)
        {
            Food food = foodRepository.GetAll().FirstOrDefault(p => p.Id == id);
            if (food != null)
            {
                Cart cart = GetCart();
                cart.SetQuantity(food, quantity);
                SaveCart(cart);
            }
        }
    }
}
