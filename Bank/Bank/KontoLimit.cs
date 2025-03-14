using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public class KontoLimit
    {
        private Konto konto;
        private decimal limit;
        public Konto Konto { get { return konto; } }
        public decimal Limit { get { return limit; } }

        public KontoLimit(Konto konto, decimal limit)
        {
            this.konto = konto;
            this.limit = limit;
        }
        public void Wplata(decimal kwota)
        {
            konto.Wplata(kwota);
            if (konto.Bilans >= 0 && konto.Zablokowane)
                konto.OdblokujKonto();
        }
        public void Wyplata(decimal kwota)
        {
            if (kwota > limit)
                throw new System.InvalidOperationException("Przekroczono limit");
            if (konto.Zablokowane)
                throw new System.InvalidOperationException("Konto zablokowane");
            konto.ZmianaBilansu(konto.Bilans - kwota);
            if (konto.Bilans < 0)
                konto.BlokujKonto();
        }
        public void ZmianaLimitu(decimal kwota)
        {
            if (kwota < 0)
                throw new System.InvalidOperationException("Limit nie może być ujemny");
            limit = kwota;
        }
        public void BlokujKonto()
        {
            konto.BlokujKonto();
        }
        public void OdblokujKonto()
        {
            konto.OdblokujKonto();
        }
    }
}
