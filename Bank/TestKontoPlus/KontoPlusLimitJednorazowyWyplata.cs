namespace TestKontoPlus;

[TestClass]
public class KontoPlusLimitJednorazowyWyplata
{
    [TestMethod]
    public void Wplata()
    {
        Bank.KontoPlus konto = new Bank.KontoPlus("aaa", 100, 50);
        konto.Wyplata(100);
        Assert.AreEqual(-50, konto.Bilans);
    }
    [TestMethod]
    public void WplataBlokowanie()
    {
        Bank.KontoPlus konto = new Bank.KontoPlus("aaa", 100, 50);
        konto.Wyplata(100);
        Assert.IsTrue(konto.Zablokowane);
    }
}
