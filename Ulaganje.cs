using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalaKriptoEvidencija2022
{
    class Ulaganje
    {
        private int redniBroj;

        private string sifraKriptovalute;

        private double iznos;

        private double cena;

        private string mesec;

        public Ulaganje(int redniBroj, string sifraKriptovalute, double iznos, double cena, string mesec)
        {
            this.RedniBroj = redniBroj;
            this.SifraKriptovalute = sifraKriptovalute;
            this.Iznos = iznos;
            this.Cena = cena;
            this.Mesec = mesec;
        }

        public int RedniBroj
        {
            get => redniBroj;
            set
            {
                if (value < 1)
                {
                    throw new Exception("Redni broj ne može biti negativan broj niti 0.");
                }
                redniBroj = value;
            }
        }

        public string SifraKriptovalute { get => sifraKriptovalute; set => sifraKriptovalute = value; }

        public double Iznos
        {
            get => iznos;
            set
            {
                if (value < 0)
                {
                    throw new Exception("Iznos ne može biti negativan broj.");
                }
                iznos = value;
            }
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

        public string Mesec
        {
            get => mesec;
            set
            {
                if (value != "januar"
                    && value != "februar"
                    && value != "mart"
                    && value != "april"
                    && value != "maj"
                    && value != "jun"
                    && value != "jul"
                    && value != "avgust"
                    && value != "septembar"
                    && value != "oktobar"
                    && value != "novembar"
                    && value != "decembar")
                {
                    throw new Exception("Mesec može biti: januar, februar, mart, april, maj, jun, jul, avgust, septembar, oktobar, novembar, decembar");
                }
                mesec = value;
            }
        }

        public override string ToString()
        {
            return redniBroj + "\t" + sifraKriptovalute + "\t" + iznos + "\t" + cena + "\t" + mesec;
        }
    }
}
