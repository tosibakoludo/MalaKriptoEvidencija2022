using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalaKriptoEvidencija2022
{
    class Kriptovaluta : Valuta
    {
        private double cena;

        private long trzisnaVrednost;

        private long obim24h;

        public Kriptovaluta(string sifra, string naziv, double cena, long trzisnaVrednost, long obim24h)
        {
            this.Sifra = sifra;
            this.Naziv = naziv;
            this.Cena = cena;
            this.TrzisnaVrednost = trzisnaVrednost;
            this.Obim24h = obim24h;
        }

        public double Cena
        {
            get => cena;
            set
            {
                if (value < 0)
                {
                    throw new Exception("Cena ne može biti negativan broj.");
                }
                cena = value;
            }
        }

        public long TrzisnaVrednost
        {
            get => trzisnaVrednost;
            set
            {
                if (value < 0)
                {
                    throw new Exception("Tržišna vrednost ne može biti negativan broj.");
                }
                trzisnaVrednost = value;
            }
        }

        public long Obim24h
        {
            get => obim24h;
            set
            {
                if (value < 0)
                {
                    throw new Exception("Obim trgovine ne može biti negativan broj.");
                }
                obim24h = value;
            }
        }

        public override string ToString()
        {
            return base.ToString() + " cena = " + cena + "\t| tržišna vrednost = " + trzisnaVrednost + "\t| obim trgovine (24h) = " + obim24h;
        }
    }
}
