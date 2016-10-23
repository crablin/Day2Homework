using System;
using System.Collections.Generic;
using System.Linq;


namespace Day2Homework
{
    public class PotterShoppingCart
    {
        private List<PotterBook> list;

        /// <summary>
        /// Initializes a new instance of the <see cref="PotterShoppingCart"/> class.
        /// </summary>
        public PotterShoppingCart()
        {
            this.list = new List<PotterBook>();
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

            return GetPackageByQuantity()
                .Sum(package => package.Sum(b => b.Price) * GetDiscountRate(package.Count()));
        }

        /// <summary>
        /// Gets the discount rate.
        /// </summary>
        /// <param name="episodeCount">episode count</param>
        /// <returns></returns>
        private double GetDiscountRate(int episodeCount)
        {
            switch (episodeCount)
            {
                case 2: 
                    return 0.95;
                case 3:
                    return 0.9;
                case 4:
                    return 0.8;
                case 5:
                    return 0.75;
                default:
                    return 1;

            }
            
        }

        /// <summary>
        /// Gets the package by quantity.
        /// </summary>
        /// <returns></returns>
        private IEnumerable<IEnumerable<PotterBook>> GetPackageByQuantity()
        {
            var packageIndex = 1;
            var max = this.list.Max(b => b.Quantity);

            while (packageIndex <= max)
            {
                yield return this.list.Where(b => b.Quantity >= packageIndex);
                packageIndex++;
            }
        }
    }
}