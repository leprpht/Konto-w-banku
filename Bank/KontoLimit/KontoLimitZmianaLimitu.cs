namespace KontoLimit;

[TestClass]
public class KontoLimitZmianaLimitu
{
    [TestMethod]
    public void ZmianaLimitu()
    {
        Bank.KontoLimit konto = new Bank.KontoLimit(new Bank.Konto("aaa", 100), 100);
        konto.ZmianaLimitu(200);
        Assert.AreEqual(200, konto.Limit);
    }
    [TestMethod]
    public void ZmianaLimituExceptions()
    {
        Bank.KontoLimit konto = new Bank.KontoLimit(new Bank.Konto("aaa", 100), 100);
        Assert.ThrowsException<System.InvalidOperationException>(() => konto.ZmianaLimitu(-100));
    }
}
