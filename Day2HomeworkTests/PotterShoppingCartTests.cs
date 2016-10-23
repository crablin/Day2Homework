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
            var book = new PotterBook { Episode = 1, Price = 100, Quantity = 1 };
            var shoppingCart = new PotterShoppingCart();

            shoppingCart.Add(book);
            var actual = shoppingCart.GetTotal();
            
            var expected = 100;
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
                new PotterBook { Episode = 1, Price = 100, Quantity = 1 },
                new PotterBook { Episode = 2, Price = 100, Quantity = 1 }
            };

            var shoppingCart = new PotterShoppingCart();

            shoppingCart.Add(books);
            var actual = shoppingCart.GetTotal();
            
            var expected = 190;
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
                new PotterBook { Episode = 1, Price = 100, Quantity = 1 },
                new PotterBook { Episode = 2, Price = 100, Quantity = 1 },
                new PotterBook { Episode = 3, Price = 100, Quantity = 1 }
            };

            var shoppingCart = new PotterShoppingCart();

            shoppingCart.Add(books);
            var actual = shoppingCart.GetTotal();
            
            var expected = 270;
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
                new PotterBook { Episode = 1, Price = 100, Quantity = 1},
                new PotterBook { Episode = 2, Price = 100, Quantity = 1},
                new PotterBook { Episode = 3, Price = 100, Quantity = 1},
                new PotterBook { Episode = 4, Price = 100, Quantity = 1}
            };

            var shoppingCart = new PotterShoppingCart();

            shoppingCart.Add(books);
            var actual = shoppingCart.GetTotal();
            
            var expected = 320;
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
                new PotterBook { Episode = 1, Price = 100, Quantity = 1},
                new PotterBook { Episode = 2, Price = 100, Quantity = 1},
                new PotterBook { Episode = 3, Price = 100, Quantity = 1},
                new PotterBook { Episode = 4, Price = 100, Quantity = 1},
                new PotterBook { Episode = 5, Price = 100, Quantity = 1}
            };

            var shoppingCart = new PotterShoppingCart();

            shoppingCart.Add(books);
            var actual = shoppingCart.GetTotal();
            
            var expected = 375;
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
                new PotterBook { Episode = 1, Price = 100, Quantity = 1},
                new PotterBook { Episode = 2, Price = 100, Quantity = 1},
                new PotterBook { Episode = 3, Price = 100, Quantity = 2},
            };

            var shoppingCart = new PotterShoppingCart();

            shoppingCart.Add(books);
            var actual = shoppingCart.GetTotal();
            
            var expected = 370;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// 第一集買了一本，第二三集各買了兩本，價格應為100*3*0.9 + 100*2*0.95 = 460
        /// </summary>
        [TestMethod]
        public void 第一集買了一本第二三集各買了兩本_價格應為460()
        {
            var books = new List<PotterBook>
            {
                new PotterBook { Episode = 1, Price = 100, Quantity = 1 },
                new PotterBook { Episode = 2, Price = 100, Quantity = 2 },
                new PotterBook { Episode = 3, Price = 100, Quantity = 2 }
            };

            var shoppingCart = new PotterShoppingCart();

            shoppingCart.Add(books);
            var expected = 460;
            
            var actual = shoppingCart.GetTotal();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// 買了三套，價格應為100*5*0.75*3 = 1125
        /// </summary>
        [TestMethod]
        public void 買了三套_價格應為1125()
        {
            var books = new List<PotterBook>
            {
                new PotterBook { Episode = 1, Price = 100, Quantity = 3 },
                new PotterBook { Episode = 2, Price = 100, Quantity = 3 },
                new PotterBook { Episode = 3, Price = 100, Quantity = 3 },
                new PotterBook { Episode = 4, Price = 100, Quantity = 3 },
                new PotterBook { Episode = 5, Price = 100, Quantity = 3 }
            };

            var shoppingCart = new PotterShoppingCart();
            shoppingCart.Add(books);
            var actual = shoppingCart.GetTotal();

            var expected = 1125;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// 買了三套，價格應為100*5*0.75*3 = 1125
        /// </summary>
        [TestMethod]
        public void 沒買東西_價格應為0()
        {
            var shoppingCart = new PotterShoppingCart();

            var actual = shoppingCart.GetTotal();

            var expected = 0;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// 第一本買了一本二三四五買了一百套，價格應為100*5*0.75 + 100*4*0.8*99 = 32055
        /// </summary>
        [TestMethod]
        public void 第一本買了一本二三四五買了一百套_價格應為32055()
        {
            var books = new List<PotterBook>
            {
                new PotterBook { Episode = 1, Price = 100, Quantity = 1 },
                new PotterBook { Episode = 2, Price = 100, Quantity = 100 },
                new PotterBook { Episode = 3, Price = 100, Quantity = 100 },
                new PotterBook { Episode = 4, Price = 100, Quantity = 100 },
                new PotterBook { Episode = 5, Price = 100, Quantity = 100 }
            };

            var shoppingCart = new PotterShoppingCart();
            shoppingCart.Add(books);
            var actual = shoppingCart.GetTotal();

            var expected = 32055;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// 第一本買了一千本二三四五買了一本，價格應為100*5*0.75 + 100*999 = 100275
        /// </summary>
        [TestMethod]
        public void 第一本買了一千本二三四五買了一本_價格應為100275()
        {
            var books = new List<PotterBook>
            {
                new PotterBook { Episode = 1, Price = 100, Quantity = 1000 },
                new PotterBook { Episode = 2, Price = 100, Quantity = 1 },
                new PotterBook { Episode = 3, Price = 100, Quantity = 1 },
                new PotterBook { Episode = 4, Price = 100, Quantity = 1 },
                new PotterBook { Episode = 5, Price = 100, Quantity = 1 }
            };

            var shoppingCart = new PotterShoppingCart();
            shoppingCart.Add(books);
            var actual = shoppingCart.GetTotal();

            var expected = 100275;
            Assert.AreEqual(expected, actual);
        }
    }
}
