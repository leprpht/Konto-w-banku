namespace TestKontoPlus;

[TestClass]
public class KontoPlusWplataNiezablokowane
{
    [TestMethod]
    public void Wplata()
    {
        Bank.KontoPlus konto = new Bank.KontoPlus("aaa", 100, 100);
        konto.Wplata(50);
        Assert.AreEqual(150, konto.Bilans);
    }
    [TestMethod]
    public void WplataExceptions()
    {
        Bank.KontoPlus konto = new Bank.KontoPlus("aaa", 100, 100);
        konto.Wplata(50);
        Assert.ThrowsException<System.InvalidOperationException>(() => konto.Wplata(-50));
    }
}
