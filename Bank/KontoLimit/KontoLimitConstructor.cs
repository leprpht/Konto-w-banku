namespace KontoLimit
{
    [TestClass]
    public sealed class KontoLimitConstructor
    {
        [TestMethod]
        public void Constructor()
        {
            Bank.KontoLimit konto = new Bank.KontoLimit(new Bank.Konto ("aaa", 50), 100);
            Assert.AreEqual(100, konto.Limit);
            Assert.AreEqual("aaa", konto.Konto.Nazwa);
            Assert.IsFalse(konto.Konto.Zablokowane);
            Assert.AreEqual(50, konto.Konto.Bilans);
        }
    }
}
