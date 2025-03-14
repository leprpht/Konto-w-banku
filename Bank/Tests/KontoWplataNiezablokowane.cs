namespace Tests;

[TestClass]
public class KontoWplataNiezablokowane
{
    [TestMethod]
    public void Wplata()
    {
        Bank.Konto konto = new Bank.Konto("aaa", 100);
        konto.Wplata(50);
        Assert.AreEqual(150, konto.Bilans);
    }
    [TestMethod]
    public void Exception()
    {
        Bank.Konto konto = new Bank.Konto("aaa", 100);
        Assert.ThrowsException<System.InvalidOperationException>(() => konto.Wplata(-50));
    }
}
