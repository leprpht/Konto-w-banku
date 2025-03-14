namespace TestKontoPlus;

[TestClass]
public class KontoPlusLimitJednorazowyWplata
{
    [TestMethod]
    public void Wyplata()
    {
        Bank.KontoPlus konto = new Bank.KontoPlus("aaa", 100, 50);
        konto.Wyplata(100);
        Assert.AreEqual(-50, konto.Bilans);
    }
    [TestMethod]
    public void WyplataBlokowanie()
    {
        Bank.KontoPlus konto = new Bank.KontoPlus("aaa", 100, 50);
        konto.Wyplata(100);
        Assert.IsTrue(konto.Zablokowane);
    }
    [TestMethod]
    public void Wplata()
    {
        Bank.KontoPlus konto = new Bank.KontoPlus("aaa", 100, 50);
        konto.Wyplata(100);
        Assert.AreEqual(-50, konto.Bilans);
        Assert.IsTrue(konto.Zablokowane);
        konto.Wplata(100);
        Assert.AreEqual(50, konto.Bilans);
    }
    [TestMethod]
    public void WplataOdblokowanie()
    {
        Bank.KontoPlus konto = new Bank.KontoPlus("aaa", 100, 50);
        konto.Wyplata(100);
        Assert.AreEqual(-50, konto.Bilans);
        Assert.IsTrue(konto.Zablokowane);
        konto.Wplata(100);
        Assert.IsFalse(konto.Zablokowane);
    }
}
