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
            var rate = GetDiscountRate();

            return this.list.Sum(b => b.Price) * rate;
        }

        /// <summary>
        /// Gets the discount rate.
        /// </summary>
        /// <returns></returns>
        private double GetDiscountRate()
        {
            switch (this.list.Count)
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

    }
}