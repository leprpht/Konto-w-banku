namespace Bank
{
    public class Konto
    {
        protected string klient;
        protected decimal bilans;
        protected bool zablokowane = false;

        public string Nazwa { get { return klient; } }
        public decimal Bilans { get { return bilans; } }
        public bool Zablokowane { get { return zablokowane; } }

        private Konto() { }

        public Konto(string klient, decimal bilansNaStart = 0)
        {
            this.klient = klient;
            bilans = bilansNaStart;
        }
        public virtual void Wplata(decimal kwota)
        {
            if (kwota < 0)
                throw new System.InvalidOperationException("Kwota musi być dodatnia");
            bilans += kwota;
        }
        public virtual void Wyplata(decimal kwota)
        {
            if (kwota < 0)
                throw new System.InvalidOperationException("Kwota musi być dodatnia");
            if (zablokowane)
                throw new System.InvalidOperationException("Konto zablokowane");
            if (bilans < kwota)
                throw new System.InvalidOperationException("Brak środków na koncie");
            bilans -= kwota;
        }
        public void BlokujKonto()
        {
            zablokowane = true;
        }
        public void OdblokujKonto()
        {
            zablokowane = false;
        }
        public void ZmianaBilansu(decimal kwota)
        {
            bilans = kwota;
        }
    }
}
