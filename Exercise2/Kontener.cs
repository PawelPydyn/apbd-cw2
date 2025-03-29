using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Exercise2
{
    internal abstract class Kontener : OverfillException
    {
        public static Dictionary<string,int> licznik = new Dictionary<string,int>();
        public double masa_ladunku { get; set; }
        public double wyokosc { get; set; }
        public double waga_wlasna { get; set; }
        public double glebokosc { get; set; }
        public String numer_seryjny { get; set; }
        public double maksymalna_ladownosc { get; set; }

        public Kontener(double masa_ladunku,
                        double wyokosc,
                        double waga_wlasna,
                        double glebokosc,
                        string rodzaj_kontenera,
                        double maksymalna_ladownosc)
        {
            this.masa_ladunku = masa_ladunku;
            this.wyokosc = wyokosc;
            this.waga_wlasna = waga_wlasna;
            this.glebokosc = glebokosc;
            this.numer_seryjny = GenerujNumerSeryjny(rodzaj_kontenera);
            this.maksymalna_ladownosc = maksymalna_ladownosc;
        }

        public String GetNumerSeryjny()
        {
            return this.numer_seryjny;
        }


        private string GenerujNumerSeryjny(string rodzajKontenera)
        {
            if (!licznik.ContainsKey(rodzajKontenera))
            {
                licznik[rodzajKontenera] = 1;
            }
            licznik[rodzajKontenera]++;
            return $"KON-{rodzajKontenera}-{licznik[rodzajKontenera]}";
        }


        public override string? ToString()
        {
            return $"{masa_ladunku} + {wyokosc} + {waga_wlasna} +{numer_seryjny} + {glebokosc} + {maksymalna_ladownosc}";
        }

        public virtual double oproznijLadunek()
        {
            return this.masa_ladunku = 0;

        }
        public  virtual double zaladujKontener(double masa) 
        {
            double nowaMasa = masa + this.masa_ladunku;
            
            if(nowaMasa > maksymalna_ladownosc)
            {
                throw new OverfillException($"Przekroczono ladownosc!!! {nowaMasa} kg > {maksymalna_ladownosc}");
            }
            else
            {
                this.masa_ladunku = nowaMasa;
            }
            return this.masa_ladunku;
          
        }
       
    }

}
