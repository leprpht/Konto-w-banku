using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public class KontoPlus : Konto
    {
        public decimal LimitJednorazowy { get; set; }
        public KontoPlus(string klient, decimal limitJednorazowy, decimal bilansNaStart = 0) : base(klient, bilansNaStart)
        {
            LimitJednorazowy = limitJednorazowy;
        }
        public void ZmianaLimitu(decimal nowyLimit)
        {
            if (nowyLimit < 0)
                throw new System.InvalidOperationException("Limit nie może być ujemny");
            LimitJednorazowy = nowyLimit;
        }
        public override void Wplata(decimal kwota)
        {
        base.Wplata(kwota);
            if (bilans >= 0)
                zablokowane = false;
        }
        public override void Wyplata(decimal kwota)
        {
            if (bilans >= kwota)
                base.Wyplata(kwota);
            else
            {
                if (kwota < 0)
                    throw new System.InvalidOperationException("Kwota musi być dodatnia");
                if (zablokowane)
                    throw new System.InvalidOperationException("Konto zablokowane");
                if (kwota > LimitJednorazowy)
                    throw new System.InvalidOperationException("Przekroczono limit jednorazowy");
                bilans -= kwota;
                zablokowane = true;
            }
        }
    }
}
