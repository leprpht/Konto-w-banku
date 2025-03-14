namespace TestKontoPlus;

[TestClass]
public class KontoPlusZmianaLimitu
{
    [TestMethod]
    public void ZmianaLimitu()
    {
        Bank.KontoPlus konto = new Bank.KontoPlus("aaa", 100);
        konto.ZmianaLimitu(150);
        Assert.AreEqual(150, konto.LimitJednorazowy);
    }
    [TestMethod]
    public void ZmianaLimituException()
    {
        Bank.KontoPlus konto = new Bank.KontoPlus("aaa", 100);
        Assert.ThrowsException<System.InvalidOperationException>(() => konto.ZmianaLimitu(-50));
    }
}
