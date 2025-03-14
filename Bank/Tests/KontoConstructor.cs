namespace Tests
{
    [TestClass]
    public sealed class KontoConstructor
    {
        [TestMethod]
        public void ConstructorWithBalance()
        {
            Bank.Konto konto = new Bank.Konto("aaa", 100);
            Assert.AreEqual("aaa", konto.Nazwa);
            Assert.AreEqual(100, konto.Bilans);
            Assert.IsFalse(konto.Zablokowane);
        }
        [TestMethod]
        public void ConstructorNoBalance()
        {
            Bank.Konto konto = new Bank.Konto("aaa");
            Assert.AreEqual("aaa", konto.Nazwa);
            Assert.AreEqual(0, konto.Bilans);
            Assert.IsFalse(konto.Zablokowane);
        }
    }
}
