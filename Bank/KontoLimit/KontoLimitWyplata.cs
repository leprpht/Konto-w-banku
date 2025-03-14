namespace KontoLimit;

[TestClass]
public class KontoLimitWyplata
{
    [TestMethod]
    public void Wyplata()
    {
        Bank.KontoLimit konto = new Bank.KontoLimit(new Bank.Konto("aaa", 100), 100);
        konto.Wyplata(50);
        Assert.AreEqual(50, konto.Konto.Bilans);
    }
    [TestMethod]
    public void WyplataException()
    {
        Bank.KontoLimit konto = new Bank.KontoLimit(new Bank.Konto("aaa", 200), 50);
        Assert.ThrowsException<System.InvalidOperationException>(() => konto.Wyplata(100));
    }
    [TestMethod]
    public void WyplataGreaterThanBalance()
    {
        Bank.KontoLimit konto = new Bank.KontoLimit(new Bank.Konto("aaa", 50), 100);
        konto.Wyplata(100);
        Assert.AreEqual(-50, konto.Konto.Bilans);
        Assert.IsTrue(konto.Konto.Zablokowane);
    }
    [TestMethod]
    public void WyplataZablokowane()
    {
        Bank.KontoLimit konto = new Bank.KontoLimit(new Bank.Konto("aaa", 200), 50);
        konto.BlokujKonto();
        Assert.ThrowsException<System.InvalidOperationException>(() => konto.Wyplata(50));
    }
}
