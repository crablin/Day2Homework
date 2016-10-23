using System;
using System.Collections.Generic;
using System.Linq;


namespace Day2Homework
{
    public class PotterShoppingCart
    {
        private Dictionary<int, double> discountRates;
        private List<PotterBook> list;

        /// <summary>
        /// Initializes a new instance of the <see cref="PotterShoppingCart"/> class.
        /// </summary>
        public PotterShoppingCart()
        {
            this.list = new List<PotterBook>();
            this.discountRates = new Dictionary<int, double>()
            {
                { 1, 1 },
                { 2, 0.95 },
                { 3, 0.9 },
                { 4, 0.8 },
                { 5, 0.75 }
            };
        }

        /// <summary>
        /// Adds the specified book.
        /// </summary>
        /// <param name="book">The book.</param>
        public void Add(PotterBook book)
        {
            this.list.Add(book);
        }

        /// <summary>
        /// Adds the specified books.
        /// </summary>
        /// <param name="books">The books.</param>
        public void Add(List<PotterBook> books)
        {
            this.list.AddRange(books);
        }

        /// <summary>
        /// Gets the total.
        /// </summary>
        /// <returns></returns>
        public double GetTotal()
        {
            if (this.list.Count == 0)
                return 0;

            return GetPackageTotalDiscounts().Sum();
        }
        

        /// <summary>
        /// Gets the package by quantity.
        /// </summary>
        /// <returns></returns>
        private IEnumerable<double> GetPackageTotalDiscounts()
        {
            var prevQuantity = 0;
            var packageQuantities = this.list.Select(b => b.Quantity).Distinct().OrderBy(b => b);

            foreach (var packageQuantity in packageQuantities)
            {
                var packageBooks = this.list.Where(b => b.Quantity >= packageQuantity);

                var sum = packageBooks.Sum(b => b.Price);
                var episodeCount = packageBooks.Count();
                var rate = discountRates[episodeCount];
                var packageRange = packageQuantity - prevQuantity;

                yield return sum * rate * packageRange;
                prevQuantity = packageQuantity;
            }
        }
    }
}