using Microsoft.VisualStudio.TestTools.UnitTesting;
using TPO_Lab1.MenuFunctions;

namespace TPO_Lab1_Tests.MenuFunctionsTests
{
    [TestClass]
    public class ExitFunctionsTests
    {
        private readonly ExitFunctions _exitFunctions;

        public ExitFunctionsTests()
        {
            _exitFunctions = new ExitFunctions();
        }

        [TestMethod]
        public void ExitFunctionParameterless_ReturnsFalse()
        {
            bool result = _exitFunctions.Exit();
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void ExitFunction_ReturnsFalse()
        {
            bool result = _exitFunctions.Exit("");
            Assert.AreEqual(false, result);
        }
    }
}