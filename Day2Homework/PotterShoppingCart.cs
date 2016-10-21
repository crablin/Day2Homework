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
            return GetPackageDiscountTotal().Sum();
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
        /// Gets the package discount total.
        /// </summary>
        /// <returns></returns>
        private IEnumerable<double> GetPackageDiscountTotal()
        {
            var groupCounts = this.list.GroupBy(b => b.Episode).Select(b => b.Count());

            var prevNum = 0;
            var packageNum = groupCounts.Min();
            var max = groupCounts.Max();

            while (packageNum <= max)
            {
                var package = this.list.GroupBy(b => b.Episode).Where(b => b.Count() >= packageNum);

                var episodeCount = package.Count();
                var total = package.Sum(b => b.First().Price);

                var rate = GetDiscountRate(episodeCount);
                yield return total * rate * (packageNum - prevNum);

                prevNum = packageNum;
                packageNum++;
            }

        }

    }
}