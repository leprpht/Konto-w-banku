namespace Tests;

[TestClass]
public class KontoBlokujOdblokuj
{
    [TestMethod]
    public void BlokujOdblokuj()
    {
        Bank.Konto konto = new Bank.Konto("aaa", 100);
        konto.BlokujKonto();
        Assert.IsTrue(konto.Zablokowane);
        konto.OdblokujKonto();
        Assert.IsFalse(konto.Zablokowane);
    }
}
