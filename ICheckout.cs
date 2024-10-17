using System;

namespace CheckOutSystem
{
    public interface ICheckout
    {
        /// <summary>
        /// Scan the Items.
        /// </summary>
        /// <param name="item">item to be scanned</param>
        void Scan(string item);

        /// <summary>
        /// Get the total price of the scanned items.
        /// </summary>
        /// <returns>total price as integer</returns>
        int GetTotalPrice();
    }
}
