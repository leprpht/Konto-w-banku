namespace TestKontoPlus;

[TestClass]
public class KontoPlusBlokujOdblokuj
{
    [TestMethod]
    public void BlokujOdblokuj()
    {
        Bank.KontoPlus konto = new Bank.KontoPlus("aaa", 100, 100);
        konto.BlokujKonto();
        Assert.IsTrue(konto.Zablokowane);
        konto.OdblokujKonto();
        Assert.IsFalse(konto.Zablokowane);
    }
}
