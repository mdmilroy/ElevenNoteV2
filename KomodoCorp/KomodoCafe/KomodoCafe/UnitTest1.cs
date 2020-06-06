using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KomodoCafe
{
    [TestClass]
    public class UnitTest1
    {
        MenuRepo menu = new MenuRepo();
        Menu item;
        List<Menu> currentItems = new List<Menu>();

        [TestInitialize]
        public void MyTestMethod()
        {
            item = new Menu(1, "cheeseburger", "burger with fries and drink", "bun, beef, pickles, cheese", 4.99);
            menu.CreateMenuItem(item);
        }

        [TestMethod]
        public void CreateShouldAddItem()
        {
            // Arrange


            // Act

            // Assert
            int actual = menu.ViewAllMenuItems(menu.menu).Count;
            Assert.AreEqual(1, actual);
        }

        [TestMethod]
        public void RemoveItems()
        {
            // Arrange
            Menu item2 = new Menu(2, "cheeseburger", "burger drink", "bun, beef, pickles, cheese", 3.99);
            menu.CreateMenuItem(item2);

            // Act
            menu.DeleteMenuItem(item);

            // Assert
            int actual = menu.ViewAllMenuItems(menu.menu).Count;
            Assert.AreEqual(1, actual);
        }
    }
}
