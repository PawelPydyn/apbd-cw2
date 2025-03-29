using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise2
{
    internal class KontenerGazG : Kontener, IHazardNotifier
    {
        protected double cisnienie { get; set; }
        public KontenerGazG(double masa_ladunku,
                            double wyokosc,
                            double waga_wlasna,
                            double glebokosc,
                            string rodzaj_kontenera,
                            double maksymalna_ladownosc,
                            double cisnienie) : base(masa_ladunku, wyokosc, waga_wlasna, glebokosc, rodzaj_kontenera, maksymalna_ladownosc)
        {
            this.cisnienie = cisnienie;
        }
        public override double oproznijLadunek()
        {
            return this.masa_ladunku * 0.05;
        }
        public void NotifyHazard(string msg)
        {
            Console.WriteLine($"Kontener {GetNumerSeryjny()} + {msg}");
        }
        public override double zaladujKontener(double masa)
        {
            return base.zaladujKontener(masa);
        }
    }
}
