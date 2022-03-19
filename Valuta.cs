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
                if (value.Length > 4)
                {
                    throw new Exception("Šifra valute ne može biti duža od 4. Npr: BTC, ETH, USDT, USDC, LUNA, SOL, AVAX.");
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
