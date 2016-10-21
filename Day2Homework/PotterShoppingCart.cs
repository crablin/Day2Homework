using System;
using System.Collections.Generic;
using System.Linq;

namespace Day2Homework
{
    public class PotterShoppingCart
    {
        private List<PotterBook> list;

        public PotterShoppingCart()
        {
            this.list = new List<PotterBook>();
        }

        public void Add(PotterBook book)
        {
            this.list.Add(book);
        }
        
        public object GetTotal()
        {
            return this.list.Sum(b => b.Price);
        }

        public void Add(List<PotterBook> books)
        {
            throw new NotImplementedException();
        }
    }
}