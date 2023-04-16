using Admin.Models.Foods;

namespace Admin.Models.Carts
{
    public class Cart
    {
        private List<CartItem> ItemCollection = new List<CartItem>();
        public virtual IEnumerable<CartItem> Items => ItemCollection;

        public virtual void AddItem(Food food, int quanity)
        {
            CartItem Item = ItemCollection.FirstOrDefault(p => p.food.Id == food.Id)!;
            if (Item == null)
            {
                ItemCollection.Add(new CartItem
                {
                    food = food,
                    Quantity = quanity
                });
            }
            else
            {
                Item.Quantity += quanity;
            }
        }

        public virtual void RemoveItem(Food food) =>
            ItemCollection.RemoveAll(l => l.food.Id == food.Id);

        public virtual double ComputeTotalValue() => ItemCollection.Sum(l => l.food.Price * l.Quantity);

        // write ComputeTotalValue function return decimal and using TryParse() to convert string to decimal

        public virtual void Clear() => ItemCollection.Clear();
        public virtual void SetQuantity(Food food, int quantity)
        {
            CartItem Item = ItemCollection.FirstOrDefault(p => p.food.Id == food.Id)!;
            if (Item != null)
            {
                Item.Quantity = quantity;
            }
        }
    }
    public class CartItem
    {
        public int CartItemId { get; set; }

        public Food? food { get; set; }

        public int Quantity { get; set; }
    }
}
