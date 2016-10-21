using System;
using System.Collections.Generic;
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

        /// <summary>
        /// 第一集買了一本，第二集也買了一本，價格應為100*2*0.95=190
        /// </summary>
        [TestMethod]
        public void 第一集買了一本第二集也買了一本_價格應為190()
        {
            var books = new List<PotterBook>
            {
                new PotterBook { Episode = 1, Price = 100 },
                new PotterBook { Episode = 2, Price = 100 }
            };

            var shoppingCart = new PotterShoppingCart();

            shoppingCart.Add(books);

            var expected = 190;
            var actual = shoppingCart.GetTotal();

            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        /// 一二三集各買了一本，價格應為100*3*0.9=270
        /// </summary>
        [TestMethod]
        public void 一二三集各買了一本_價格應為270()
        {
            var books = new List<PotterBook>
            {
                new PotterBook { Episode = 1, Price = 100 },
                new PotterBook { Episode = 2, Price = 100 },
                new PotterBook { Episode = 3, Price = 100 }
            };

            var shoppingCart = new PotterShoppingCart();

            shoppingCart.Add(books);

            var expected = 270;
            var actual = shoppingCart.GetTotal();

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// 一二三四集各買了一本，價格應為100*4*0.8=320
        /// </summary>
        [TestMethod]
        public void 一二三四集各買了一本_價格應為320()
        {
            var books = new List<PotterBook>
            {
                new PotterBook { Episode = 1, Price = 100 },
                new PotterBook { Episode = 2, Price = 100 },
                new PotterBook { Episode = 3, Price = 100 },
                new PotterBook { Episode = 4, Price = 100 }
            };

            var shoppingCart = new PotterShoppingCart();

            shoppingCart.Add(books);

            var expected = 320;
            var actual = shoppingCart.GetTotal();

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// 一次買了整套，一二三四五集各買了一本，價格應為100*5*0.75=375
        /// </summary>
        [TestMethod]
        public void 一次買了整套_一二三四五集各買了一本_價格應為375()
        {
            var books = new List<PotterBook>
            {
                new PotterBook { Episode = 1, Price = 100 },
                new PotterBook { Episode = 2, Price = 100 },
                new PotterBook { Episode = 3, Price = 100 },
                new PotterBook { Episode = 4, Price = 100 },
                new PotterBook { Episode = 5, Price = 100 }
            };

            var shoppingCart = new PotterShoppingCart();

            shoppingCart.Add(books);

            var expected = 375;
            var actual = shoppingCart.GetTotal();

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// 一二集各買了一本，第三集買了兩本，價格應為100*3*0.9 + 100 = 370
        /// </summary>
        [TestMethod]
        public void 一二集各買了一本_第三集買了兩本_價格應為370()
        {
            var books = new List<PotterBook>
            {
                new PotterBook { Episode = 1, Price = 100 },
                new PotterBook { Episode = 2, Price = 100 },
                new PotterBook { Episode = 3, Price = 100 },
                new PotterBook { Episode = 3, Price = 100 }
            };

            var shoppingCart = new PotterShoppingCart();

            shoppingCart.Add(books);

            var expected = 370;
            var actual = shoppingCart.GetTotal();

            Assert.AreEqual(expected, actual);
        }
        
    }
}
