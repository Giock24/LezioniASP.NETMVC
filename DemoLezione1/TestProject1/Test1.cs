using DemoLezione1.Models;

namespace TestProject1
{
    [TestClass]
    public sealed class Test1
    {
        [TestMethod]
        public void TestiamoCheAlMattinoIlMessaggioEBuongiorno()
        {
            var clock = new MorningClock();
            var w = new WelcomeMessage(clock);
            var expected = "Good morning!";
            var calculated = w.Welcome();   
            Assert.AreEqual(expected, calculated);
        }

        [TestMethod]
        public void TestiamoCheAlPomeriggioIlMessaggioEBuonPomeriggio()
        {
            var clock = new AfternoonClock();
            var w = new WelcomeMessage(clock);
            var expected = "Good afternoon!";
            var calculated = w.Welcome();
            Assert.AreEqual(expected, calculated);
        }

    }
}
