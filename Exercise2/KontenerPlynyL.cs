using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise2
{
    internal class KontenerPlynyL : Kontener, IHazardNotifier
    {
        protected bool czyNiebiezpiecznyLadunek { get; set; }
        public KontenerPlynyL(double masa_ladunku,
                         double wyokosc,
                         double waga_wlasna,
                         double glebokosc,
                         string rodzaj_kontenera,
                         double maksymalna_ladownosc,
                         bool czyNiebiezpiecznyLadunek) : base(masa_ladunku, wyokosc, waga_wlasna, glebokosc, rodzaj_kontenera, maksymalna_ladownosc)
        {
            this.czyNiebiezpiecznyLadunek = czyNiebiezpiecznyLadunek;

        }
        public void NotifyHazard(string msg)
        {
            Console.WriteLine($"Kontener {GetNumerSeryjny()} + {msg}");
        }
        public override double zaladujKontener(double masa)
        {
            if (czyNiebiezpiecznyLadunek && masa > maksymalna_ladownosc * 0.5)
            {
                NotifyHazard("Przy niebezpiecznych mozemy zaladowac tylko 50% kontenera!");
                return masa_ladunku *= 0.5;
            }
            else
            {
                masa_ladunku *= 0.9;
                return masa_ladunku;
            }
        }

    }

    
}
