using Admin.Infrastruture;
using Admin.Models.Foods;
using Newtonsoft.Json;

namespace Admin.Models.Carts
{
    public class SessionCart : Cart
    {
        public static Cart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            SessionCart cart = session?.GetJson<SessionCart>("Cart") ?? new SessionCart();
            cart.Session = session;
            return cart;
        }

        [JsonIgnore] public ISession Session { get; set; }

        public override void AddItem(Food food, int quantity)
        {
            base.AddItem(food, quantity);
            Session.SetJson("Cart", this);
        }

        public override void RemoveItem(Food food)
        {
            base.RemoveItem(food);
            Session.SetJson("Cart", this);
        }

        public override void Clear()
        {
            base.Clear();
            Session.Remove("Cart");
        }
    }
}
