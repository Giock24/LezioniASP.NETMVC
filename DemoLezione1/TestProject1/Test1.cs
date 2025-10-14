using DemoLezione1.Models;

namespace TestProject1
{
    [TestClass]
    public sealed class Test1
    {
        [TestMethod]
        public void TestiamoIlMessaggioDelMattino()
        {
            var w = new WelcomeMessage(new MorningClock());

            var excpected = "xGood morning!";
            var calculated = w.Welcome();
            Assert.AreEqual(excpected, calculated);
        }

        [TestMethod]
        public void TestiamoIlMessaggioDelPomeriggio()
        {
            var w = new WelcomeMessage(new AfternoonClock());

            var excpected = "Good afternoon!";
            var calculated = w.Welcome();
            Assert.AreEqual(excpected, calculated);
        }
    }
}
