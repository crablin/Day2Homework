using System;
using Day2Homework;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Day2HomeworkTests
{
    [TestClass]
    public class PotterShoppingCartTests
    {
        /// <summary>
        /// 第一集買了一本，其他都沒買，價格應為100*1=100元
        /// </summary>
        [TestMethod]
        public void 第一集買了一本_價格應為100()
        {
            var book = new PotterBook { Episode = 1, Price = 100 };
            var shoppingCart = new PotterShoppingCart();

            shoppingCart.Add(book);

            var expected = 100;
            var actual = shoppingCart.GetTotal();

            Assert.AreEqual(expected, actual);

        }

        
    }
}
