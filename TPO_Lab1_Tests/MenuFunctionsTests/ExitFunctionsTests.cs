using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TPO_Lab1.MenuFunctions;

namespace TPO_Lab1_Tests.MenuFunctionsTests
{
    [TestClass]
    public class ExitFunctionsTests
    {
        [TestMethod]
        public void ExitFunctionParameterless_ReturnsFalse()
        {
            bool result = ExitFunctions.Exit();
            Assert.AreEqual(false, result);
        }
        [TestMethod]
        public void ExitFunction_ReturnsFalse()
        {
            bool result = ExitFunctions.Exit("");
            Assert.AreEqual(false, result);
        }
    }
}
