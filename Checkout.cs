  
    namespace CheckOutSystem
{
    public class Checkout : ICheckout
    {
        private readonly Dictionary<string, (int unitPrice, int? specialQuantity, int? specialPrice)> _pricing;
        private readonly Dictionary<string, int> _scannedItems = new();

        /// <summary>
        /// Constructor for the Checkout class.
        /// </summary>
        /// <param name="pricing">pricing dictionary</param>
        public Checkout(Dictionary<string, (int unitPrice, int? specialQuantity, int? specialPrice)> pricing)
        {
            _pricing = pricing;
        }

        /// <summary>
        /// Method to Scan the cart items.
        /// </summary>
        /// <param name="item">items</param>
        public void Scan(string item)
        {
            _scannedItems[item] = _scannedItems.GetValueOrDefault(item, 0) + 1;
        }

        /// <summary>
        /// Method to get the total price.
        /// </summary>
        /// <returns>total price of the cart items.</returns>
            public int GetTotalPrice()
        {
            int totalPrice = 0;
            foreach (var item in _scannedItems)
            {
                var (unitPrice, specialQuantity, specialPrice) = _pricing[item.Key];
                var quantity = item.Value;
                if (specialQuantity.HasValue && specialPrice.HasValue)
                {
                    totalPrice += (quantity / specialQuantity.Value) * specialPrice.Value;
                    totalPrice += (quantity % specialQuantity.Value) * unitPrice;
                }
                else
                {
                    totalPrice += quantity * unitPrice;
                }
            }
            return totalPrice;
        }
    }
}