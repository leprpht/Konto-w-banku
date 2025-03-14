namespace KontoLimit;

[TestClass]
public class KontoLimitWplata
{
    [TestMethod]
    public void Wplata()
    {
        Bank.KontoLimit konto = new Bank.KontoLimit(new Bank.Konto("aaa", 50), 100);
        konto.Wplata(50);
        Assert.AreEqual(100, konto.Konto.Bilans);
    }
    [TestMethod]
    public void WplataOrazOdblokowanie()
    {
        Bank.KontoLimit konto = new Bank.KontoLimit(new Bank.Konto("aaa", -25), 100);
        konto.BlokujKonto();
        konto.Wplata(50);
        Assert.AreEqual(25, konto.Konto.Bilans);
        Assert.IsFalse(konto.Konto.Zablokowane);
    }
    [TestMethod]
    public void WplataExceptions()
    {
        Bank.KontoLimit konto = new Bank.KontoLimit(new Bank.Konto("aaa", 50), 100);
        Assert.ThrowsException<System.InvalidOperationException>(() => konto.Wplata(-50));
    }
}
