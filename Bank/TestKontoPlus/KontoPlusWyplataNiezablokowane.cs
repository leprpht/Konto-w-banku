namespace TestKontoPlus;

[TestClass]
public class KontoPlusWyplataNiezablokowane
{
    [TestMethod]
    public void Wyplata()
    {
        Bank.KontoPlus konto = new Bank.KontoPlus("aaa", 100, 100);
        konto.Wyplata(50);
        Assert.AreEqual(50, konto.Bilans);
    }
    public void WyplataExceptions()
    {
        Bank.KontoPlus konto = new Bank.KontoPlus("aaa", 100, 100);
        konto.Wyplata(50);
        Assert.ThrowsException<System.InvalidOperationException>(() => konto.Wyplata(-50));
        Assert.ThrowsException<System.InvalidOperationException>(() => konto.Wyplata(150));
    }
}
