using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalaKriptoEvidencija2022
{
    abstract class Valuta
    {
        protected string sifra;

        protected string naziv;

        public string Sifra { get => sifra;
            set
            {
                if (value.Length > 5)
                {
                    throw new Exception("Šifra valute ne može biti duža od 5. Npr: RSD, EUR, USD, BTC, ETH, USDT, USDC.");
                }
                sifra = value;
            }
        }

        public string Naziv { get => naziv; set => naziv = value; }

        public override string ToString()
        {
            return naziv + " (" + sifra + ")\t=>";
        }
    }
}
