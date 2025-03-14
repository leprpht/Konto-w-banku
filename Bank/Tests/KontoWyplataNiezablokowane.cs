namespace Tests;

[TestClass]
public class KontoWyplataNiezablokowane
{
    [TestMethod]
    public void Wyplata()
    {
        Bank.Konto konto = new Bank.Konto("aaa", 100);
        konto.Wyplata(50);
        Assert.AreEqual(50, konto.Bilans);
    }
    [TestMethod]
    public void Exceptions()
    {
        Bank.Konto konto = new Bank.Konto("aaa", 100);
        konto.Wyplata(50);
        Assert.ThrowsException<System.InvalidOperationException>(() => konto.Wyplata(-50));
    }
}
