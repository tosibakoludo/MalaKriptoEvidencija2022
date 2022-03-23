using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalaKriptoEvidencija2022
{
    class Program
    {
        public static MalaKriptoEvidencija2022DataSetTableAdapters.KorisnikTableAdapter ad1 = new MalaKriptoEvidencija2022DataSetTableAdapters.KorisnikTableAdapter();

        public static MalaKriptoEvidencija2022DataSetTableAdapters.UlaganjeTableAdapter ad2 = new MalaKriptoEvidencija2022DataSetTableAdapters.UlaganjeTableAdapter();
        static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;

            List<Kriptovaluta> kriptovalute = new List<Kriptovaluta>();

            TrentnoStanjeKriptovaluta(kriptovalute);

            List<Korisnik> korisnici = UcitajKorisnikeIzBaze();
            UcitajUlaganjaIzBaze(korisnici);

            bool dozvola = true;
            while (dozvola)
            {
                Console.WriteLine("Odaberi opciju: ");
                Console.WriteLine("(1) prijavi se");
                Console.WriteLine("(2) registruj se");
                Console.WriteLine("(3) izađi iz programa");
                Console.Write(":");
                string opcija = Console.ReadLine();
                if (opcija == "1")
                {
                    Console.Clear();
                    TrentnoStanjeKriptovaluta(kriptovalute);
                    Console.Write("Korisničko ime: ");
                    string korisnickoIme = Console.ReadLine();
                    Console.Write("Lozinka: ");
                    string lozinka = null;
                    while (true)
                    {
                        var key = Console.ReadKey(true);
                        if (key.Key == ConsoleKey.Enter)
                            break;
                        lozinka += key.KeyChar;
                    }
                    Console.WriteLine();
                    bool nadjen = false;
                    bool dobraLozinka = false;
                    foreach (Korisnik korisnik in korisnici)
                    {
                        if (korisnickoIme == korisnik.KorisnickoIme && lozinka == korisnik.Lozinka)
                        {
                            Console.WriteLine("Zdravo, " + korisnik.Ime + "!");
                            Console.WriteLine("U nastavku je lista tvojih dosadašnjih ulaganja: ");
                            Console.WriteLine();
                            if (korisnik.ListaUlaganja.Count == 0)
                            {
                                Console.WriteLine("Nema evidentiranih ulaganja.");
                            }
                            else
                            {
                                Console.WriteLine("R.B.   |KRIPTO |IZN.(€)|CENA($)|MESEC ");
                                Console.WriteLine();
                                foreach (Ulaganje u in korisnik.ListaUlaganja)
                                {
                                    Console.WriteLine(u);
                                }
                            }
                            Console.WriteLine();
                            nadjen = true;
                            dobraLozinka = true;
                            bool dodajUlaganje = true;
                            while (dodajUlaganje)
                            {
                                Console.Write("Da li želiš da evidentiraš novo ulaganje (Da/Ne): ");
                                string odg1 = Console.ReadLine();
                                if (odg1 == "Da" || odg1 == "da" || odg1 == "DA" || odg1 == "dA")
                                {
                                    Console.Write("Unesi kod kriptovalute (npr. BTC): ");
                                    string sifraKriptovalute = Console.ReadLine().ToUpper();
                                    Console.Write("Unesi iznos ulaganja (EUR): ");
                                    double iznos;
                                    try
                                    {
                                        iznos = double.Parse(Console.ReadLine());
                                    }
                                    catch (FormatException)
                                    {
                                        Console.WriteLine("Iznos mora biti broj");
                                        continue;
                                    }
                                    Console.Write("Unesi cenu kriptovalute (USD): ");
                                    double cena;
                                    try
                                    {
                                        cena = double.Parse(Console.ReadLine());
                                    }
                                    catch (FormatException)
                                    {
                                        Console.WriteLine("Cena mora biti broj");
                                        continue;
                                    }
                                    Console.Write("Unesi mesec (npr. januar): ");
                                    string mesec = Console.ReadLine().ToLower();
                                    int redniBroj = korisnik.RedniBroj();
                                    Ulaganje un;
                                    try
                                    {
                                        un = new Ulaganje(redniBroj, sifraKriptovalute, iznos, cena, mesec);
                                    }
                                    catch (Exception e)
                                    {
                                        Console.WriteLine(e.Message);
                                        continue;
                                    }
                                    ad2.Insert(korisnik.Ime, un.RedniBroj, un.SifraKriptovalute, un.Iznos, un.Cena, un.Mesec);
                                    UcitajUlaganjaIzBaze(korisnici);
                                    Console.Clear();
                                    TrentnoStanjeKriptovaluta(kriptovalute);
                                    Console.WriteLine("Bravo, " + korisnik.Ime + "!");
                                    Console.WriteLine();
                                    Console.WriteLine("U nastavku je lista tvojih dosadašnjih ulaganja: ");
                                    Console.WriteLine();
                                    if (korisnik.ListaUlaganja.Count == 0)
                                    {
                                        Console.WriteLine("Nema evidentiranih ulaganja.");
                                    }
                                    else
                                    {
                                        Console.WriteLine("R.B.   |KRIPTO |IZN.(€)|CENA($)|MESEC ");
                                        Console.WriteLine();
                                        foreach (Ulaganje u in korisnik.ListaUlaganja)
                                        {
                                            Console.WriteLine(u);
                                        }
                                    }
                                    Console.WriteLine();
                                }
                                else
                                {
                                    dodajUlaganje = false;
                                    Console.Clear();
                                    TrentnoStanjeKriptovaluta(kriptovalute);
                                }
                            }
                        }
                        else if (korisnickoIme == korisnik.KorisnickoIme)
                        {
                            nadjen = true;
                            dobraLozinka = false;
                        }
                    }
                    if (!nadjen)
                    {
                        Console.WriteLine("Korisnik nije pronađen, probajte ponovo, ili registrujte novog korisnika.");
                    }
                    else if (!dobraLozinka)
                    {
                        Console.WriteLine("Niste uneli dobru lozinku, probajte ponovo.");
                    }
                }
                else if (opcija == "2")
                {
                    Console.Clear();
                    TrentnoStanjeKriptovaluta(kriptovalute);
                    Console.Write("Ime: ");
                    string ime = Console.ReadLine();
                    Console.Write("Prezime: ");
                    string prezime = Console.ReadLine();
                    Console.Write("Korisničko ime: ");
                    string korisnickoIme = Console.ReadLine();
                    try
                    {
                        foreach (Korisnik korisnik in korisnici)
                        {
                            if (korisnik.KorisnickoIme == korisnickoIme)
                            {
                                throw new Exception("Korisnik sa izabranim korisničkim imenom već postoji, molimo probajte ponovo.");
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        continue;
                    }
                    Console.Write("Lozinka: ");
                    string lozinka = null;
                    while (true)
                    {
                        var key = Console.ReadKey(true);
                        if (key.Key == ConsoleKey.Enter)
                            break;
                        lozinka += key.KeyChar;
                    }
                    Console.WriteLine();
                    Korisnik k = new Korisnik(ime, prezime, korisnickoIme, lozinka);
                    ad1.Insert(k.Ime, k.Prezime, k.KorisnickoIme, k.Lozinka);
                    korisnici = UcitajKorisnikeIzBaze();
                    UcitajUlaganjaIzBaze(korisnici);
                    Console.WriteLine("Uspešno ste registrovani. Možete se prijaviti.");
                }
                else if (opcija == "3")
                {
                    Console.Clear();
                    Console.WriteLine("Doviđenja!\n");
                    dozvola = false;
                }
            }

            IzvestajOKoriscenjuPrograma(korisnici);
        }

        private static void IzvestajOKoriscenjuPrograma(List<Korisnik> korisnici)
        {
            string sadrzaj = "";
            foreach (Korisnik korisnik in korisnici)
            {
                sadrzaj += "Korisnik: ";
                sadrzaj += korisnik.ToString().ToUpper() + "\n";
                if (korisnik.ListaUlaganja.Count == 0)
                {
                    sadrzaj += "\nNema evidentiranih ulaganja." + "\n";
                }
                else
                {
                    sadrzaj += "\nR.B.   |KRIPTO |IZN.(€)|CENA($)|MESEC \n";
                    foreach (Ulaganje u in korisnik.ListaUlaganja)
                    {
                        sadrzaj += u + "\n";
                    }
                }
                sadrzaj += "\nKorisnik je najviše uložio u: " + korisnik.ValutaSaNajvecimUlogom() + "\n";
                sadrzaj += "\n\n";
            }
            Console.WriteLine(sadrzaj);
            string fajl = "izvestaj" + DateTime.Now.ToString("ddMMyyyyHHmmss") + ".txt";
            System.IO.File.WriteAllText(fajl, sadrzaj);
            Console.WriteLine("Izveštaj o korišćenju programa " + fajl + " je uspešno sačuvan.");
            Console.ReadLine();
        }

        private static void TrentnoStanjeKriptovaluta(List<Kriptovaluta> kriptovalute)
        {
            Console.WriteLine("Izvori:");
            try
            {
                string json = System.IO.File.ReadAllText("kriptovalute.json");
                kriptovalute = JsonConvert.DeserializeObject<List<Kriptovaluta>>(json);
                Console.WriteLine("- kriptovalute.json");
            }
            catch
            {
                Kriptovaluta kripto1 = new Kriptovaluta("BTC ", "Bitcoin  ", 40000, 765000000000, 30000000000);
                Kriptovaluta kripto2 = new Kriptovaluta("ETH ", "Ethereum ", 2700, 320000000000, 15000000000);
                Kriptovaluta kripto3 = new Kriptovaluta("USDT", "Tether   ", 1, 79000000000, 51000000000);
                kriptovalute.Add(kripto1);
                kriptovalute.Add(kripto2);
                kriptovalute.Add(kripto3);
                Console.WriteLine("- programski generisani podaci");
                System.IO.File.WriteAllText("kriptovalute.json", JsonConvert.SerializeObject(kriptovalute));
            }

            try
            {
                string[] linije = System.IO.File.ReadAllLines("kriptovalute.txt");
                foreach (string linija in linije)
                {
                    string[] niz = linija.Split('\t');
                    Kriptovaluta kripto = new Kriptovaluta(niz[0], niz[1], double.Parse(niz[2]), long.Parse(niz[3]), long.Parse(niz[4]));
                    kriptovalute.Add(kripto);
                }
                Console.WriteLine("- kriptovalute.txt");
            }
            catch
            {

            }
            Console.WriteLine("\nTRENUTNO STANJE NA KRIPTO TRŽIŠTU: ");
            foreach (Kriptovaluta kripto in kriptovalute)
            {
                Console.WriteLine(kripto);
            }
            Console.WriteLine();
        }

        private static void UcitajUlaganjaIzBaze(List<Korisnik> korisnici)
        {
            MalaKriptoEvidencija2022DataSet.UlaganjeDataTable t = new MalaKriptoEvidencija2022DataSet.UlaganjeDataTable();

            ad2.Fill(t);

            foreach (Korisnik korisnik in korisnici)
            {
                korisnik.ListaUlaganja.Clear();
                foreach (DataRow r in t.Rows)
                {
                    if (r[0].ToString() == korisnik.Ime)
                    {
                        Ulaganje u = new Ulaganje(int.Parse(r[1].ToString()), r[2].ToString(), double.Parse(r[3].ToString()), double.Parse(r[4].ToString()), r[5].ToString());
                        korisnik.ListaUlaganja.Add(u);
                    }
                }
            }
        }

        private static List<Korisnik> UcitajKorisnikeIzBaze()
        {
            List<Korisnik> korisnici = new List<Korisnik>();
            MalaKriptoEvidencija2022DataSet.KorisnikDataTable t = new MalaKriptoEvidencija2022DataSet.KorisnikDataTable();

            ad1.Fill(t);

            foreach (DataRow r in t.Rows)
            {
                Korisnik korisnik = new Korisnik(r[0].ToString(), r[1].ToString(), r[2].ToString(), r[3].ToString());
                korisnici.Add(korisnik);
            }

            return korisnici;
        }
    }
}