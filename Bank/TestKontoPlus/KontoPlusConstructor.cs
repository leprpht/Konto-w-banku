namespace TestKontoPlus
{
    [TestClass]
    public sealed class KontoPlusConstructor
    {
        [TestMethod]
        public void Constructor()
        {
            Bank.KontoPlus konto = new Bank.KontoPlus("aaa", 50, 100);
            Assert.AreEqual("aaa", konto.Nazwa);
            Assert.AreEqual(100, konto.Bilans);
            Assert.AreEqual(50, konto.LimitJednorazowy);
            Assert.IsFalse(konto.Zablokowane);
        }
        [TestMethod]
        public void ConstructorNoBalance()
        {
            Bank.KontoPlus konto = new Bank.KontoPlus("aaa", 50);
            Assert.AreEqual("aaa", konto.Nazwa);
            Assert.AreEqual(0, konto.Bilans);
            Assert.AreEqual(50, konto.LimitJednorazowy);
            Assert.IsFalse(konto.Zablokowane);
        }
    }
}
