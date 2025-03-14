namespace Tests;

[TestClass]
public class KontoDzialaniaZablokowane
{
    [TestMethod]
    public void KontoIfBlocked()
    {
        Bank.Konto konto = new Bank.Konto("aaa", 100);
        konto.BlokujKonto();
        Assert.IsTrue(konto.Zablokowane);
    }
    [TestMethod]
    public void KontoExceptions()
    {
        Bank.Konto konto = new Bank.Konto("aaa", 100);
        konto.BlokujKonto();
        Assert.ThrowsException<System.InvalidOperationException>(() => konto.Wyplata(50));
    }
}
