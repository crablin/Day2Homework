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
            // 取得需計算的數列並排序 ex. [1, 200, 200, 3, 4] => [1, 3, 4, 200]
            var packageQuantities = this.list.Select(b => b.Quantity).Distinct().OrderBy(b => b);

            // 依數列計算每個數量的價格 loop n = 1 ~ 5
            foreach (var packageQuantity in packageQuantities)
            {
                // 取得指定數量的書本清單
                var packageBooks = this.list.Where(b => b.Quantity >= packageQuantity);

                var sum = packageBooks.Sum(b => b.Price);
                var episodeCount = packageBooks.Count();
                var rate = discountRates[episodeCount];
                var packageRange = packageQuantity - prevQuantity;
                
                // 回傳此數量計算折扣價格：書本總價 x 依購買集數取得折扣 x 書本套數
                yield return sum * rate * packageRange;
                prevQuantity = packageQuantity;
            }
        }
    }
}