using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalaKriptoEvidencija2022
{
    class Korisnik
    {
        private string ime, prezime, korisnickoIme, lozinka;

        private List<Ulaganje> listaUlaganja;

        public Korisnik(string ime, string prezime, string korisnickoIme, string lozinka)
        {
            this.Ime = ime;
            this.Prezime = prezime;
            this.KorisnickoIme = korisnickoIme;
            this.Lozinka = lozinka;
            listaUlaganja = new List<Ulaganje>();
        }

        public string Ime { get => ime; 
            set
            {
                if (value.Trim().Length < 1)
                {
                    throw new Exception("Ime mora sadžati makar jedan karakter.");
                }
                ime = value;
            }
        }

        public string Prezime { get => prezime;
            set
            {
                if (value.Trim().Length < 1)
                {
                    throw new Exception("Prezime mora sadžati makar jedan karakter.");
                }
                prezime = value;
            }
        }

        public List<Ulaganje> ListaUlaganja { get => listaUlaganja; }

        public string KorisnickoIme { get => korisnickoIme;
            set
            {
                if (value.Trim().Length < 1)
                {
                    throw new Exception("Korisničko ime mora sadžati makar jedan karakter.");
                }
                korisnickoIme = value;
            }
        }

        public string Lozinka { get => lozinka;
            set
            {
                if (value.Trim().Length < 1)
                {
                    throw new Exception("Lozinka mora sadžati makar jedan karakter.");
                }
                lozinka = value;
            }
        }

        //indekser
        public Ulaganje this[int index]
        {
            get
            {
                return listaUlaganja[index];
            }
            set
            {
                listaUlaganja[index] = value;
            }
        }

        public int RedniBroj()
        {
            return listaUlaganja.Count + 1;
        }

        public string ValutaSaNajvecimUlogom()
        {
            if (listaUlaganja.Count > 0)
            {
                Dictionary<string, double> PR = new Dictionary<string, double>();
                foreach (Ulaganje ulaganje in listaUlaganja)
                {
                    if (PR.Keys.Contains(ulaganje.SifraKriptovalute))
                    {
                        PR[ulaganje.SifraKriptovalute] += ulaganje.Iznos;
                    }
                    else
                    {
                        PR[ulaganje.SifraKriptovalute] = ulaganje.Iznos;
                    }
                }
                double maxIznos = PR.Values.Max();
                string valutaSaNajvecimUlogom = "";
                foreach (string SifraKriptovalute in PR.Keys)
                {
                    if (PR[SifraKriptovalute] == maxIznos)
                    {
                        valutaSaNajvecimUlogom = SifraKriptovalute;
                    }
                }
                return valutaSaNajvecimUlogom;
            }
            else
            {
                return "X";
            }
        }

        public override string ToString()
        {
            return ime + " " + prezime;
        }
    }
}