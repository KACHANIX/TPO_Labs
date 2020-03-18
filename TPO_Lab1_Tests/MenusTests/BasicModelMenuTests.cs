using Microsoft.VisualStudio.TestTools.UnitTesting;
using TPO_Lab1.Menus.BasicModelMenu;
using TPO_Lab1.Menus.DefaultMenu;

namespace TPO_Lab1_Tests.MenusTests
{
    [TestClass]
    public class MenuTests
    {
        [TestMethod]
        public void AddItemToBasicModelMenu_BasicModelMenuItemsCountIncremented()
        {
            var menu = new BasicModelMenu();
            menu.AddItem(null, (a) => true, null, null);
            Assert.AreEqual(1, menu._items.Count);
        }

        [TestMethod]
        public void AddItemToDefaultMenu_DefaultMenuItemsCountIncremented()
        {
            var menu = new DefaultMenu();
            menu.AddItem(null, () => true, null);
            menu.AddItem(null, () => true, null);
            Assert.AreEqual(2, menu._items.Count);
        }
    }
}