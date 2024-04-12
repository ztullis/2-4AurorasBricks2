namespace _2_4AurorasBricks2.Models
{
    public class Cart
    {
        public List<CartLine> Lines { get; set; } = new List<CartLine>();
        public virtual void AddItem(Product prod, int quantity)
        {
            CartLine? line = Lines
                .Where(x => x.Product.ProductId == prod.ProductId)
                .FirstOrDefault(); // We are really just looking for one entry, which is why we use this

            //Has this item already been added to our cart?
            if (line == null) //If nothing is in the cart
            {
                Lines.Add(new CartLine
                {
                    Product = prod,
                    Quantity = quantity
                });
            }
            else //f something HAS been added to our cart already before this one
            {
                line.Quantity += quantity;
            }
        }

        public virtual void RemoveLine(Product prod) => Lines.RemoveAll(x => x.Product.ProductId == prod.ProductId);

        public virtual void Clear() => Lines.Clear();

        public decimal CalculateTotal() => Lines.Sum(x => 25 * x.Quantity);
        //THIS BELOW is another way to do the above lambda function.

        //public decimal CalculateTotal()
        //{
        //    var totalPrice = Lines.Sum(x => 25 * x.Quantity);

        //    return totalPrice;
        //}


        //Each line consists of these three things
        public class CartLine
        {
            public int CartLineId { get; set; }
            public Product Product { get; set; }
            public int Quantity { get; set; } //Quantity we are ordering for each of these
        }
    }
}
